using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BeatMerge.Items
{
    public abstract class ItemBase
    {
        [JsonIgnore]
        public Note ClosestNote { get; private set; }
        [JsonIgnore]
        public double NoteOffset { get; private set; }
        public double _time { get; set; }

        public void SetClosestNote(Note[] notes)
        {
            Note closestNote = notes[0];

            for (int i = 1; i < notes.Length; i++)
            {
                Note currentNote = notes[i];

                if (Math.Abs(_time - currentNote._time) < Math.Abs(_time - closestNote._time))
                    closestNote = currentNote;
            }

            NoteOffset = _time - closestNote._time;

            ClosestNote = closestNote;
        }

        public static void ConvertItemBeatsToSeconds<T>(T[] items, List<T> mergedItems, double bpm) where T : ItemBase
        {
            foreach (var item in items)
            {
                item._time *= Map.GetBeatLengthInSeconds(bpm);
                mergedItems.Add(item);
            }
        }

        public static void ConvertItemSecondsToBeats<T>(List<T> items, double bpm) where T : ItemBase
        {
            foreach (var item in items)
                item._time = Map.GetSecondsInBeats(bpm, item._time);
        }
    }
}
