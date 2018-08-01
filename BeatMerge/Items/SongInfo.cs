using Newtonsoft.Json;

namespace BeatMerge.Items
{
    public class SongInfo
    {
        public DifficultyLevel[] difficultyLevels { get; set; }
        
        public double GetOffset(string difficulty)
        {
            return GetDifficulty(difficulty).offset;
        }
        
        private DifficultyLevel GetDifficulty(string difficulty)
        {
            for (int i = 0; i < difficultyLevels.Length; i++)
            {
                if (difficultyLevels[i].difficulty == difficulty)
                {
                    return difficultyLevels[i];
                }
            }

            return null;
        }
    }

    public class DifficultyLevel
    {
        public string difficulty { get; set; }
        public double offset { get; set; }
        public double oldOffset { get; set; }
    }
}
