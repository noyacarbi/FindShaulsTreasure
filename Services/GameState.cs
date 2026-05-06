using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindShaulsTreasure.Services
{
    internal static class GameState
    {
        public const int QuestScore = 100;

        public static int TeamId { 
            get => Preferences.Default.Get("team_id", -1); 
            set => Preferences.Default.Set("team_id", value); 
        }

        public static int QuestIndex
        {
            get => Preferences.Default.Get("quest_index", 0);
            set => Preferences.Default.Set("quest_index", value);
        }

        public static int Score
        {
            get => Preferences.Default.Get("score", 0);
            set => Preferences.Default.Set("score", value);
        }

        public static void Clear()
        {
            Preferences.Default.Clear();
        }
    }
}
