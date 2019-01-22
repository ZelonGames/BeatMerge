using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;
using BeatMerge.Items;

namespace BeatMerge
{
    public partial class Form1 : Form
    {
        private List<SongPack> songPacks = new List<SongPack>();

        public const string songPackFolder = "SongPacks";

        private string SelectedSongPackName => listSongPacks.Items[listSongPacks.SelectedIndex].ToString();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReLoadSongPacks();
        }

        #region Events

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName.EndsWith(".json"))
                    listMap.Items.Add(new MapFile(openFileDialog.FileName, SelectedSongPackName, true).DisplayName);
                else
                    MessageBox.Show("You must select a .json file!");
            }
        }

        private void btnAddSongPack_Click(object sender, EventArgs e)
        {
            string songPackInputName = txtSongPackName.Text.Replace("\\", "").Replace(".", "").Replace("/", "");
            if (string.IsNullOrEmpty(songPackInputName))
                return;

            if (!Directory.Exists(songPackFolder))
                Directory.CreateDirectory(songPackFolder);

            string songPackName = songPackFolder + "/" + songPackInputName;
            songPacks.Add(new SongPack(songPackName, true));
            ReLoadSongPacks();
        }

        private void listSongPacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            grpMaps.Visible = true;

            SongPack selectedSongPack = songPacks[listSongPacks.SelectedIndex];
            selectedSongPack.ReLoadMapFiles(listMap);
        }

        private void btnDeleteSongPack_Click(object sender, EventArgs e)
        {
            if (listSongPacks.SelectedIndex < 0)
                return;

            SongPack selectedSongPack = songPacks[listSongPacks.SelectedIndex];
            if (Directory.Exists(selectedSongPack.Path))
            {
                foreach (var file in Directory.GetFiles(selectedSongPack.Path))
                    File.Delete(file);

                Directory.Delete(selectedSongPack.Path);
            }
            else
                MessageBox.Show("This song pack doesn't exist!");

            ReLoadSongPacks();
            grpMaps.Visible = false;
        }

        private void btnDeleteMap_Click(object sender, EventArgs e)
        {
            try
            {
                SongPack selectedSongPack = songPacks[listSongPacks.SelectedIndex];
                string file = selectedSongPack.MapFiles[listMap.SelectedIndex].Path;
                if (File.Exists(file))
                    File.Delete(file);
                else
                    MessageBox.Show("This map doesn't exist!");

                selectedSongPack.ReLoadMapFiles(listMap);
            }
            catch { }
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (listMap.SelectedIndex < 0)
                return;

            double newBPM = 0;
            try
            {
                newBPM = Convert.ToDouble(txtNewBpm.Text);
            }
            catch
            {
                MessageBox.Show("I can only understand digits...");
                return;
            }
            double? noteJumpSpeed = null;

            var mergedEvents = new List<Event>();
            var mergedNotes = new List<Note>();
            var mergedObstacles = new List<Obstacle>();

            SongPack currentSongPack = songPacks[listSongPacks.SelectedIndex];
            currentSongPack.ReLoadMapFiles(listMap);

            foreach (var mapFile in currentSongPack.MapFiles)
            {
                string jsonData = File.ReadAllText(mapFile.Path);
                Map currentMap = JsonConvert.DeserializeObject<Map>(jsonData);

                if (!noteJumpSpeed.HasValue)
                    noteJumpSpeed = currentMap._noteJumpSpeed;

                ItemBase.ConvertItemBeatsToSeconds(currentMap._events, mergedEvents, currentMap._beatsPerMinute);
                ItemBase.ConvertItemBeatsToSeconds(currentMap._notes, mergedNotes, currentMap._beatsPerMinute);
                ItemBase.ConvertItemBeatsToSeconds(currentMap._obstacles, mergedObstacles, currentMap._beatsPerMinute);
            }

            ItemBase.ConvertItemSecondsToBeats(mergedEvents, newBPM);
            ItemBase.ConvertItemSecondsToBeats(mergedNotes, newBPM);
            ItemBase.ConvertItemSecondsToBeats(mergedObstacles, newBPM);

            var mergedMap = new Map(newBPM, noteJumpSpeed.Value, mergedEvents.ToArray(), mergedNotes.ToArray(), mergedObstacles.ToArray());

            try
            {
                string path = currentSongPack.Path + "/Merged.json";
                using (StreamWriter wr = new StreamWriter(path))
                    wr.WriteLine(JsonConvert.SerializeObject(mergedMap));

                MessageBox.Show("A new .json file has been created at: \"" + path + "\"");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Methods

        private string GetMapNameFromFile(string fileName)
        {
            string[] folders = fileName.Split('\\');
            return folders[folders.Length - 2] + " - " + folders.Last().Replace(".json", "");
        }

        private void ReLoadSongPacks()
        {
            listMap.Items.Clear();
            listSongPacks.Items.Clear();
            songPacks.Clear();

            foreach (var directory in Directory.GetDirectories(songPackFolder))
            {
                SongPack songPack = new SongPack(directory, false);
                songPacks.Add(songPack);

                listSongPacks.Items.Add(directory.Split('\\').Last());
            }
        }

        #endregion
    }

    public class SongPack
    {
        public List<MapFile> MapFiles { get; private set; }

        public string Path { get; private set; }

        public string DisplayName => Path.Split('\\').Last();

        public SongPack(string path, bool createDirectory)
        {
            Path = path;
            if (createDirectory)
                Directory.CreateDirectory(path);
        }

        public void ReLoadMapFiles(ListBox listMap)
        {
            listMap.Items.Clear();
            MapFiles = new List<MapFile>();
            foreach (var file in Directory.GetFiles(Path))
            {
                var mapFile = new MapFile(file, DisplayName, false);
                MapFiles.Add(mapFile);
                listMap.Items.Add(mapFile.FileName);
            }
        }
    }

    public class MapFile
    {
        public string Path { get; private set; }

        public string FileName => Folders.Last();

        public string DisplayName => MapName + " - " + DifficultyName;

        public string MapName => Folders[Folders.Length - 2];

        public string DifficultyName => Folders.Last().Replace(".json", "");

        private string[] Folders => Path.Split('\\');

        public MapFile(string selectedFile, string selectedSongPackName, bool createFile)
        {
            this.Path = selectedFile;
            if (createFile)
                File.Copy(Path, Form1.songPackFolder + "/" + selectedSongPackName + "/" + DisplayName + ".json");
        }

        private string GetMapNameFromFile(string fileName)
        {
            string[] folders = fileName.Split('\\');
            return folders[folders.Length - 2] + " - " + folders.Last().Replace(".json", "");
        }
    }
}
