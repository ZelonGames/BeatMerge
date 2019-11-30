using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatMerge
{
    public class MapListManager
    {
        public readonly Form1 form;

        public MapListManager(Form1 form)
        {
            this.form = form;
        }

        public void AddMap(SongPack songPack)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select a difficulty .dat file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (openFileDialog.FileName == "info.dat")
                        MessageBox.Show("You must select a difficulty .dat file!");
                    else if (openFileDialog.FileName.EndsWith(".dat"))
                        songPack.AddMap(openFileDialog.FileName, songPack.DisplayName, true, form.listMap);
                    else
                        MessageBox.Show("You must select a .dat file!");
                }
            }
        }

        public void DeleteMap(SongPack songPack)
        {
            try
            {
                songPack.CustomMaps[form.listMap.SelectedIndex].audio.Close();

                string directory = songPack.CustomMaps[form.listMap.SelectedIndex].directoryPath;
                if (Directory.Exists(directory))
                    Directory.Delete(directory, true);
                else
                    MessageBox.Show("This map doesn't exist!");

                songPack.ReloadMapsListInCurrentSongPack(form.listMap);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
