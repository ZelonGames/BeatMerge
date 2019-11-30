using Newtonsoft.Json;

namespace BeatMerge.Items
{
    public class SongInfo
    {
        public SongInfo(DifficultyBeatmapSet[] difficultyBeatmapSets, CustomInfoData customData, string version, string songName, string songSubName, string songAuthorName, string levelAuthorName, string songFilename, string coverImageFilename, string environmentName, double beatsPerMinute, double songTimeOffset, double shuffle, double shufflePeriod, double previewStartTime, double previewDuration)
        {
            _difficultyBeatmapSets = difficultyBeatmapSets;
            _customData = customData;
            _version = version;
            _songName = songName;
            _songSubName = songSubName;
            _songAuthorName = songAuthorName;
            _levelAuthorName = levelAuthorName;
            _songFilename = songFilename;
            _coverImageFilename = coverImageFilename;
            _environmentName = environmentName;
            _beatsPerMinute = beatsPerMinute;
            _songTimeOffset = songTimeOffset;
            _shuffle = shuffle;
            _shufflePeriod = shufflePeriod;
            _previewStartTime = previewStartTime;
            _previewDuration = previewDuration;
        }

        public DifficultyBeatmapSet[] _difficultyBeatmapSets { get; set; }
        public CustomInfoData _customData { get; set; }

        public string _version { get; set; }
        public  string _songName { get; set; }
        public string _songSubName { get; set; }
        public string _songAuthorName { get; set; }
        public string _levelAuthorName { get; set; }
        public string _songFilename { get; set; }
        public string _coverImageFilename { get; set; }
        public string _environmentName { get; set; }

        public double _beatsPerMinute { get; set; }
        public double _songTimeOffset { get; set; }
        public double _shuffle { get; set; }
        public double _shufflePeriod { get; set; }
        public double _previewStartTime { get; set; }
        public double _previewDuration { get; set; }
    }

    public class DifficultyBeatmapSet
    {
        public DifficultyBeatmapSet(DifficultyBeatmap[] difficultyBeatmaps, string beatmapCharacteristicName)
        {
            _difficultyBeatmaps = difficultyBeatmaps;
            _beatmapCharacteristicName = beatmapCharacteristicName;
        }

        public DifficultyBeatmap[] _difficultyBeatmaps { get; set; }
        public string _beatmapCharacteristicName { get; set; }
    }

    public class DifficultyBeatmap
    {
        public DifficultyBeatmap(string difficulty, string beatmapFilename, double difficultyRank, double noteJumpMovementSpeed, double noteJumpStartBeatOffset, CustomDifficultyData customData)
        {
            _difficulty = difficulty;
            _beatmapFilename = beatmapFilename;
            _difficultyRank = difficultyRank;
            _noteJumpMovementSpeed = noteJumpMovementSpeed;
            _noteJumpStartBeatOffset = noteJumpStartBeatOffset;
            _customData = customData;
        }

        public string _difficulty { get; set; }
        public string _beatmapFilename { get; set; }
        public double _difficultyRank { get; set; }
        public double _noteJumpMovementSpeed { get; set; }
        public double _noteJumpStartBeatOffset { get; set; }

        public CustomDifficultyData _customData { get; set; }
    }

    public class CustomInfoData
    {
        public CustomInfoData(string customEnvironment, string customEnvironmentHash)
        {
            _customEnvironment = customEnvironment;
            _customEnvironmentHash = customEnvironmentHash;
        }

        public string _customEnvironment { get; set; }
        public string _customEnvironmentHash { get; set; }
    }

    public class CustomDifficultyData
    {
        public CustomDifficultyData(string difficultyLabel, double editorOffset, double editorOldOffset)
        {
            _difficultyLabel = difficultyLabel;
            _editorOffset = editorOffset;
            _editorOldOffset = editorOldOffset;
        }

        public string _difficultyLabel { get; set; }
        public double _editorOffset { get; set; }
        public double _editorOldOffset { get; set; }
    }
}
