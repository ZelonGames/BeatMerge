using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeatMerge
{
    public sealed class SongPackManager
    {
        #region Fields

        public List<SongPack> songPacks = new List<SongPack>();
        public readonly Form1 form;

        public const string SONG_PACK_FOLDER = "SongPacks";

        #endregion

        public SongPackManager(Form1 form)
        {
            this.form = form;
        }

        #region Events

        public void AddSongPack()
        {
            string songPackInputName = form.txtSongPackName.Text.Replace("\\", "").Replace(".", "").Replace("/", "");
            if (string.IsNullOrEmpty(songPackInputName))
                return;

            if (!Directory.Exists(SONG_PACK_FOLDER))
                Directory.CreateDirectory(SONG_PACK_FOLDER);

            string songPackName = SONG_PACK_FOLDER + "/" + songPackInputName;
            songPacks.Add(new SongPack(songPackName, true));
            ReLoadSongPacks();
        }

        public void DeleteSongPack(SongPack songPack)
        {
            if (form.listSongPacks.SelectedIndex < 0)
                return;

            if (Directory.Exists(songPack.path))
            {
                foreach (var file in Directory.GetFiles(songPack.path))
                    File.Delete(file);

                Directory.Delete(songPack.path);
            }
            else
                MessageBox.Show("This song pack doesn't exist!");

            ReLoadSongPacks();
            form.grpMaps.Visible = false;
        }

        public void LoadNewSongPack(SongPack songPack)
        {
            if (form.listSongPacks.SelectedIndex < 0)
                return;

            form.grpMaps.Visible = true;

            songPack.ReloadMapsListInCurrentSongPack(form.listMap);
        }

        #endregion

        #region Methods

        public void ReLoadSongPacks()
        {
            form.listMap.Items.Clear();
            form.listSongPacks.Items.Clear();
            songPacks.Clear();

            if (!Directory.Exists(SONG_PACK_FOLDER))
                Directory.CreateDirectory(SONG_PACK_FOLDER);

            foreach (var directory in Directory.GetDirectories(SONG_PACK_FOLDER))
            {
                SongPack songPack = new SongPack(directory, false);
                songPacks.Add(songPack);

                form.listSongPacks.Items.Add(directory.Split('\\').Last());
            }
        }

        public SongPack GetCurrentSongPack()
        {
            if (form.listSongPacks.SelectedIndex < 0)
                form.listSongPacks.SelectedIndex = 0;

            return songPacks[form.listSongPacks.SelectedIndex];
        }

        #endregion
    }
}
