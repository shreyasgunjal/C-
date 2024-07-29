//Book Library – Movie library///

using System;
using System.Collections.Generic;
using System.Linq;
public interface IBook
{
    string Title { get; set; }
    string Author { get; set; }
    int Year { get; set; }
}

public interface IBookLibrary
{
    void AddBook(IBook book);
    void RemoveBook(string title);
    List<IBook> GetBooks();
    List<IBook> SearchBook(string query);
    int GetTotalBookCount();
}
public class Book : IBook
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }
    
}
public class BookLibrary : IBookLibrary
{
    private List<Book> books = new List<Book>();
    
    public void AddBook(IBook book)
    {
        books.Add((Book)book);
    }

    public void RemoveBook(string title)
    {
        books.RemoveAll(b => b.Title==title);
    }

    public List<IBook> GetBooks()
    {
        return books.Cast<IBook>().ToList();
        
    }

    public List<IBook> SearchBook(string query)
    {
        return books.FindAll(b => b.Title.Contains(query) || b.Author.Contains(query)).Cast<IBook>().ToList();
    }

    public int GetTotalBookCount()
    {
        return books.Count;
    }
}
public class Program
{
    public static void Main()
    {
        IBookLibrary library = new BookLibrary();

        IBook book1 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925);
        IBook book2 = new Book("1984", "George Orwell", 1949);
        IBook book3 = new Book("To Kill a Mockingbird", "Harper Lee", 1960);

        library.AddBook(book1);
        library.AddBook(book2);
        library.AddBook(book3);

        Console.WriteLine("Total books: " + library.GetTotalBookCount());

        var searchResults = library.SearchBook("George");
        Console.WriteLine("Search results:");
        foreach (var book in searchResults)
        {
            Console.WriteLine($"{book.Title} by {book.Author}");
        }

        library.RemoveBook("1984");
        Console.WriteLine("Total books after removal: " + library.GetTotalBookCount());
    }
}
