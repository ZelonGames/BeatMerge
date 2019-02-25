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
        public double _time { get; set; }

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
