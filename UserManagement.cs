//User Management
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
class User
{
    public int Id { get; set; }
    public string IdentityNumber { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public DateOnly? BirthDate { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;    
    public string Address { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Roles { get; set; } = string.Empty;
    public DateOnly? JoinDate { get; set; }
    public decimal Credit { get; set; }
    public string Status { get; set; } = string.Empty;
}
static class UserManager
{
    /*
    * Complete the 'CompareUsers' function below.
    *
    * The function is expected to return two lists which are updat
   ed and inserted.
    * The function accepts two lists usersListInDB and newUsersLis
   t as parameter.
    */



    public static (List<User> updated, List<User> inserted) CompareUsers(List<User> userListInDB, List<User> newUsersList)
    {
        List<User> updated = new List<User>();
        List<User> inserted = new List<User>();

        
        
            foreach (var newUser in newUsersList)
            {
                var existingUser = userListInDB.FirstOrDefault(x => x.Id ==newUser.Id);
                if (existingUser!=null)
                { 
                    if (newUser.IdentityNumber==existingUser.IdentityNumber &&
                        newUser.FirstName == existingUser.FirstName &&
                        newUser.LastName==existingUser.LastName &&
                        newUser.Age==existingUser.Age &&
                        newUser.BirthDate==existingUser.BirthDate &&
                        newUser.Email==existingUser.Email &&
                        newUser.Gender == existingUser.Gender &&
                        newUser.Country == existingUser.Country &&
                        newUser.City==existingUser.City &&
                        newUser.Address==existingUser.Address &&
                        newUser.ZipCode==existingUser.ZipCode &&
                        newUser.PhoneNumber ==existingUser.PhoneNumber &&
                        newUser.Department == existingUser.Department &&
                        newUser.Roles==existingUser.Roles &&
                        newUser.JoinDate == existingUser.JoinDate &&
                        newUser.Status == existingUser.Status &&
                        newUser.Credit == existingUser.Credit)
                    {
                    updated.Add(newUser);
                    }                   
                }
                else
                {
                    inserted.Add(newUser);
            }
            }

        return ((updated,inserted));
    }

}
class Solution
{
    public static void Main(string[] args)
    {
        
        List<User> usersListInDB = new List<User>();
        List<User> newUsersList = new List<User>();

        int userInDbCount = Convert.ToInt32(Console.ReadLine().Trim
       ());
        for (int i = 0; i < userInDbCount; i++)
        {
            var u = Console.ReadLine().Trim().Split(',');
            var usr = new User()
            {
                Id = string.IsNullOrEmpty(u[0]) ? 0 : Convert.ToInt32(u[0]),
                IdentityNumber = u[1],
                FirstName = u[2],
                LastName = u[3],
                Age = string.IsNullOrEmpty(u[4]) ? 0 : Convert.ToInt32(u[4]),
                BirthDate = string.IsNullOrEmpty(u[5]) ? null : new DateOnly(Convert.ToInt32(u[5].Split('.')[0]), Convert.ToInt32(u[5].Split('.')[1]), Convert.ToInt32(u[5].Split('.')[2])),
                Email = u[6],
                Gender = u[7],
                Country = u[8],
                City = u[9],
                Address = u[10],
                ZipCode = u[11],
                PhoneNumber = u[12],
                Department = u[13],
                Roles = u[14],
                JoinDate = string.IsNullOrEmpty(u[15]) ? null : new DateOnly(Convert.ToInt32(u[15].Split('.')[0]), Convert.ToInt32(u[15].Split('.')[1]), Convert.ToInt32(u[15].Split('.')[2])),
                Credit = string.IsNullOrEmpty(u[16]) ? 0 : Convert.ToDecimal(u[16]),
                Status = u[17]
            };
            usersListInDB.Add(usr);
        }
        int newUsersCount = Convert.ToInt32(Console.ReadLine().Trim());
        for (int i = 0; i < newUsersCount; i++)
        {
            var u = Console.ReadLine().Trim().Split(',');
            var usr = new User()
            {
                Id = string.IsNullOrEmpty(u[0]) ? 0 : Convert.ToInt32(u[0]),
                IdentityNumber = u[1],
                FirstName = u[2],
                LastName = u[3],
                Age = string.IsNullOrEmpty(u[4]) ? 0 : Convert.ToInt32(u[4]),
                BirthDate = string.IsNullOrEmpty(u[5]) ? null : new DateOnly(Convert.ToInt32(u[5].Split('.')[0]), Convert.ToInt32(u[5].Split('.')[1]), Convert.ToInt32(u[5].Split('.')[2])),
                Email = u[6],
                Gender = u[7],
                Country = u[8],
                City = u[9],
                Address = u[10],
                ZipCode = u[11],
                PhoneNumber = u[12],
                Department = u[13],
                Roles = u[14],
                JoinDate = string.IsNullOrEmpty(u[15]) ? null : new DateOnly(Convert.ToInt32(u[15].Split('.')[0]), Convert.ToInt32(u[15].Split('.')[1]), Convert.ToInt32(u[15].Split('.')[2])),
                Credit = string.IsNullOrEmpty(u[16]) ? 0 : Convert.ToDecimal(u[16]),
                Status = u[17]
            };
            newUsersList.Add(usr);
        }
        var (updated, inserted) = UserManager.CompareUsers(usersListInDB, newUsersList);
        Console.WriteLine("Updated Users:" + updated.Count);
        Console.WriteLine("Inserted Users:" + inserted.Count);
        Console.ReadKey();
    }
}


//different method

class UserManager
{
    public static (List<User> updated, List<User> inserted) CompareUsers(List<User> usersListInDB, List<User> newUsersList)
    {
        var updated = new List<User>();
        var inserted = new List<User>();

        foreach (var user in newUsersList)
        {
            var userInDB = usersListInDB.FirstOrDefault(u => u.Id == user.Id);
            if (userInDB != null)
            {
                var properties = user.GetType().GetProperties();
                foreach (var property in properties)
                {
                    var valueInDB = property.GetValue(userInDB);
                    var valueInNewList = property.GetValue(user);
                    if ((valueInDB == null && valueInNewList == null) || (valueInDB == null || valueInNewList == null))
                        continue;
                    if (!valueInDB.Equals(valueInNewList))
                    {
                        updated.Add(user);
                        break;
                    }
                }
            }
            else
            {
                inserted.Add(user);
            }
        }

        return (updated, inserted);
    }
}
