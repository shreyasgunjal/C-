///4.	Laptop -/ computer inheritance

using System;
using System.Collections.Generic;
using System.Linq;
public abstract class Laptop
{
    public string Type { get; private set; }
    public string Model { get; private set; }
    public string CPU { get; private set; }
    public bool IsTurnedOn { get; private set; } = false;

    public Laptop(string type, string model, string cpu)
    {
        Type = type;
        Model = model;
        CPU = cpu;
    }

    public string GetLaptopType()
    {
        return Type;
    }

    public string GetLaptopModel()
    {
        return Model;
    }

    public string GetLaptopCPU()
    {
        return CPU;
    }

    public string GetLaptopStatus()
    {
        return IsTurnedOn ? "On" : "Off";
    }

    public void SwitchComputerStatus()
    {
        IsTurnedOn = !IsTurnedOn;
    }
}
public class PersonalLaptop : Laptop
{
    public PersonalLaptop(string type, string model, string cpu)
        : base(type, model, cpu)
    {
    }

    public void DisplayLaptopDetails()
    {
        Console.WriteLine($"Type: {GetLaptopType()}");
        Console.WriteLine($"Model: {GetLaptopModel()}");
        Console.WriteLine($"CPU: {GetLaptopCPU()}");
        Console.WriteLine($"Status: {GetLaptopStatus()}");
    }
}
public class Program
{
    public static void Main()
    {
        PersonalLaptop myLaptop = new PersonalLaptop("Personal", "Dell XPS 15", "Intel Core i7");

        myLaptop.DisplayLaptopDetails();
        myLaptop.SwitchComputerStatus();
        Console.WriteLine($"Status after toggle: {myLaptop.GetLaptopStatus()}");

        myLaptop.SwitchComputerStatus();
        Console.WriteLine($"Status after another toggle: {myLaptop.GetLaptopStatus()}");
    }
}
