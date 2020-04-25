using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace BeatMerge.Difficulty
{
    public class Rootobject
    {
        public string _version { get; set; }
        public _Events[] _events { get; set; }
        public _Notes[] _notes { get; set; }
        public _Obstacles[] _obstacles { get; set; }
        public _Customdata _customData { get; set; }

        public void Create(string path)
        {
            string data = JsonConvert.SerializeObject(this);
            using (StreamWriter wr = new StreamWriter(path))
            {
                wr.WriteLine(data);
            }
        }

        public double GetFirstItemTimestamp()
        {
            double? noteTimestamp = null;
            if (_notes.Length > 0)
                noteTimestamp = _notes.First()._time;

            double? eventTimeStamp = null;
            if (_events.Length > 0)
                eventTimeStamp = _events.First()._time;

            double? obstacleTimeStamp = null;
            if (_obstacles.Length > 0)
                obstacleTimeStamp = _obstacles.First()._time;

            var timestamps = new List<double>();
            if (noteTimestamp.HasValue)
                timestamps.Add(noteTimestamp.Value);
            /*
            if (eventTimeStamp.HasValue)
                timestamps.Add(eventTimeStamp.Value);

            if (obstacleTimeStamp.HasValue)
                timestamps.Add(obstacleTimeStamp.Value);*/

            return timestamps.Min();
        }

        public static double SecondsToBeats(double bpm, double seconds)
        {
            return seconds / (60 / bpm);
        }

        public static double MSToBeats(double bpm, double ms)
        {
            if (ms == 0)
                return 0;
            return ms / (60000 / bpm);
        }

        public static double BPMToMS(double bpm)
        {
            return 60000d / bpm;
        }

        public static double GetBeatLengthInSeconds(double bpm)
        {
            return 60d / bpm;
        }

        public static double GetBeatLengthInMS(double bpm)
        {
            return 60000d / bpm;
        }
    }

    public class _Customdata
    {
        public float _time { get; set; }
        public object[] _BPMChanges { get; set; }
        public object[] _bookmarks { get; set; }
    }

    public class _Events : ItemBase.ItemBase
    {
        public _Events(int type, int value, double time) : base(time)
        {
            _type = type;
            _value = value;
        }

        public int _type { get; set; }
        public int _value { get; set; }
    }

    public class _Notes : ItemBase.ItemBase
    {
        public _Notes(int lineIndex, int lineLayer, int type, int cutDirection, double time) : base(time)
        {
            _lineIndex = lineIndex;
            _lineLayer = lineLayer;
            _type = type;
            _cutDirection = cutDirection;
        }

        public int _lineIndex { get; set; }
        public int _lineLayer { get; set; }
        public int _type { get; set; }
        public int _cutDirection { get; set; }
    }

    public class _Obstacles : ItemBase.ItemBase
    {
        public _Obstacles(int lineIndex, int type, double duration, int width, double time) : base(time)
        {
            _lineIndex = lineIndex;
            _type = type;
            _duration = duration;
            _width = width;
        }

        public int _lineIndex { get; set; }
        public int _type { get; set; }
        public double _duration { get; set; }
        public int _width { get; set; }
    }
}