using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio.Wave;

namespace BeatMerge
{
    public static class AudioHelper
    {
        public static void Combine(string outputFileName, string[] inputFiles)
        {
            using (var output = new FileStream(outputFileName, FileMode.Create))
            {
                foreach (string file in inputFiles)
                {
                    Mp3FileReader reader = new Mp3FileReader(file);
                    if ((output.Position == 0) && (reader.Id3v2Tag != null))
                        output.Write(reader.Id3v2Tag.RawData, 0, reader.Id3v2Tag.RawData.Length);

                    Mp3Frame frame;
                    while ((frame = reader.ReadNextFrame()) != null)
                        output.Write(frame.RawData, 0, frame.RawData.Length);
                }
            }
        }
    }
}
