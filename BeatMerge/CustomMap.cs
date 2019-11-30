using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

using BeatMerge.Items;
using NAudio.Vorbis;

namespace BeatMerge
{
    public class CustomMap
    {
        public readonly VorbisWaveReader audio;

        public readonly Map map;
        public readonly SongInfo info;

        public readonly string audioPath;
        public readonly string difficultyPath;
        public readonly string infoPath;
        public readonly string directoryPath;
        public readonly string displayName;

        public readonly int songLengthInMS;

        public CustomMap(string selectedFile, string selectedSongPackName, bool createFile)
        {
            difficultyPath = selectedFile;
            string[] folders = difficultyPath.Split('\\');
            directoryPath = Form1.songPackFolder + "/" + selectedSongPackName + "/" + folders[folders.Length - 2];

            string[] selectedPathFolders = selectedFile.Split('\\');
            string selectedDirectoryPath = selectedFile.Replace(selectedPathFolders.Last(), "").Replace("\\", "/");
            string infoFile = "";

            infoFile = selectedDirectoryPath + "info.dat";
            infoPath = directoryPath + "/info.dat";

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

            map = JsonConvert.DeserializeObject<Map>(difficultyJsonData);
            info = JsonConvert.DeserializeObject<SongInfo>(infoJsonData);

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

            audio = new VorbisWaveReader(audioPath);
        }
    }
}
