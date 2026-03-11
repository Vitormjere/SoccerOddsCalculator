# Football Match Probability Analyzer

A C# console application that analyzes football matches using a Poisson probability model to estimate expected goals and simulate possible scorelines.

The program calculates probabilities for match outcomes and common betting markets based on team attack and defense strengths.

## Features

- Calculate expected goals for each team
- Simulate score probabilities from 0–0 to 5–5
- Identify the most likely scorelines
- Estimate probabilities for:
  - Home win
  - Draw
  - Away win
  - Over / Under 2.5 goals
  - Both teams to score

## Technologies

- C#
- .NET
- Object-Oriented Programming
- LINQ

## Mathematical Model

The program uses the Poisson distribution to estimate the probability of a team scoring a certain number of goals based on expected goals.

P(k) = (λ^k * e^-λ) / k!

Where:
- k = number of goals
- λ = expected goals

## Author

Vitor Miranda
