using System;
using System.Collections.Generic;
using System.IO;

// Klasa odpowiedzialna za wczytywanie danych do problemu plecakowego
public static class DataLoader
{
    public static (int capacity, List<Item> items) LoadData(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        // Pierwsza linia zawiera pojemność plecaka
        int capacity = int.Parse(lines[0].Split()[1]);

        var items = new List<Item>();

        // Kolejne linie zawierają przedmioty w formacie "wartość waga"
        for (int i = 1; i < lines.Length; i++)
        {
            var parts = lines[i].Split();
            items.Add(new Item
            {
                Value = int.Parse(parts[0]),
                Weight = int.Parse(parts[1])
            });
        }

        return (capacity, items);
    }
}

