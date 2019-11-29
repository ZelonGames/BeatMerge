using System;

namespace BeatMerge.Items
{
    public class Obstacle : ItemBase
    {
        public Obstacle(int lineIndex, int type, double duration, double width, double time) : base(time)
        {
            _lineIndex = lineIndex;
            _type = type;
            _duration = duration;
            _width = width;
        }

        public int _lineIndex { get; set; }
        public int _type { get; set; }
        public double _duration { get; set; }
        public double _width { get; set; }
    }
}
