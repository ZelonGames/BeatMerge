using System;
using System.IO;
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

        private void btnMerge_Click(object sender, EventArgs e)
        {
            string jsonBeginningFile = GetFileName(txtJsonBegin.Text, cmbDifficulty.Text);
            string jsonEndFile = GetFileName(txtJsonEnd.Text, cmbDifficulty.Text);

            Map beginMap = JsonHelper.LoadMap(jsonBeginningFile);
            Map endMap = JsonHelper.LoadMap(jsonEndFile);

            if (beginMap != null && endMap != null)
            {
                try
                {
                    CreateMergedMapFile(beginMap, endMap);
                    MessageBox.Show("Successfully created " + cmbDifficulty.Text + ".json at " + txtOutput.Text + "!");
                }
                catch
                {
                    MessageBox.Show("Oops, something went wrong.");
                }
            }
        }

        private void CreateMergedMapFile(Map beginMap, Map endMap)
        {
            Map mergedMap = Map.GetMergedMap(beginMap, endMap);
            string json = JsonConvert.SerializeObject(mergedMap);

            string filename = txtOutput.Text + "\\" + cmbDifficulty.Text + ".json";
            using (StreamWriter wr = new StreamWriter(filename))
            {
                wr.WriteLine(json);
            }
        }

        private string GetFileName(string folder, string difficulty)
        {
            return folder + "\\" + difficulty + ".json";
        }
    }
}
