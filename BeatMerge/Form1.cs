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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ScreenHelper.AddScreens(this);
            ScreenHelper.ChangeScreen(this, ScreenHelper.screenMergeSong);
        }

        private string GetFileName(string folder, string difficulty)
        {
            return folder + "\\" + difficulty + ".json";
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            string jsonBeginningFile = GetFileName(txtJsonBegin.Text, cmbDifficulty.Text);
            string jsonEndFile = GetFileName(txtJsonEnd.Text, cmbDifficulty.Text);

            Map beginMap = JsonHelper.LoadMap(jsonBeginningFile);
            Map endMap = JsonHelper.LoadMap(jsonEndFile);

            if (beginMap != null && endMap != null)
                Map.CreateMergedMapFile(this, beginMap, endMap);
        }

        private void mergeSongsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenHelper.ChangeScreen(this, ScreenHelper.screenMergeSong);
        }

        private void changeBPMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenHelper.ChangeScreen(this, ScreenHelper.screenChangeBPM);
        }

        private void txtJsonBegin_MouseClick(object sender, MouseEventArgs e)
        {
            BrowseHelper.BrowseDialog(sender);
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

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            var currentTextBox = (TextBox)sender;
            currentTextBox.Text = "";
        }

        private void btnChangeBPM_click(object sender, EventArgs e)
        {
            Map map = JsonHelper.LoadMap(txtJsonFile.Text);
            if (map == null)
                return;

            try
            {
                double newBPM = Convert.ToDouble(txtNewBPM.Text);

                var startOffset = map._notes.First()._time;
                var newStartOffset =  startOffset * (newBPM / map._beatsPerMinute) - startOffset;

                map.StretchToNewBPM(newBPM);
                map._beatsPerMinute = newBPM;
                Map.MoveItems(map, newStartOffset);
                
                string filename = BrowseHelper.BrowseDialog() + "\\" + txtJsonFile.Text.Split('\\').Last();
                Map.CreateMap(filename, map);
                MessageBox.Show("BPM was changed successfully!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
