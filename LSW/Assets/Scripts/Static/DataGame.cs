using UnityEngine.Events;

namespace LSW.Static
{
    public class DataGame
    {
        private static int currentTier;
        private static int currentHealthHero;
        private static int currentScore;

        //Getters and Setters
        public static int CurrentTier { get => currentTier; set => currentTier = value; }
        public static int CurrentHealthHero { get => currentHealthHero; set => currentHealthHero = value; }
        public static int CurrentScore { get => currentScore; set => currentScore = value; }
    }
}