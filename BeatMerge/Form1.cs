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
            //AudioHelper.Combine2(new string[] { "b.egg", "a.egg"});

            ReLoadSongPacks();
        }

        #region Events

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a difficulty .dat file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.FileName == "info.dat")
                        MessageBox.Show("You must select a difficulty .dat file!");
                    else if (openFileDialog.FileName.EndsWith(".dat"))
                        songPacks[listSongPacks.SelectedIndex].AddMap(openFileDialog.FileName, SelectedSongPackName, true, listMap);
                    else
                        MessageBox.Show("You must select a .dat file!");
                }
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
            selectedSongPack.ReloadMapsListInCurrentSongPack(listMap);
        }

        private void btnDeleteSongPack_Click(object sender, EventArgs e)
        {
            if (listSongPacks.SelectedIndex < 0)
                return;

            SongPack selectedSongPack = songPacks[listSongPacks.SelectedIndex];
            if (Directory.Exists(selectedSongPack.path))
            {
                foreach (var file in Directory.GetFiles(selectedSongPack.path))
                    File.Delete(file);

                Directory.Delete(selectedSongPack.path);
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

                selectedSongPack.CustomMaps[listMap.SelectedIndex].audio.Close();

                string directory = selectedSongPack.CustomMaps[listMap.SelectedIndex].directoryPath;
                if (Directory.Exists(directory))
                    Directory.Delete(directory, true);
                else
                    MessageBox.Show("This map doesn't exist!");

                selectedSongPack.ReloadMapsListInCurrentSongPack(listMap);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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

            var mergedEvents = new List<Event>();
            var mergedNotes = new List<Note>();
            var mergedObstacles = new List<Obstacle>();

            bool ignoringEvents = checkIgnoreEvents.Checked;
            bool ignoringObstacles = checkIgnoreObstacles.Checked;

            SongPack currentSongPack = songPacks[listSongPacks.SelectedIndex];

            // Move the notes to a way that changes the bpm of the map
            foreach (var customMap in currentSongPack.CustomMaps)
            {
                ItemBase.ConvertItemBeatsToSeconds(customMap.map._notes, mergedNotes, customMap.info._beatsPerMinute);
                if (!ignoringEvents)
                    ItemBase.ConvertItemBeatsToSeconds(customMap.map._events, mergedEvents, customMap.info._beatsPerMinute);
                if (!ignoringObstacles)
                    ItemBase.ConvertItemBeatsToSeconds(customMap.map._obstacles, mergedObstacles, customMap.info._beatsPerMinute);
            }

            ItemBase.ConvertItemSecondsToBeats(mergedNotes, newBPM);
            if (!ignoringEvents)
                ItemBase.ConvertItemSecondsToBeats(mergedEvents, newBPM);
            if (!ignoringObstacles)
                ItemBase.ConvertItemSecondsToBeats(mergedObstacles, newBPM);
            //////////////////////////////////////////////////////////////////////////

            // Move the notes behind the current map
            double? currentMapLengthInBeats = null;
            foreach (var customMap in currentSongPack.CustomMaps)
            {
                if (currentMapLengthInBeats.HasValue)
                {
                    double startOffsetInBeats = Map.MSToBeats(customMap.info._beatsPerMinute, customMap.info._difficultyBeatmapSets.First()._difficultyBeatmaps.First()._customData._editorOffset);
                    double distanceToMove = currentMapLengthInBeats.Value - startOffsetInBeats;
                    ItemBase.MoveItems(customMap.map._notes, distanceToMove);
                    if (!ignoringEvents)
                        ItemBase.MoveItems(customMap.map._events, distanceToMove);
                    if (!ignoringObstacles)
                        ItemBase.MoveItems(customMap.map._obstacles, distanceToMove);
                }

                if (!currentMapLengthInBeats.HasValue)
                    currentMapLengthInBeats = 0;
                currentMapLengthInBeats += customMap.audio.TotalTime.TotalMilliseconds / Map.GetBeatLengthInMS(newBPM);
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            var mergedMap = new Map(newBPM, mergedEvents.ToArray(), mergedNotes.ToArray(), mergedObstacles.ToArray());
            SongInfo firstSongInfo = currentSongPack.CustomMaps.First().info;
            firstSongInfo._beatsPerMinute = newBPM;
            firstSongInfo._songFilename = "song.ogg";

            try
            {
                string mergedDirectory = "Merged Map";
                if (Directory.Exists(mergedDirectory))
                    Directory.Delete(mergedDirectory, true);

                Directory.CreateDirectory(mergedDirectory);

                string difficulty = mergedDirectory + "/" + firstSongInfo._difficultyBeatmapSets.First()._difficultyBeatmaps.First()._beatmapFilename;
                using (StreamWriter wr = new StreamWriter(difficulty))
                    wr.WriteLine(JsonConvert.SerializeObject(mergedMap));

                string info = mergedDirectory + "/info.dat";
                using (StreamWriter wr = new StreamWriter(info))
                    wr.WriteLine(JsonConvert.SerializeObject(firstSongInfo));

                MessageBox.Show("A new folder called " + mergedDirectory + " has been created");
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
            return folders[folders.Length - 2] + " - " + folders.Last().Replace(".dat", "");
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
}
