using System;
using Odds.Entities.Enums;
using Odds.Entities;
using static System.Formats.Asn1.AsnWriter;
using System.Data;

namespace odds
{
    public class  Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==============================");
            Console.WriteLine("ENTRE COM OS DADOS DA PARTIDA");
            Console.WriteLine("==============================");

            Console.Write("Nome do time #1: ");
            string homeName = Console.ReadLine();

            Console.Write("Ataque do time #1: ");
            double homeAttack = double.Parse(Console.ReadLine());

            Console.Write("Defesa do time #1: ");
            double homeDefense = double.Parse(Console.ReadLine());

            Console.WriteLine("------------------------");

            Console.Write("Nome do time #2: ");
            string awayName = Console.ReadLine();

            Console.Write("Ataque do time #2: ");
            double awayAttack = double.Parse(Console.ReadLine());

            Console.Write("Defesa do time #2: ");
            double awayDefense = double.Parse(Console.ReadLine());


            Team home = new Team(homeName, homeAttack, homeDefense); // criei os objetos da classe TEAM
            Team away = new Team(awayName, awayAttack, awayDefense);

            Match match = new Match(home, away); // a partida - passando os times como parametro para calcular os gols esperados

            List<ScoreProbability> probabilities = new List<ScoreProbability>(); // lista com as probabilidades


            for (int homeGoals = 0; homeGoals <= 5; homeGoals++) //gero todos os resultados de 0 até 5 gols para cada time
            {
                for (int awayGoals = 0; awayGoals <= 5; awayGoals++)
                {
                    double homeProb = PoissonCalculator.Poisson(homeGoals, match.HomeExpectedGoals);//probabilidade do time da casa fazer X gols, com POISSON
                    double awayProb = PoissonCalculator.Poisson(awayGoals, match.AwayExpectedGoals);

                    probabilities.Add(new ScoreProbability(
                        homeGoals,
                        awayGoals,
                        homeProb * awayProb // probabilidade do placar final
                     ));
                }
            }

            var topScores = probabilities //so pega os placares mais provaveis, os 5 primeiros
            .OrderByDescending(s => s.Probability)
            .Take(5);

            Console.WriteLine();

            Console.WriteLine("================");
            Console.WriteLine("GOLS ESPERADOS");
            Console.WriteLine("================");
            Console.WriteLine($"{home.Name}: {match.HomeExpectedGoals:F2}");
            Console.WriteLine($"{away.Name}: {match.AwayExpectedGoals:F2}");

            Console.WriteLine();

            Console.WriteLine("========================");
            Console.WriteLine("PLACARES MAIS PROVAVEIS");
            Console.WriteLine("========================");
            foreach (var score in topScores)
            {
                Console.WriteLine($"{score.HomeGoals}-{score.AwayGoals}: {score.Probability:F2}");
            }

            double homeWin = 0;
            double draw = 0;
            double awayWin = 0;

            foreach (var s in probabilities) // probabilidade de vitória ou empate
            {
                if (s.HomeGoals > s.AwayGoals)
                {
                    homeWin += s.Probability;
                }
                else if (s.HomeGoals == s.AwayGoals)
                {
                    draw += s.Probability;
                }
                else
                {
                    awayWin += s.Probability;
                }
            }

            Console.WriteLine();

            Console.WriteLine("=============================");
            Console.WriteLine("PROBABILIDADE DOS RESULTADOS");
            Console.WriteLine("=============================");
            Console.WriteLine($"#1 ganhar: {homeWin:F2}");
            Console.WriteLine($"Empate: {draw:F2}");
            Console.WriteLine($"#2 ganhar: {awayWin:F2}");

            double over25 = probabilities //pega placar com 3 gols ou mais de probabilidade
            .Where(s => s.HomeGoals + s.AwayGoals >= 3)
            .Sum(s => s.Probability);

            double under25 = 1 - over25;

            Console.WriteLine();

            Console.WriteLine("===========================");
            Console.WriteLine("MENOS DE/MAIS DE 2.5 GOLS");
            Console.WriteLine("===========================");
            Console.WriteLine($"Mais de 2.5: {over25:P2}");
            Console.WriteLine($"Menos de 2.5: {under25:P2}");

            double bothTeamsScore = probabilities
                .Where(s => s.HomeGoals > 0 && s.AwayGoals > 0)
                .Sum(s => s.Probability);

            Console.WriteLine();
            Console.WriteLine($"Ambas equipes marcam: {bothTeamsScore:P2}");
        }
    }
}