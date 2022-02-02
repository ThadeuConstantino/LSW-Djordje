using UnityEngine.Events;

namespace LSW.Static
{
    public class DataGame
    {
        private static int currentTier = 1;
        private static int currentHealthHero = 3;
        private static int currentScore = 0;

        public static bool win; 
        public const string PREFAB_ENDGAME = "PopEndGame";

        //Getters and Setters
        public static int CurrentTier { get => currentTier; set => currentTier = value; }
        public static int CurrentHealthHero { get => currentHealthHero; set => currentHealthHero = value; }
        public static int CurrentScore { get => currentScore; set => currentScore = value; }
    }
}