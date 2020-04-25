
using System.Collections.Generic;


namespace BeatMerge.ItemBase
{
    public abstract class ItemBase
    {
        protected ItemBase(double time)
        {
            _time = time;
        }

        public double _time { get; set; }

        public static void ConvertItemBeatsToSeconds<T>(T[] items, List<T> mergedItems, double bpm) where T : ItemBase
        {
            foreach (var item in items)
            {
                item._time *= Difficulty.Rootobject.GetBeatLengthInSeconds(bpm);
                mergedItems.Add(item);
            }
        }

        public static void ConvertItemSecondsToBeats<T>(List<T> items, double bpm) where T : ItemBase
        {
            foreach (var item in items)
            {
                item._time = Difficulty.Rootobject.SecondsToBeats(bpm, item._time);
            }
        }

        public static void MoveItems<T>(T[] items, double distanceToMove) where T : ItemBase
        {
            foreach (var item in items)
            {
                item._time += distanceToMove;
            }
        }
    }
}
