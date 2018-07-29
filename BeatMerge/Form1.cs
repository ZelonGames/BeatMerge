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
            string jsonBeginningFile = GetFileName(txtJsonBegin.Text, cmbDiffBegin.Text);
            string jsonEndFile = GetFileName(txtJsonEnd.Text, cmbDiffBegin.Text);

            Map beginMap = JsonHelper.LoadMap(jsonBeginningFile);
            Map endMap = JsonHelper.LoadMap(jsonEndFile);

            CreateMergedMapFile(beginMap, endMap);
        }

        private void CreateMergedMapFile(Map beginMap, Map endMap)
        {
            Map mergedMap = Map.GetMergedMap(beginMap, endMap);
            string json = JsonConvert.SerializeObject(mergedMap);

            string filename = txtOutput.Text + "\\" + cmbDiffBegin.Text + ".json";
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
