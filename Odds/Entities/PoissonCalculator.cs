

namespace Odds.Entities
{
    class PoissonCalculator
    {
            public static double Poisson(int k, double lambda) // P(k) = (λ^k * e^-λ) / k!
            {
                return (Math.Pow(lambda, k) * Math.Exp(-lambda)) / Factorial(k); // k - número de gols, lambda - média de gols esperada
            }

            public static int Factorial(int n)
            {
                if (n == 0) return 1;

                int result = 1;

                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                }

                return result;
            }
    }
}
