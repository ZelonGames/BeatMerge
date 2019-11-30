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
        private SongPackManager songPackManager;
        private MapsManager mapsManager;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InstallSongPackManager();
            InstallMapsManager();
        }

        #region Methods

        private void InstallSongPackManager()
        {
            songPackManager = new SongPackManager(this);
            songPackManager.ReLoadSongPacks();

            btnAddSongPack.Click += songPackManager.OnAddSongPackClicked;
            btnDeleteSongPack.Click += songPackManager.OnDeleteSongPackClicked;
            listSongPacks.SelectedIndexChanged += songPackManager.OnListSongPackSelectedIndexChanged;
        }

        private void InstallMapsManager()
        {
            mapsManager = new MapsManager(this, songPackManager);
            btnAdd.Click += mapsManager.OnAddMapClicked;
            btnDeleteMap.Click += mapsManager.OnDeleteMapClicked;
            btnMerge.Click += mapsManager.OnMergeButtonClicked;
        }

        #endregion
    }
}
