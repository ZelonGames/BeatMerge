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
            double newBPM;
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
                    double distanceToMove = currentMapLengthInBeats.Value;
                    ItemBase.ItemBase.MoveItems(customMap.map._notes, distanceToMove);
                    if (!ignoringEvents)
                        ItemBase.ItemBase.MoveItems(customMap.map._events, distanceToMove);
                    if (!ignoringObstacles)
                        ItemBase.ItemBase.MoveItems(customMap.map._obstacles, distanceToMove);
                }

                if (!currentMapLengthInBeats.HasValue)
                    currentMapLengthInBeats = 0;
                currentMapLengthInBeats += customMap.SongLengthInMilliSeconds / Rootobject.GetBeatLengthInMS(newBPM);
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

            var customInfo = new Info.Rootobject()
            {
                _version = currentSongPack.CustomMaps.First().info._version,
                _songName = "Merged",
                _songSubName = "",
                _songAuthorName = "Various Artists",
                _levelAuthorName = "BeatMerge",
                _beatsPerMinute = newBPM,
                _shuffle = currentSongPack.CustomMaps.First().info._shuffle,
                _shufflePeriod = currentSongPack.CustomMaps.First().info._shufflePeriod,
                _previewStartTime = 10,
                _previewDuration = 12,
                _songFilename = "song.ogg",
                _coverImageFilename = "cover.jpg",
                _environmentName = currentSongPack.CustomMaps.First().info._environmentName,
                _songTimeOffset = 0,
                _customData = currentSongPack.CustomMaps.First().info._customData,
            };

            var customData = new Info._Customdata1()
            {
                _difficultyLabel = "Pack",
                _editorOffset = currentSongPack.CustomMaps.First().info._difficultyBeatmapSets.First()._difficultyBeatmaps.First()._customData._editorOffset,
                _editorOldOffset = currentSongPack.CustomMaps.First().info._difficultyBeatmapSets.First()._difficultyBeatmaps.First()._customData._editorOldOffset,
                _information = currentSongPack.CustomMaps.First().info._difficultyBeatmapSets.First()._difficultyBeatmaps.First()._customData._information,
                _requirements = currentSongPack.CustomMaps.First().info._difficultyBeatmapSets.First()._difficultyBeatmaps.First()._customData._requirements,
                _suggestions = currentSongPack.CustomMaps.First().info._difficultyBeatmapSets.First()._difficultyBeatmaps.First()._customData._suggestions,
                _warnings = currentSongPack.CustomMaps.First().info._difficultyBeatmapSets.First()._difficultyBeatmaps.First()._customData._warnings
            };

            Info._Difficultybeatmaps[] customDifficultybeatmaps = new Info._Difficultybeatmaps[1];
            Info._Difficultybeatmaps temp = new Info._Difficultybeatmaps
            {
                _difficulty = "ExpertPlus",
                _difficultyRank = 9,
                _beatmapFilename = "ExpertPlusStandard.dat",
                _noteJumpMovementSpeed = currentSongPack.CustomMaps.First().info._difficultyBeatmapSets.First()._difficultyBeatmaps.First()._noteJumpMovementSpeed,
                _noteJumpStartBeatOffset = currentSongPack.CustomMaps.First().info._difficultyBeatmapSets.First()._difficultyBeatmaps.First()._noteJumpStartBeatOffset,
                _customData = customData
            };
            customDifficultybeatmaps[0] = temp;

            Info._Difficultybeatmapsets[] customdifficultyBeatmapSets = new Info._Difficultybeatmapsets[1];
            Info._Difficultybeatmapsets tempo = new Info._Difficultybeatmapsets();
            tempo._beatmapCharacteristicName = "Standard";
            tempo._difficultyBeatmaps = customDifficultybeatmaps;

            customdifficultyBeatmapSets[0] = tempo;

            customInfo._difficultyBeatmapSets = customdifficultyBeatmapSets;

            Info.Rootobject firstSongInfo = customInfo;

            try
            {
                string mergedDirectory = "Merged Map";
                if (Directory.Exists(mergedDirectory))
                    Directory.Delete(mergedDirectory, true);

                Directory.CreateDirectory(mergedDirectory);

                for (int i = 0; i < currentSongPack.CustomMaps.Count; i++)
                {
                    CustomMap custmMap = currentSongPack.CustomMaps[i];
                    File.Copy(custmMap.audioPath, mergedDirectory + "/" + i + Path.GetExtension(custmMap.audioPath));
                }

                string difficulty = mergedDirectory + "/" + "ExpertPlusStandard.dat";
                using (StreamWriter wr = new StreamWriter(difficulty))
                    wr.WriteLine(JsonConvert.SerializeObject(mergedMap));

                string info = mergedDirectory + "/info.dat";
                using (StreamWriter wr = new StreamWriter(info))
                    wr.WriteLine(JsonConvert.SerializeObject(firstSongInfo));

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = "/C cd " + AppDomain.CurrentDomain.BaseDirectory + mergedDirectory + "\\"
                };
                startInfo.Arguments += " & copy /b";
                for (int i = 0; i < currentSongPack.CustomMaps.Count; i++)
                {
                    CustomMap custmMap = currentSongPack.CustomMaps[i];
                    if (i == 0)
                    {
                        startInfo.Arguments += " " + i + Path.GetExtension(custmMap.audioPath);
                    }
                    else
                    {
                        startInfo.Arguments += " +" + i + Path.GetExtension(custmMap.audioPath);
                    }
                }
                startInfo.Arguments += " song.ogg";
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();

                for (int i = 0; i < currentSongPack.CustomMaps.Count; i++)
                {
                    CustomMap custmMap = currentSongPack.CustomMaps[i];
                    File.Delete(mergedDirectory + "/" + i + Path.GetExtension(custmMap.audioPath));
                }

                MessageBox.Show("A new folder called " + mergedDirectory + " has been created");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
