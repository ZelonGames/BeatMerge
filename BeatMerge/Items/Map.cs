using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

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

        public Map(double beatsPerMinute, double noteJumpSpeed, Event[] events, Note[] notes, Obstacle[] obstacles)
        {
            this._version = "1.5.0";
            this._beatsPerMinute = beatsPerMinute;
            this._beatsPerBar = 16;
            this._noteJumpSpeed = noteJumpSpeed;
            this._shuffle = 0;
            this._shufflePeriod = 0.5;

            this._events = events;
            this._notes = notes;
            this._obstacles = obstacles;
        }

        public void Create(string path)
        {
            string data = JsonConvert.SerializeObject(this);
            using (StreamWriter wr = new StreamWriter(path))
            {
                wr.WriteLine(data);
            }
        }

        public static double GetSecondsInBeats(double bpm, double ms)
        {
            return (bpm / 60) * ms;
        }
        public static double GetBeatLengthInSeconds(double bpm)
        {
            return 60d / bpm;
        }
    }
}
