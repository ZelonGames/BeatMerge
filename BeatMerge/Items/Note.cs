
namespace BeatMerge.Items
{
    public class Note : ItemBase
    {
        public int _lineIndex { get; set; }
        public int _lineLayer { get; set; }
        public int _type { get; set; }
        public int _cutDirection { get; set; }
    }
}
