using System;
using System.Collections.Generic;

// Klasa odpowiedzialna za obliczanie funkcji przystosowania (fitness)
public static class FitnessCalculator
{
    public static int CalculateFitness(int[] chromosome, List<Item> items, int capacity)
    {
        int totalValue = 0;  // Łączna wartość wybranych przedmiotów
        int totalWeight = 0; // Łączna waga wybranych przedmiotów

        for (int i = 0; i < chromosome.Length; i++)
        {
            // Jeśli gen wynosi 1, przedmiot jest w plecaku
            if (chromosome[i] == 1)
            {
                totalValue += items[i].Value;
                totalWeight += items[i].Weight;
            }
        }

        // Jeśli waga przekracza pojemność, rozwiązanie jest nielegalne (fitness = 0)
        return totalWeight <= capacity ? totalValue : 0;
    }
}
