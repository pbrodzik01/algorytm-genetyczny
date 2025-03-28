using System;

public static class GeneticOperators
{
    private static readonly Random Random = new Random();

    public static Tuple<int[], int[]> Crossover(int[] parent1, int[] parent2)
    {
        int point = Random.Next(1, parent1.Length);
        int[] child1 = new int[parent1.Length];
        int[] child2 = new int[parent2.Length];

        for (int i = 0; i < parent1.Length; i++)
        {
            if (i < point)
            {
                child1[i] = parent1[i];
                child2[i] = parent2[i];
            }
            else
            {
                child1[i] = parent2[i];
                child2[i] = parent1[i];
            }
        }

        return new Tuple<int[], int[]>(child1, child2);
    }

    public static int[] Mutate(int[] chromosome, double mutationRate)
    {
        for (int i = 0; i < chromosome.Length; i++)
        {
            if (Random.NextDouble() < mutationRate)
            {
                chromosome[i] = 1 - chromosome[i]; // Flip bit
            }
        }

        return chromosome;
    }
}
