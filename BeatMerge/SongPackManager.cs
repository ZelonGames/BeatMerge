using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeatMerge
{
    public class SongPackManager
    {
        #region Fields

        public List<SongPack> songPacks = new List<SongPack>();
        public readonly Form1 form;

        public const string songPackFolder = "SongPacks";

        #endregion

        public SongPackManager(Form1 form)
        {
            this.form = form;
        }

        #region Events

        public void OnAddSongPackClicked(object sender, EventArgs e)
        {
            string songPackInputName = form.txtSongPackName.Text.Replace("\\", "").Replace(".", "").Replace("/", "");
            if (string.IsNullOrEmpty(songPackInputName))
                return;

            if (!Directory.Exists(songPackFolder))
                Directory.CreateDirectory(songPackFolder);

            string songPackName = songPackFolder + "/" + songPackInputName;
            songPacks.Add(new SongPack(songPackName, true));
            ReLoadSongPacks();
        }

        public void OnDeleteSongPackClicked(object sender, EventArgs e)
        {
            if (form.listSongPacks.SelectedIndex < 0)
                return;

            SongPack selectedSongPack = songPacks[form.listSongPacks.SelectedIndex];
            if (Directory.Exists(selectedSongPack.path))
            {
                foreach (var file in Directory.GetFiles(selectedSongPack.path))
                    File.Delete(file);

                Directory.Delete(selectedSongPack.path);
            }
            else
                MessageBox.Show("This song pack doesn't exist!");

            ReLoadSongPacks();
            form.grpMaps.Visible = false;
        }

        public void OnListSongPackSelectedIndexChanged(object sender, EventArgs e)
        {
            if (form.listSongPacks.SelectedIndex < 0)
                return;

            form.grpMaps.Visible = true;

            SongPack selectedSongPack = songPacks[form.listSongPacks.SelectedIndex];
            selectedSongPack.ReloadMapsListInCurrentSongPack(form.listMap);
        }

        #endregion

        #region Methods

        public void ReLoadSongPacks()
        {
            form.listMap.Items.Clear();
            form.listSongPacks.Items.Clear();
            songPacks.Clear();

            foreach (var directory in Directory.GetDirectories(songPackFolder))
            {
                SongPack songPack = new SongPack(directory, false);
                songPacks.Add(songPack);

                form.listSongPacks.Items.Add(directory.Split('\\').Last());
            }
        }

        #endregion
    }
}
