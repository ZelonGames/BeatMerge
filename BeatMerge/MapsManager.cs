using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatMerge
{
    public class MapsManager
    {
        public readonly Form1 form;
        public readonly SongPackManager songPackManager;

        private string SelectedSongPackName => form.listSongPacks.Items[form.listSongPacks.SelectedIndex].ToString();

        public MapsManager(Form1 form, SongPackManager songPackManager)
        {
            this.form = form;
            this.songPackManager = songPackManager;
        }

        public void OnAddMapClicked(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a difficulty .dat file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.FileName == "info.dat")
                        MessageBox.Show("You must select a difficulty .dat file!");
                    else if (openFileDialog.FileName.EndsWith(".dat"))
                        songPackManager.songPacks[form.listSongPacks.SelectedIndex].AddMap(openFileDialog.FileName, SelectedSongPackName, true, form.listMap);
                    else
                        MessageBox.Show("You must select a .dat file!");
                }
            }
        }

        public void OnDeleteMapClicked(object sender, EventArgs e)
        {
            try
            {
                SongPack selectedSongPack = songPackManager.songPacks[form.listSongPacks.SelectedIndex];

                selectedSongPack.CustomMaps[form.listMap.SelectedIndex].audio.Close();

                string directory = selectedSongPack.CustomMaps[form.listMap.SelectedIndex].directoryPath;
                if (Directory.Exists(directory))
                    Directory.Delete(directory, true);
                else
                    MessageBox.Show("This map doesn't exist!");

                selectedSongPack.ReloadMapsListInCurrentSongPack(form.listMap);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void OnMergeButtonClicked(object sender, EventArgs e)
        {
            MapsMergerHelper.MergeMaps(form, songPackManager.GetCurrentSongPack());
        }
    }
}
