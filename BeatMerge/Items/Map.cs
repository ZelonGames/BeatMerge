using System;
using System.Linq;
using System.Collections.Generic;


namespace BeatMerge.Items
{
    public class Map
    {
        public string _version { get; set; }
        public double _beatsPerMinute { get; set; }
        public double _beatsPerBar { get; set; }
        public double _noteJumpSpeed { get; set; }
        public double _shuffle { get; set; }
        public double _shufflePeriod { get; set; }

        public Event[] _events { get; set; }
        public Note[] _notes { get; set; }
        public Obstacle[] _obstacles { get; set; }

        public Map(string version, double beatsPerMinute, double beatsPerBar, double noteJumpSpeed, double shuffle, double shufflePeriod,
            Event[] events, Note[] notes, Obstacle[] obstacles)
        {
            this._version = version;
            this._beatsPerMinute = beatsPerMinute;
            this._beatsPerBar = beatsPerBar;
            this._noteJumpSpeed = noteJumpSpeed;
            this._shuffle = shuffle;
            this._shufflePeriod = shufflePeriod;

            this._events = events;
            this._notes = notes;
            this._obstacles = obstacles;
        }

        public static Map GetMergedMap(Map mapBegin, Map mapEnd)
        {
            double timeDifference = GetTimeDifference(mapBegin, mapEnd);
            MoveItemsTowardsMarker(mapEnd, timeDifference);

            mapEnd.StretchToNewBPM(mapBegin);

            List<Event> newEvents = mapBegin._events.ToList();
            List<Note> newNotes = mapBegin._notes.ToList();
            List<Obstacle> newObstacles = mapBegin._obstacles.ToList();

            // Remove the last note that's used as a marker
            newNotes.Remove(newNotes.Last());

            foreach (var mergeEvent in mapEnd._events)
                newEvents.Add(mergeEvent);

            foreach (var mergeNote in mapEnd._notes)
                newNotes.Add(mergeNote);

            foreach (var mergeObstacle in mapEnd._obstacles)
                newObstacles.Add(mergeObstacle);

            return new Map(mapBegin._version, mapBegin._beatsPerMinute, mapBegin._beatsPerBar, mapBegin._noteJumpSpeed, mapBegin._shuffle, mapBegin._shufflePeriod,
                newEvents.ToArray(), newNotes.ToArray(), newObstacles.ToArray());
        }

        private static void MoveItemsTowardsMarker(Map map, double timeDifference)
        {
            foreach (var endEvent in map._events)
                endEvent._time -= timeDifference;
            foreach (var endNote in map._notes)
                endNote._time -= timeDifference;
            foreach (var endObstacle in map._obstacles)
                endObstacle._time -= timeDifference;
        }

        private void StretchToNewBPM(Map newMap)
        {
            foreach (var obstacle in _obstacles)
                obstacle.ClosestNote = obstacle.GetClosestNote(_notes);
            foreach (var _event in _events)
                _event.ClosestNote = _event.GetClosestNote(_notes);

            double comparedBPM = _beatsPerMinute / newMap._beatsPerMinute;

            var groupedNotes = GetGroupedItems<Note>(_notes);

            for (int i = 1; i < groupedNotes.Count; i++)
            {
                List<Note> prevGroup = groupedNotes[i - 1];
                List<Note> currentGroup = groupedNotes[i];

                double distance = currentGroup.First()._time - prevGroup.First()._time;

                double distanceToMove = distance - (distance / comparedBPM);
                currentGroup.ForEach(x => x._time -= distanceToMove);

                for (int j = i + 1; j < groupedNotes.Count; j++)
                {
                    currentGroup = groupedNotes[j];
                    currentGroup.ForEach(n => n._time -= distanceToMove);
                }
            }

            foreach (var obstacle in _obstacles)
            {
                double newOffset = obstacle._time - obstacle.ClosestNote._time;
                obstacle._time -= newOffset - obstacle.NoteOffset;
            }
            foreach(var _event in _events)
            {
                double newOffset = _event._time - _event.ClosestNote._time;
                _event._time -= newOffset - _event.NoteOffset;
            }
        }

        public List<List<T>> GetGroupedItems<T>(T[] items) where T : ItemBase
        {
            var groupedItemsList = new List<List<T>>();
            var groupedItemsDict = new Dictionary<double, List<T>>();

            for (int i = 0; i < items.Length; i++)
            {
                T currentNote = items[i];

                if (groupedItemsDict.ContainsKey(currentNote._time))
                {
                    groupedItemsDict[currentNote._time].Add(currentNote);
                    groupedItemsList.Last().Add(currentNote);
                }
                else
                {
                    groupedItemsDict.Add(currentNote._time, new List<T>());
                    groupedItemsDict[currentNote._time].Add(currentNote);

                    var noteList = new List<T>();
                    noteList.Add(currentNote);
                    groupedItemsList.Add(noteList);
                }
            }

            return groupedItemsList;
        }

        public static double GetTimeDifference(Map mapBegin, Map mapEnd)
        {
            Note lastBeginNote = mapBegin._notes.Last();
            Note firstEndNote = mapEnd._notes.First();

            return firstEndNote._time - lastBeginNote._time;
        }
    }
}
