

namespace Odds.Entities
{
    class Team
    {
        public string Name { get; set; }
        public double Attack { get; set; }
        public double Defense { get; set; }


        public Team()
        {
        }
        public Team(string name, double attack, double defense)
        {
            Name = name;
            Attack = attack;
            Defense = defense;
        }
    }
}
