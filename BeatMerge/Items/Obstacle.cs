using System;

namespace BeatMerge.Items
{
    public class Obstacle : ItemBase
    {
        public int _lineIndex { get; set; }
        public int _type { get; set; }
        public int _duration { get; set; }
        public int _width { get; set; }
    }
}
