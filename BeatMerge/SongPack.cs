using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

using BeatMerge.Difficulty;
using BeatMerge.Info;
using BeatMerge.ItemBase;

namespace BeatMerge
{
    public sealed class SongPack
    {
        public List<CustomMap> CustomMaps { get; private set; }

        public readonly string path;
        public readonly string songPackOrderFile;

        public string DisplayName => path.Split('/').Last();

        public SongPack(string path, bool createDirectory)
        {

            this.path = path;
            songPackOrderFile = this.path + "\\songPackOrder.txt";

            if (createDirectory)
                Directory.CreateDirectory(path);
        }

        public async Task AddMap(string filename, string songPackName, bool createFile, ListBox listMap)
        {
            CustomMap customMap = null;

            await Task.Run(() => {
                customMap = new CustomMap(filename, songPackName, createFile);
            });

            listMap.Items.Add(customMap.displayName);
            CustomMaps.Add(customMap);

            if (createFile)
            {
                using (StreamWriter wr = new StreamWriter(songPackOrderFile, true))
                {
                    wr.WriteLine(customMap.directoryPath);
                }
            }
        }

        public void ReloadSongPackOrderFile()
        {
            List<string> news = new List<string>();
            string[] directories = Directory.GetDirectories(path);

            if (File.Exists(songPackOrderFile))
            {
                news.AddRange(File.ReadAllLines(songPackOrderFile));
            }
            else
            {
                File.Create(songPackOrderFile).Close();
            }

            foreach (var x in directories)
            {
                if (!news.Contains(x))
                {
                    news.Add(x);
                }
            }

            for (int i = 0; i < news.Count(); i++)
            {
                if (!directories.Contains(news[i]))
                {
                    news.RemoveAt(i);
                }
            }

            File.WriteAllLines(songPackOrderFile, news);
        }

        public async void ReloadMapsListInCurrentSongPack(ListBox listMap)
        {
            listMap.Items.Clear();
            CustomMaps = new List<CustomMap>();

            List<string> news = new List<string>();
            string[] directories = Directory.GetDirectories(path);


            if(File.Exists(songPackOrderFile))
            {
                news.AddRange(File.ReadAllLines(songPackOrderFile));
            }
            else
            {
                File.Create(songPackOrderFile).Close();
            }
            
            foreach (var x in directories)
            {
                if(!news.Contains(x))
                {
                    news.Add(x);
                }
            }

            for(int i = 0; i < news.Count(); i++)
            {
                if(!directories.Contains(news[i]))
                {
                    news.RemoveAt(i);
                }
            }

            File.WriteAllLines(songPackOrderFile, news);

            foreach (var directory in news)
            {
                string[] files = Directory.GetFiles(directory, "*.dat");
                string file = files.Where(x => x.Split('/').Last() != "info.dat").First();

                // The files are already created so just add it to the listbox
                await AddMap(file, DisplayName, false, listMap);
            }
        }
    }
}
