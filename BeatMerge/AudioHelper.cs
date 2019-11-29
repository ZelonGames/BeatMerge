using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio.Wave;
using NVorbis;
using NAudio.Lame;

using Alvas.Audio;

namespace BeatMerge
{
    public static class AudioHelper
    {
        public static void ConvertToMp3(string file)
        {
            string newFile = file.Replace(Path.GetExtension(file), "");

            using (var vorbis = new VorbisReader(file))
            using (var outFile = File.Create(newFile))
            using (var writer = new BinaryWriter(outFile))
            {
                writer.Write(Encoding.ASCII.GetBytes("RIFF"));
                writer.Write(0);
                writer.Write(Encoding.ASCII.GetBytes("WAVE"));
                writer.Write(Encoding.ASCII.GetBytes("fmt "));
                writer.Write(18);
                writer.Write((short)1);
                writer.Write((short)vorbis.Channels);
                writer.Write(vorbis.SampleRate);
                writer.Write(vorbis.SampleRate * vorbis.Channels * 2);
                writer.Write((short)(2 * vorbis.Channels));
                writer.Write((short)16);
                writer.Write((short)0);

                writer.Write(Encoding.ASCII.GetBytes("data"));
                writer.Flush();
                var dataPos = outFile.Position;
                writer.Write(0);

                var buf = new float[vorbis.SampleRate / 10 * vorbis.Channels];
                int count;
                while ((count = vorbis.ReadSamples(buf, 0, buf.Length)) > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        var temp = (int)(32767f * buf[i]);
                        if (temp > 32767)
                            temp = 32767;
                        else if (temp < -32768)
                            temp = -32768;

                        writer.Write((short)temp);
                    }
                }
                writer.Flush();

                writer.Seek(4, SeekOrigin.Begin);
                writer.Write((int)(outFile.Length - 8L));

                writer.Seek((int)dataPos, SeekOrigin.Begin);
                writer.Write((int)(outFile.Length - dataPos - 4L));

                writer.Flush();
            }

            DsReader dr = new DsReader(newFile);
            IntPtr formatPcm = dr.ReadFormat();

            byte[] dataPcm = dr.ReadData();
            dr.Close();

            IntPtr formatMp3 = AudioCompressionManager.GetCompatibleFormat(formatPcm, AudioCompressionManager.MpegLayer3FormatTag);

            byte[] dataMp3 = AudioCompressionManager.Convert(formatPcm, formatMp3, dataPcm, false);
            File.Delete(newFile);
            Mp3Writer mw = new Mp3Writer(File.Create(newFile + ".mp3"));

            mw.WriteData(dataMp3);
            mw.Close();
        }

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
