

namespace BeatMerge.Info
{
    public class Rootobject
    {
        public string _version { get; set; }
        public string _songName { get; set; }
        public string _songSubName { get; set; }
        public string _songAuthorName { get; set; }
        public string _levelAuthorName { get; set; }
        public double _beatsPerMinute { get; set; }
        public double _shuffle { get; set; }
        public double _shufflePeriod { get; set; }
        public double _previewStartTime { get; set; }
        public double _previewDuration { get; set; }
        public string _songFilename { get; set; }
        public string _coverImageFilename { get; set; }
        public string _environmentName { get; set; }
        public double _songTimeOffset { get; set; }
        public _Customdata _customData { get; set; }
        public _Difficultybeatmapsets[] _difficultyBeatmapSets { get; set; }
    }

    public class _Customdata
    {
        public object[] _contributors { get; set; }
    }

    public class _Difficultybeatmapsets
    {
        public string _beatmapCharacteristicName { get; set; }
        public _Difficultybeatmaps[] _difficultyBeatmaps { get; set; }
    }

    public class _Difficultybeatmaps
    {
        public string _difficulty { get; set; }
        public int _difficultyRank { get; set; }
        public string _beatmapFilename { get; set; }
        public double _noteJumpMovementSpeed { get; set; }
        public double _noteJumpStartBeatOffset { get; set; }
        public _Customdata1 _customData { get; set; }
    }

    public class _Customdata1
    {
        public string _difficultyLabel { get; set; }
        public double _editorOffset { get; set; }
        public double _editorOldOffset { get; set; }
        public object[] _warnings { get; set; }
        public object[] _information { get; set; }
        public object[] _suggestions { get; set; }
        public object[] _requirements { get; set; }
    }
}