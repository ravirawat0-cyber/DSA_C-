using System;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }

    public Book(int id, string title)
    {
        Id = id;
        Title = title;
    }

}

public class Library
{
    public Book[] Books { get; set; }
    public Library(Book[] books)
    {
        Books = books;
    }

    //shallow copy 
    public Library ShallowCopy()
    {
        return (Library)this.MemberwiseClone();
    }

    // deep copy
    public Library DeepCopy()
    {
        Book[] copiedBooks = new Book[Books.Length];
        for (int i = 0; i < Books.Length; i++)
        {
            copiedBooks[i] = new Book(Books[i].Id, Books[i].Title);
        }

        return new Library(copiedBooks);
    }
}





class Program{


  static void Main(string[] args) {
      Book[] books = {
          new Book(1, "Harry Potter"),
          new Book(2, "Lord of the Rings")
      };

      Library library1 = new Library(books);
      Library library2 = library1.ShallowCopy();

      // Modify a book in library1
      library1.Books[0].Title = "Harry Potter - Updated";

      // Output the titles from both libraries
      Console.WriteLine($"Library 1 - Book 1 Title: {library1.Books[0].Title}");
      Console.WriteLine($"Library 2 - Book 1 Title: {library2.Books[0].Title}");

      // Output:
      // Library 1 - Book 1 Title: Harry Potter - Updated
      // Library 2 - Book 1 Title: Harry Potter - Updated
  }
}