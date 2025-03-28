using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class GeneticAlgorithm
{
    private readonly int _capacity;
    private readonly List<Item> _items;
    private readonly int _populationSize;
    private readonly int _numIterations;
    private readonly double _crossoverRate;
    private readonly double _mutationRate;
    private static readonly Random Random = new Random();
    private readonly string _logFilePath;

    public GeneticAlgorithm(int capacity, List<Item> items, int populationSize, int numIterations, double crossoverRate, double mutationRate, string logFilePath)
    {
        _capacity = capacity;
        _items = items;
        _populationSize = populationSize;
        _numIterations = numIterations;
        _crossoverRate = crossoverRate;
        _mutationRate = mutationRate;
        _logFilePath = logFilePath;
    }

    public void Run()
    {
        // Inicjalizacja populacji (losowe chromosomy)
        var population = new int[_populationSize][];
        for (int i = 0; i < _populationSize; i++)
        {
            population[i] = RandomChromosome(_items.Count);
        }

        using (var writer = new StreamWriter(_logFilePath, append: true))
        {
            for (int iteration = 0; iteration < _numIterations; iteration++)
            {
                // Obliczanie przystosowania dla każdego chromosomu
                var fitnessValues = new int[_populationSize];
                for (int i = 0; i < _populationSize; i++)
                {
                    fitnessValues[i] = FitnessCalculator.CalculateFitness(population[i], _items, _capacity);
                }

                // Logowanie najlepszego wyniku w iteracji
                int bestFitness = fitnessValues.Max();
                string logMessage = $"Iteration {iteration + 1}: Best Fitness = {bestFitness}";
                Console.WriteLine(logMessage);
                writer.WriteLine(logMessage);

                // Selekcja ruletkowa
                population = Selection.RouletteWheelSelection(population, fitnessValues);

                var newPopulation = new List<int[]>();

                // Krzyżowanie
                for (int i = 0; i < population.Length; i += 2)
                {
                    if (Random.NextDouble() < _crossoverRate && i + 1 < population.Length)
                    {
                        var (child1, child2) = GeneticOperators.Crossover(population[i], population[i + 1]);
                        newPopulation.Add(child1);
                        newPopulation.Add(child2);
                    }
                    else
                    {
                        newPopulation.Add(population[i]);
                        newPopulation.Add(population[i + 1]);
                    }
                }

                // Mutacja
                for (int i = 0; i < newPopulation.Count; i++)
                {
                    newPopulation[i] = GeneticOperators.Mutate(newPopulation[i], _mutationRate);
                }

                population = newPopulation.ToArray();
            }
        }
    }

    private int[] RandomChromosome(int length)
    {
        var chromosome = new int[length];
        for (int i = 0; i < length; i++)
        {
            chromosome[i] = Random.Next(0, 2);
        }
        return chromosome;
    }
}
