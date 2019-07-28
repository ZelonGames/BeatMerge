using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
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
        private string SelectedTimeStamp => lstTimeStamps.Items[lstTimeStamps.SelectedIndex].ToString().Split(' ')[0];

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
                {
                    songPacks[listSongPacks.SelectedIndex].AddMap(openFileDialog.FileName, SelectedSongPackName, true, listMap, lstTimeStamps);
                }
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
            if (listSongPacks.SelectedIndex < 0)
                return;

            grpMaps.Visible = true;

            SongPack selectedSongPack = songPacks[listSongPacks.SelectedIndex];
            selectedSongPack.ReLoadMapFiles(listMap, lstTimeStamps);
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

        private void lstTimeStamps_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            string input = Interaction.InputBox("Type in the time where this song should start in milliseconds", "Timestamp", SelectedTimeStamp);
            if (input.Length > 0)
            {
                try
                {
                    double timestamp = Convert.ToDouble(input);
                    lstTimeStamps.Items[lstTimeStamps.SelectedIndex] = timestamp + " ms";
                    songPacks[listSongPacks.SelectedIndex].MapFiles[lstTimeStamps.SelectedIndex].StartTimeInMS = timestamp;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

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

                selectedSongPack.ReLoadMapFiles(listMap, lstTimeStamps);
            }
            catch { }
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
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
            //currentSongPack.ReLoadMapFiles(listMap, lstTimeStamps);

            foreach (var mapFile in currentSongPack.MapFiles)
            {
                string jsonData = File.ReadAllText(mapFile.Path);
                Map currentMap = JsonConvert.DeserializeObject<Map>(jsonData);

                if (!noteJumpSpeed.HasValue)
                    noteJumpSpeed = currentMap._noteJumpSpeed;

                if (checkBox1.Checked && mapFile.StartTimeInMS.HasValue)
                {
                    double jumpDistance = Map.MSToBeats(currentMap._beatsPerMinute, mapFile.StartTimeInMS.Value) - currentMap.GetFirstItemTimestamp();

                    ItemBase.MoveItems(currentMap._notes, currentMap._beatsPerMinute, jumpDistance);
                    ItemBase.MoveItems(currentMap._events, currentMap._beatsPerMinute, jumpDistance);
                    ItemBase.MoveItems(currentMap._obstacles, currentMap._beatsPerMinute, jumpDistance);
                }

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
                string path = "Merged.json";
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            lstTimeStamps.Visible = checkBox1.Checked;
        }
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

        public void AddMap(string filename, string songPackName, bool createFile, ListBox listMap, ListBox lstTimeStamps)
        {
            var mapFile = new MapFile(filename, songPackName, createFile);
            listMap.Items.Add(mapFile.DisplayName);
            MapFiles.Add(mapFile);

            string jsonData = File.ReadAllText(mapFile.Path);
            Map currentMap = JsonConvert.DeserializeObject<Map>(jsonData);
            Map.GetBeatLengthInSeconds(currentMap._beatsPerMinute);
            lstTimeStamps.Items.Add((Map.BPMToMS(currentMap._beatsPerMinute) * currentMap.GetFirstItemTimestamp()) + " ms");
        }

        public void ReLoadMapFiles(ListBox listMap, ListBox lstTimeStamps)
        {
            listMap.Items.Clear();
            lstTimeStamps.Items.Clear();
            MapFiles = new List<MapFile>();
            foreach (var file in Directory.GetFiles(Path))
            {
                AddMap(file, DisplayName, false, listMap, lstTimeStamps);
            }
        }
    }

    public class MapFile
    {
        public string Path { get; private set; }

        public double? StartTimeInMS = null;

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
