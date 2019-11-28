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

        public void AddMap(string filename, string songPackName, bool createFile, ListBox listMap, ListBox lstTimeStamps)
        {
            var mapFile = new CustomMap(filename, songPackName, createFile);
            listMap.Items.Add(mapFile.displayName);
            CustomMaps.Add(mapFile);

            string jsonData = File.ReadAllText(mapFile.difficultyPath);
            Items.Map currentMap = JsonConvert.DeserializeObject<Items.Map>(jsonData);
            Items.Map.GetBeatLengthInSeconds(currentMap._beatsPerMinute);
            lstTimeStamps.Items.Add((Items.Map.BPMToMS(currentMap._beatsPerMinute) * currentMap.GetFirstItemTimestamp()) + " ms");
        }

        public void ReloadMapsListInCurrentSongPack(ListBox listMap, ListBox lstTimeStamps)
        {
            listMap.Items.Clear();
            lstTimeStamps.Items.Clear();
            CustomMaps = new List<CustomMap>();
            foreach (var directory in Directory.GetDirectories(path))
            {
                string[] files = Directory.GetFiles(directory, "*.dat");
                string file = files.Where(x => x != "info.dat").First();

                // The files are already created so just add it to the listbox
                AddMap(file, DisplayName, false, listMap, lstTimeStamps);
            }
        }
    }
}
