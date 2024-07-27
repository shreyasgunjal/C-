//Authenticate State

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

interface IUser
{
    int Id { get; set; }
    string Email { get; set; }
    string Password { get; set; }
    int IncorrectAttempt { get; set; }
    string Location { get; set; }
}

interface IApplicationAuthState
{
    List<IUser> RegisteredUsers { get; set; }
    List<IUser> UsersLoggedIn { get; set; }
    List<string> AllowedLocations { get; set; }
    string Register(IUser user);
    string Login(IUser user);
    string Logout(IUser user);
}

class User : IUser
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int IncorrectAttempt { get; set; }
    public string Location { get; set; } = string.Empty;

    public User(int id, string email, string password, string location)
    {
        Id = id;
        Email = email;
        Password = password;
        Location = location;
        IncorrectAttempt = 0;
    }
}

class ApplicationAuthState : IApplicationAuthState
{
    public List<IUser> RegisteredUsers { get; set; }
    public List<IUser> UsersLoggedIn { get; set; }
    public List<string> AllowedLocations { get; set; }

    public ApplicationAuthState(List<string> allowedLocations)
    {
        RegisteredUsers = new List<IUser>();
        UsersLoggedIn = new List<IUser>();
        AllowedLocations = allowedLocations;
    }

    public string Register(IUser user)
    {
        if (RegisteredUsers.Any(u => u.Email == user.Email))
        {
            return $"{user.Email} is already registered!";
        }

        RegisteredUsers.Add(user);
        return $"{user.Email} registered successfully!";
    }

    public string Login(IUser user)
    {
        var registeredUser = RegisteredUsers.FirstOrDefault(u => u.Email == user.Email);

        if (registeredUser == null)
        {
            return $"{user.Email} is not registered!";
        }

        if (registeredUser.IncorrectAttempt >= 3)
        {
            return $"{user.Email} is blocked!";
        }

        if (!AllowedLocations.Contains(user.Location))
        {
            return $"{user.Email} is not allowed to login from this location!";
        }

        


        if (registeredUser.Password != user.Password)
        {
            registeredUser.IncorrectAttempt++;
            return $"{user.Email} password is incorrect!";
        }

        if (UsersLoggedIn.Any(u => u.Email == user.Email))
        {
            var loggedInUser = UsersLoggedIn.FirstOrDefault(u => u.Email == user.Email);
            if (loggedInUser.Location != user.Location)
            {
                return $"{user.Email} is already logged in from another location!";
            }
            else
            {
                return $"{user.Email} is already logged in!";
            }
        }

        UsersLoggedIn.Add(registeredUser);
        registeredUser.IncorrectAttempt = 0;
        return $"{user.Email} logged in successfully!";


        

       


    }

    public string Logout(IUser user)
    {
        var loggedInUser = UsersLoggedIn.FirstOrDefault(u => u.Email == user.Email);

        if (loggedInUser == null)
        {
            return $"{user.Email} is not logged in!";
        }

        UsersLoggedIn.Remove(loggedInUser);
        return $"{user.Email} logged out successfully!";
    }
}

class Solution
{
    public static void Main(string[] args)
    {

        List<IUser> users = new List<IUser>();
        List<string> allowedLocations = new List<string>();
        int allowedLocationCount = Convert.ToInt32(Console.ReadLine().Trim());
        for (int i = 0; i < allowedLocationCount; i++)
        {
            var a = Console.ReadLine().Trim();
            allowedLocations.Add(a);
        }

        ApplicationAuthState authState = new ApplicationAuthState(allowedLocations);

        int usersCount = Convert.ToInt32(Console.ReadLine().Trim());
        for (int i = 0; i < usersCount; i++)
        {
            var a = Console.ReadLine().Trim().Split(',');
            users.Add(new User(Convert.ToInt32(a[0]), a[1], a[2], a[3]));
        }

        int actionCount = Convert.ToInt32(Console.ReadLine().Trim());
        for (int i = 0; i < actionCount; i++)
        {
            var a = Console.ReadLine().Trim().Split(':');
            var uIndex = Convert.ToInt32(a[1]);
            if (a[0] == "Register")
            {
                Console.WriteLine(authState.Register(users[uIndex]));
            }
            else if (a[0] == "Login")
            {
                Console.WriteLine(authState.Login(users[uIndex]));
            }
            else if (a[0] == "Logout")
            {
                Console.WriteLine(authState.Logout(users[uIndex]));
            }
            
        }
        Console.ReadKey();
    }
}
//16,user16@email.com,1234,16
//8,user8@email.com,3421,8
//17,user17@email.com,5678,17
//16,user16@email.com,16
