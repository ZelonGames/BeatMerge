using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatMerge.Items
{
    public abstract class ItemBase
    {
        public Note ClosestNote { get; set; }
        public double NoteOffset { get; private set; }
        public double _time { get; set; }

        public Note GetClosestNote(Note[] notes)
        {
            Note closestNote = notes[0];

            for (int i = 1; i < notes.Length; i++)
            {
                Note currentNote = notes[i];

                if (Math.Abs(_time - currentNote._time) < Math.Abs(_time - closestNote._time))
                    closestNote = currentNote;
            }

            NoteOffset = _time - closestNote._time;

            return closestNote;
        }
    }
}
