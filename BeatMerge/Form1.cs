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
        public static string BasePath { get; private set; }
        public static string Difficulty { get; private set; }

        private static readonly string settingsFile = "settings.txt";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();

            ScreenHelper.AddScreens(this);
            ScreenHelper.ChangeScreen(this, ScreenHelper.screenMergeSong);
        }

        private void LoadSettings()
        {
            if (!File.Exists(settingsFile))
            {
                BasePath = null;
                return;
            }

            using (StreamReader re = new StreamReader(settingsFile))
            {
                BasePath = re.ReadLine();
            }
        }

        private string GetFileName(string folder, string difficulty)
        {
            return folder + "\\" + difficulty + ".json";
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            Difficulty = cmbDifficulty.Text;

            string jsonBeginningFile = GetFileName(txtJsonBegin.Text, Difficulty);
            string jsonEndFile = GetFileName(txtJsonEnd.Text, Difficulty);

            Map beginMap = JsonHelper.LoadJson<Map>(jsonBeginningFile);
            if (beginMap == null)
                return;

            beginMap.SongInfo = JsonHelper.LoadJson<SongInfo>(txtJsonBegin.Text + "\\info.json");

            Map endMap = JsonHelper.LoadJson<Map>(jsonEndFile);
            if (endMap == null)
                return;

            endMap.SongInfo = JsonHelper.LoadJson<SongInfo>(txtJsonEnd.Text + "\\info.json");

            if (beginMap != null && endMap != null)
                Map.CreateMergedMapFile(beginMap, endMap);
        }

        private void mergeSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenHelper.ChangeScreen(this, ScreenHelper.screenMergeSong);
        }

        private void changeBPMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenHelper.ChangeScreen(this, ScreenHelper.screenChangeBPM);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenHelper.ChangeScreen(this, ScreenHelper.screenSettings);
        }

        private void txtJsonBegin_MouseClick(object sender, MouseEventArgs e)
        {
            BrowseHelper.BrowseDialog(sender);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtSettings.Text == "")
                return;

            using (StreamWriter wr = new StreamWriter(settingsFile, false))
            {
                wr.WriteLine(txtSettings.Text);
            }

            BasePath = txtSettings.Text;
            MessageBox.Show("Successfully changed base path to: " + BasePath);
        }

        private void txtJsonEnd_MouseClick(object sender, MouseEventArgs e)
        {
            BrowseHelper.BrowseDialog(sender);
        }

        private void txtOutput_MouseClick(object sender, MouseEventArgs e)
        {
            BrowseHelper.BrowseDialog(sender);
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            BrowseHelper.BrowseFile(sender);
        }

        private void txtSettings_MouseClick(object sender, MouseEventArgs e)
        {
            BrowseHelper.BrowseDialog(sender);
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            var currentTextBox = (TextBox)sender;
            currentTextBox.Text = "";
        }

        private void btnChangeBPM_click(object sender, EventArgs e)
        {
            Map map = JsonHelper.LoadJson<Map>(txtJsonFile.Text);
            if (map == null)
                return;

            try
            {
                float newBPM = Convert.ToSingle(txtNewBPM.Text);

                var startOffset = map._notes.First()._time;
                var newStartOffset = startOffset * (newBPM / map._beatsPerMinute) - startOffset;

                map.StretchToNewBPM(newBPM);
                map._beatsPerMinute = newBPM;
                Map.MoveItems(map, newStartOffset);

                string filename = BrowseHelper.BrowseDialog() + "\\" + txtJsonFile.Text.Split('\\').Last();
                Map.CreateMap(filename, map);
                MessageBox.Show("BPM was changed successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}
