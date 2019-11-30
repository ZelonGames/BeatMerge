using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using BeatMerge.Items;

namespace BeatMerge
{
    public static class MapsMergerHelper
    {
        public static void MergeMaps(Form1 form, SongPack currentSongPack)
        {
            double newBPM = 0;
            try
            {
                newBPM = Convert.ToDouble(form.txtNewBpm.Text);
            }
            catch
            {
                MessageBox.Show("I can only understand digits...");
                return;
            }

            var mergedEvents = new List<Event>();
            var mergedNotes = new List<Note>();
            var mergedObstacles = new List<Obstacle>();

            bool ignoringEvents = form.checkIgnoreEvents.Checked;
            bool ignoringObstacles = form.checkIgnoreObstacles.Checked;

            // Move the notes to a way that changes the bpm of the map
            foreach (var customMap in currentSongPack.CustomMaps)
            {
                ItemBase.ConvertItemBeatsToSeconds(customMap.map._notes, mergedNotes, customMap.info._beatsPerMinute);
                if (!ignoringEvents)
                    ItemBase.ConvertItemBeatsToSeconds(customMap.map._events, mergedEvents, customMap.info._beatsPerMinute);
                if (!ignoringObstacles)
                    ItemBase.ConvertItemBeatsToSeconds(customMap.map._obstacles, mergedObstacles, customMap.info._beatsPerMinute);
            }

            ItemBase.ConvertItemSecondsToBeats(mergedNotes, newBPM);
            if (!ignoringEvents)
                ItemBase.ConvertItemSecondsToBeats(mergedEvents, newBPM);
            if (!ignoringObstacles)
                ItemBase.ConvertItemSecondsToBeats(mergedObstacles, newBPM);
            //////////////////////////////////////////////////////////////////////////

            // Move the notes behind the current map
            double? currentMapLengthInBeats = null;
            foreach (var customMap in currentSongPack.CustomMaps)
            {
                if (currentMapLengthInBeats.HasValue)
                {
                    double startOffsetInBeats = Map.MSToBeats(customMap.info._beatsPerMinute, customMap.info._difficultyBeatmapSets.First()._difficultyBeatmaps.First()._customData._editorOffset);
                    double distanceToMove = currentMapLengthInBeats.Value - startOffsetInBeats;
                    ItemBase.MoveItems(customMap.map._notes, distanceToMove);
                    if (!ignoringEvents)
                        ItemBase.MoveItems(customMap.map._events, distanceToMove);
                    if (!ignoringObstacles)
                        ItemBase.MoveItems(customMap.map._obstacles, distanceToMove);
                }

                if (!currentMapLengthInBeats.HasValue)
                    currentMapLengthInBeats = 0;
                currentMapLengthInBeats += customMap.audio.TotalTime.TotalMilliseconds / Map.GetBeatLengthInMS(newBPM);
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////

            var mergedMap = new Map(newBPM, mergedEvents.ToArray(), mergedNotes.ToArray(), mergedObstacles.ToArray());
            SongInfo firstSongInfo = currentSongPack.CustomMaps.First().info;
            firstSongInfo._beatsPerMinute = newBPM;
            firstSongInfo._songFilename = "song.ogg";

            try
            {
                string mergedDirectory = "Merged Map";
                if (Directory.Exists(mergedDirectory))
                    Directory.Delete(mergedDirectory, true);

                Directory.CreateDirectory(mergedDirectory);

                string difficulty = mergedDirectory + "/" + firstSongInfo._difficultyBeatmapSets.First()._difficultyBeatmaps.First()._beatmapFilename;
                using (StreamWriter wr = new StreamWriter(difficulty))
                    wr.WriteLine(JsonConvert.SerializeObject(mergedMap));

                string info = mergedDirectory + "/info.dat";
                using (StreamWriter wr = new StreamWriter(info))
                    wr.WriteLine(JsonConvert.SerializeObject(firstSongInfo));

                MessageBox.Show("A new folder called " + mergedDirectory + " has been created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
