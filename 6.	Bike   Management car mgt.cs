///6.	Bike   Management / car mgt


using System;
using System.Collections.Generic;
using System.Linq;

public class Bike
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public decimal Price { get; set; }

    public Bike(string brand, string model, decimal price)
    {
        Brand = brand;
        Model = model;
        Price = price;
    }
}
public class BikeManagement
{
    private List<Bike> bikes;

    public BikeManagement(List<Bike> bikeList)
    {
        bikes = bikeList;
    }

    public List<Bike> MostExpensiveBike()
    {
        decimal maxPrice = bikes.Max(b => b.Price);
        return bikes.Where(b => b.Price == maxPrice).ToList();
    }

    public List<Bike> CheapestBike()
    {
        //decimal minPrice = bikes.Min(b => b.Price);
        //return bikes.Where(b => b.Price == minPrice).ToList();
        return bikes.FindAll(b => b.Price == bikes.Min(b => b.Price)).ToList();
    }

    public int AveragePriceofBike()
    {
        return (int)Math.Round(bikes.Average(b => b.Price));
    }

    public Dictionary<string, Bike> MostExpensiveModelForEachBrand()
    {
        return bikes.GroupBy(b => b.Brand)
                    .ToDictionary(g => g.Key, g => g.OrderByDescending(b => b.Price).First());
    }
}
public class Program
{
    public static void Main()
    {
        List<Bike> bikeList = new List<Bike>
        {
            new Bike("Yamaha", "YZF-R1", 15000),
            new Bike("Yamaha", "MT-07", 7001),
            new Bike("Kawasaki", "Ninja ZX-10R", 16000),
            new Bike("Kawasaki", "Ninja 400", 5000),
            new Bike("Ducati", "Panigale V4", 20000),
            new Bike("Ducati", "Monster 821", 11000),
        };

        BikeManagement bikeManagement = new BikeManagement(bikeList);

        var mostExpensiveBikes = bikeManagement.MostExpensiveBike();
        Console.WriteLine("Most Expensive Bike(s):");
        foreach (var bike in mostExpensiveBikes)
        {
            Console.WriteLine($"{bike.Brand} {bike.Model} - ${bike.Price}");
        }

        var cheapestBikes = bikeManagement.CheapestBike();
        Console.WriteLine("\nCheapest Bike(s):");
        foreach (var bike in cheapestBikes)
        {
            Console.WriteLine($"{bike.Brand} {bike.Model} - ${bike.Price}");
        }

        int averagePrice = bikeManagement.AveragePriceofBike();
        Console.WriteLine($"\nAverage Price of Bikes: ${averagePrice}");

        var mostExpensiveModelForEachBrand = bikeManagement.MostExpensiveModelForEachBrand();
        Console.WriteLine("\nMost Expensive Model for Each Brand:");
        foreach (var kvp in mostExpensiveModelForEachBrand)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value.Model} - ${kvp.Value.Price}");
        }
    }
}
