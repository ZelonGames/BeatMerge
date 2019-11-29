
namespace BeatMerge.Items
{
    public class Note : ItemBase
    {
        public Note(int lineIndex, int lineLayer, int type, int cutDirection, double time) : base(time)
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
}
