using System;

public static class Selection
{
    private static readonly Random Random = new Random();

    public static int[][] RouletteWheelSelection(int[][] population, int[] fitnessValues)
    {
        int totalFitness = 0;
        foreach (var fitness in fitnessValues)
        {
            totalFitness += fitness;
        }

        var probabilities = new double[population.Length];
        for (int i = 0; i < population.Length; i++)
        {
            probabilities[i] = (double)fitnessValues[i] / totalFitness;
        }

        var selected = new int[population.Length][];
        for (int i = 0; i < population.Length; i++)
        {
            double randomValue = Random.NextDouble();
            double cumulative = 0.0;
            for (int j = 0; j < population.Length; j++)
            {
                cumulative += probabilities[j];
                if (cumulative >= randomValue)
                {
                    selected[i] = population[j];
                    break;
                }
            }
        }

        return selected;
    }
}
