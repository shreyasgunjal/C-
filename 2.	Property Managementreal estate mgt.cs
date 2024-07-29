///2.	Property Management/ real estate mgt

using System;
using System.Collections.Generic;
using System.Linq;


public interface IPropertyListing
{
    int Id { get; set; }
    string Title { get; set; }
    string Description { get; set; }
    decimal Price { get; set; }
    string Location { get; set; }
}

public interface IPropertyApp
{
    void AddProperty(IPropertyListing property);
    void RemoveProperty(int propertyId);
    void UpdateProperty(IPropertyListing property);
    IPropertyListing GetProperty(int propertyId);
    List<IPropertyListing> GetPropertiesByLocation(string location);
    List<IPropertyListing> GetPropertiesByPriceRange(decimal minPrice, decimal maxPrice);
}
public class PropertyListing : IPropertyListing
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Location { get; set; }

    public PropertyListing(int id, string title, string description, decimal price, string location)
    {
        Id = id;
        Title = title;
        Description = description;
        Price = price;
        Location = location;
    }
}

public class PropertyApp : IPropertyApp
{
    private List<IPropertyListing> listings = new List<IPropertyListing>();

    public void AddProperty(IPropertyListing property)
    {
        listings.Add(property);
    }

    public void RemoveProperty(int propertyId)
    {
        
        listings.RemoveAll(p => p.Id == propertyId);
    }

    public void UpdateProperty(IPropertyListing property)
    {
        var existingProperty = listings.FirstOrDefault(p => p.Id == property.Id);
        if (existingProperty != null)
        {
            existingProperty.Title = property.Title;
            existingProperty.Description = property.Description;
            existingProperty.Price = property.Price;
            existingProperty.Location = property.Location;
        }
    }

    public IPropertyListing GetProperty(int propertyId)
    {
        return listings.FirstOrDefault(p => p.Id == propertyId);
    }

    public List<IPropertyListing> GetPropertiesByLocation(string location)
    {
        return listings.Where(p => p.Location.Equals(location, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<IPropertyListing> GetPropertiesByPriceRange(decimal minPrice, decimal maxPrice)
    {
        return listings.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
    }
}
public class Program
{
    public static void Main()
    {
        IPropertyApp propertyApp = new PropertyApp();

        IPropertyListing property1 = new PropertyListing(1, "Luxury Villa", "A beautiful luxury villa", 500000, "New York");
        IPropertyListing property2 = new PropertyListing(2, "Cozy Cottage", "A small cozy cottage", 150000, "Los Angeles");
        IPropertyListing property3 = new PropertyListing(3, "Modern Apartment", "A modern apartment in the city center", 300000, "New York");

        propertyApp.AddProperty(property1);
        propertyApp.AddProperty(property2);
        propertyApp.AddProperty(property3);

        Console.WriteLine("All Properties:");
        foreach (var property in propertyApp.GetPropertiesByLocation("New York"))
        {
            Console.WriteLine($"{property.Title} in {property.Location} for ${property.Price}");
        }

        Console.WriteLine("\nProperties between $200,000 and $400,000:");
        foreach (var property in propertyApp.GetPropertiesByPriceRange(200000, 400000))
        {
            Console.WriteLine($"{property.Title} in {property.Location} for ${property.Price}");
        }

        propertyApp.RemoveProperty(2);
        Console.WriteLine("\nAll Properties after removal:");
        foreach (var property in propertyApp.GetPropertiesByLocation("New York"))
        {
            Console.WriteLine($"{property.Title} in {property.Location} for ${property.Price}");
        }

        IPropertyListing updatedProperty = new PropertyListing(1, "Luxury Villa Updated", "An updated beautiful luxury villa", 550000, "New York");
        propertyApp.UpdateProperty(updatedProperty);

        Console.WriteLine("\nAll Properties after update:");
        foreach (var property in propertyApp.GetPropertiesByLocation("New York"))
        {
            Console.WriteLine($"{property.Title} in {property.Location} for ${property.Price}");
        }
    }
}
