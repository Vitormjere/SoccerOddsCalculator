

namespace Odds.Entities
{
    class Match
    {

        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public double HomeExpectedGoals { get; set; }
        public double AwayExpectedGoals { get; set; }

        public Match()
        {
        }
        public Match(Team home, Team away)
        {
            HomeTeam = home;
            AwayTeam = away;

            HomeExpectedGoals = (home.Attack + away.Defense) / 2;
            AwayExpectedGoals = (away.Attack + home.Defense) / 2;
        }



    }
}
