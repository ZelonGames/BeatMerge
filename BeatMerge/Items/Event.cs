
namespace BeatMerge.Items
{
    public class Event : ItemBase
    {
        public Event(int type, int value, double time) : base(time)
        {
            _type = type;
            _value = value;
        }

        public int _type { get; set; }
        public int _value { get; set; }
    }
}
