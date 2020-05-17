using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using NAudio.Vorbis;

namespace BeatMerge
{
    public class CustomMap
    {
        private VorbisWaveReader audio;

        public readonly string difficultyPath;
        public readonly string infoPath;
        public readonly string directoryPath;
        public readonly string displayName;
        public readonly double SongLengthInMilliSeconds;
        public readonly int songLengthInMS;

        public Difficulty.Rootobject map { get; private set; }
        public Info.Rootobject info { get; private set; }

        public string audioPath { get; private set; }

        public CustomMap(string selectedFile, string selectedSongPackName, bool createFile)
        {
            selectedSongPackName = selectedSongPackName.Replace("\\", "\\");
               difficultyPath = selectedFile.Replace("\\", "/");
            string[] folders = difficultyPath.Split('/');
            directoryPath = selectedSongPackName + "\\" + folders[folders.Length - 2];

            string[] selectedPathFolders = selectedFile.Split('\\');
            string selectedDirectoryPath = selectedFile.Replace(selectedPathFolders.Last(), "").Replace("\\", "/");
            string infoFile = selectedDirectoryPath + "info.dat";
            infoPath = directoryPath + "\\info.dat";

            if (createFile)
            {
                Directory.CreateDirectory(directoryPath);

                displayName = folders[folders.Length - 2] + " - " + folders.Last().Replace(".dat", "");

                string newPath = directoryPath + "/" + displayName + ".dat";
                difficultyPath = newPath;

                try
                {
                    File.Copy(infoFile, infoPath);
                    File.Copy(selectedFile, newPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
                displayName = folders.Last().Replace(".dat", "");

            string difficultyJsonData = File.ReadAllText(difficultyPath);
            string infoJsonData = File.ReadAllText(infoPath);

            map = JsonConvert.DeserializeObject<Difficulty.Rootobject>(difficultyJsonData);
            info = JsonConvert.DeserializeObject<Info.Rootobject>(infoJsonData);

            audioPath = directoryPath + "/" + info._songFilename;

            if (createFile)
            {
                try
                {
                    File.Copy(selectedDirectoryPath + info._songFilename, audioPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            try
            {
                audio = new VorbisWaveReader(audioPath);
                SongLengthInMilliSeconds = audio.TotalTime.TotalMilliseconds;
                audio.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
