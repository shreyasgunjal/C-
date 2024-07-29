//5. Person,Gender Inheritance

using System;
using System.Collections.Generic;
using System.Linq;

public enum Gender
{
    Male,
    Female,
    Other
}

public abstract class Person
{
    public string Type { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public Gender Gender { get; private set; }

    public Person(string type, string name, Gender gender, int age)
    {
        Type = type;
        Name = name;
        Gender = gender;
        Age = age;
    }

    public string GetUserName()
    {
        return Name;
    }

    public string GetUserType()
    {
        return Type;
    }

    public int GetAge()
    {
        return Age;
    }

    public Gender GetGender()
    {
        return Gender;
    }
}

public class Admin : Person
{
    public Admin(string name, Gender gender, int age)
        : base("Admin", name, gender, age)
    {
    }
}
public class Moderator : Person
{
    public Moderator(string name, Gender gender, int age)
        : base("Moderator", name, gender, age)
    {
    }
}
public class Program
{
    public static void Main()
    {
        Admin admin = new Admin("Alice", Gender.Female, 30);
        Moderator moderator = new Moderator("Bob", Gender.Male, 25);

        Console.WriteLine($"Admin Details: Name={admin.GetUserName()}, Type={admin.GetUserType()}, Age={admin.GetAge()}, Gender={admin.GetGender()}");
        Console.WriteLine($"Moderator Details: Name={moderator.GetUserName()}, Type={moderator.GetUserType()}, Age={moderator.GetAge()}, Gender={moderator.GetGender()}");
    }
}
