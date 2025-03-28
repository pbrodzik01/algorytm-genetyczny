using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        string filePath = "f1_l-d_kp_10_269";
        string logFilePath = "f1_l-d_kp_10_269_log.txt"; // Ścieżka do pliku logu

        Console.WriteLine($"Plik danych: {Path.GetFullPath(filePath)}");

        var (capacity, items) = DataLoader.LoadData(filePath);

        // Przekazanie logFilePath jako argumentu do konstruktora
        var ga = new GeneticAlgorithm(
            capacity: capacity,
            items: items,
            populationSize: 50,
            numIterations: 100,
            crossoverRate: 0.7,
            mutationRate: 0.1,
            logFilePath: logFilePath  // Przekazanie ścieżki pliku logu
        );

        ga.Run();
    }
}
