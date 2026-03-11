

namespace Odds.Entities
{
    class ScoreProbability 
    {
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public double Probability { get; set; }

        public ScoreProbability()
        {
        }

        public ScoreProbability(int homeGoals, int awayGoals, double probability)
        {
            HomeGoals = homeGoals;
            AwayGoals = awayGoals;
            Probability = probability;
        }
    }
}
