using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json;

using BeatMerge.Difficulty;
using BeatMerge.Info;
using BeatMerge.ItemBase;

namespace BeatMerge
{
    public partial class Form1 : Form
    {
        #region Fields

        private SongPackManager songPackManager;
        private MapListManager mapListManager;

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region Events

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            songPackManager = new SongPackManager(this);
            songPackManager.ReLoadSongPacks();

            mapListManager = new MapListManager(this);
        }

        #region SongPackManager

        private void btnAddSongPack_Click(object sender, EventArgs e)
        {
            songPackManager.AddSongPack();
        }

        private void btnDeleteSongPack_Click(object sender, EventArgs e)
        {
            songPackManager.DeleteSongPack(songPackManager.GetCurrentSongPack());
        }

        private void listSongPacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            songPackManager.LoadNewSongPack(songPackManager.GetCurrentSongPack());
        }

        #endregion

        #region MapListManager

        private void btnDeleteMap_Click(object sender, EventArgs e)
        {
            mapListManager.DeleteMap(songPackManager.GetCurrentSongPack());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            mapListManager.AddMap(songPackManager.GetCurrentSongPack());
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            SongPack currentSongPack = songPackManager.GetCurrentSongPack();
            Task.Run(() => MapsMergerHelper.MergeMaps(this, currentSongPack));
        }

        #endregion

        #endregion
    }
}
