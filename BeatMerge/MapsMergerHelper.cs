using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

using BeatMerge.Difficulty;


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

            var mergedEvents = new List<_Events>();
            var mergedNotes = new List<_Notes>();
            var mergedObstacles = new List<_Obstacles>();

            bool ignoringEvents = form.checkIgnoreEvents.Checked;
            bool ignoringObstacles = form.checkIgnoreObstacles.Checked;

            // Move the notes to a way that changes the bpm of the map
            foreach (var customMap in currentSongPack.CustomMaps)
            {
                ItemBase.ItemBase.ConvertItemBeatsToSeconds(customMap.map._notes, mergedNotes, customMap.info._beatsPerMinute);
                if (!ignoringEvents)
                    ItemBase.ItemBase.ConvertItemBeatsToSeconds(customMap.map._events, mergedEvents, customMap.info._beatsPerMinute);
                if (!ignoringObstacles)
                    ItemBase.ItemBase.ConvertItemBeatsToSeconds(customMap.map._obstacles, mergedObstacles, customMap.info._beatsPerMinute);
            }

            ItemBase.ItemBase.ConvertItemSecondsToBeats(mergedNotes, newBPM);
            if (!ignoringEvents)
                ItemBase.ItemBase.ConvertItemSecondsToBeats(mergedEvents, newBPM);
            if (!ignoringObstacles)
                ItemBase.ItemBase.ConvertItemSecondsToBeats(mergedObstacles, newBPM);
            //////////////////////////////////////////////////////////////////////////

            // Move the notes behind the current map
            double? currentMapLengthInBeats = null;
            foreach (var customMap in currentSongPack.CustomMaps)
            {
                if (currentMapLengthInBeats.HasValue)
                {
                    double startOffsetInBeats = Rootobject.MSToBeats(customMap.info._beatsPerMinute, customMap.info._difficultyBeatmapSets.First()._difficultyBeatmaps.First()._customData._editorOffset);
                    double distanceToMove = currentMapLengthInBeats.Value - startOffsetInBeats;
                    ItemBase.ItemBase.MoveItems(customMap.map._notes, distanceToMove);
                    if (!ignoringEvents)
                        ItemBase.ItemBase.MoveItems(customMap.map._events, distanceToMove);
                    if (!ignoringObstacles)
                        ItemBase.ItemBase.MoveItems(customMap.map._obstacles, distanceToMove);
                }

                if (!currentMapLengthInBeats.HasValue)
                    currentMapLengthInBeats = 0;
                currentMapLengthInBeats += customMap.audio.TotalTime.TotalMilliseconds / Rootobject.GetBeatLengthInMS(newBPM);
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            // TODO customData need to be implemented                                                            //
            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            var mergedMap = new Rootobject
            {
                _events = mergedEvents.ToArray(),
                _notes = mergedNotes.ToArray(),
                _obstacles = mergedObstacles.ToArray(),
                _version = currentSongPack.CustomMaps[0].map._version,
                _customData = null
            };

            Info.Rootobject firstSongInfo = currentSongPack.CustomMaps.First().info;
            firstSongInfo._beatsPerMinute = newBPM;
            firstSongInfo._songFilename = "song.ogg";

            try
            {
                string mergedDirectory = "Merged Map";
                if (Directory.Exists(mergedDirectory))
                    Directory.Delete(mergedDirectory, true);

                Directory.CreateDirectory(mergedDirectory);

                Directory.CreateDirectory(mergedDirectory + "/Audio Files");
                for (int i = 0; i < currentSongPack.CustomMaps.Count; i++)
                {
                    CustomMap custmMap = currentSongPack.CustomMaps[i];
                    File.Copy(custmMap.audioPath, mergedDirectory + "/Audio Files/" + i + Path.GetExtension(custmMap.audioPath));
                }

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
