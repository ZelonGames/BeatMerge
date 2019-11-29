using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

using BeatMerge.Items;

namespace BeatMerge
{
    public class SongPack
    {
        public List<CustomMap> CustomMaps { get; private set; }

        public readonly string path;

        public string DisplayName => path.Split('\\').Last();

        public SongPack(string path, bool createDirectory)
        {
            this.path = path;
            if (createDirectory)
                Directory.CreateDirectory(path);
        }

        public void AddMap(string filename, string songPackName, bool createFile, ListBox listMap)
        {
            var mapFile = new CustomMap(filename, songPackName, createFile);
            listMap.Items.Add(mapFile.displayName);
            CustomMaps.Add(mapFile);

            string jsonData = File.ReadAllText(mapFile.difficultyPath);
            Map currentMap = JsonConvert.DeserializeObject<Map>(jsonData);
            Map.GetBeatLengthInSeconds(currentMap._beatsPerMinute);
        }

        public void ReloadMapsListInCurrentSongPack(ListBox listMap)
        {
            listMap.Items.Clear();
            CustomMaps = new List<CustomMap>();
            foreach (var directory in Directory.GetDirectories(path))
            {
                string[] files = Directory.GetFiles(directory, "*.dat");
                string file = files.Where(x => x != "info.dat").First();

                // The files are already created so just add it to the listbox
                AddMap(file, DisplayName, false, listMap);
            }
        }
    }
}
