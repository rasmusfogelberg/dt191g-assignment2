using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBookstore.Models;

namespace MVCBookstore.Repository
{
  public static class BookList
  {
    static List<Book> bookList = new List<Book>();

    // Testdata for the application
    static BookList()
    {
      bookList = new List<Book>()
            {
                new Book { Title = "1984", Author = "George Orwell", Stock = 10, Price = 59.99m, Language = Book._Language.Swedish, SelectedTypes = new List<string> { "Hardback", "Ebook" } },
                new Book { Title = "Sword of Destiny", Author = "Andrzej Sapkowski", Stock = 2, Price = 27.99m, Language = Book._Language.Czech, SelectedTypes = new List<string> { "Hardback", "Pocket" } },
                new Book { Title = "The Last Wish", Author = "Andrzej Sapkowski", Stock = 3, Price = 25.99m, Language = Book._Language.Czech, SelectedTypes = new List<string> { "Hardback", "Pocket" } },
                new Book { Title = "The Way of Kings", Author = "Brandon Sanderson", Stock = 1, Price = 69.99m, Language = Book._Language.English, SelectedTypes = new List<string> { "Pocket", "Ebook" } },
                new Book { Title = "Oathbringer", Author = "Brandon Sanderson", Stock = 2, Price = 79.99m, Language = Book._Language.English, SelectedTypes = new List<string> { "Hardback", "Pocket", "Ebook" } },
            };
    }

    // Different types of books
    public static List<SelectListItem> SelectBookTypes()
    {
      return new List<SelectListItem>
        {
            new SelectListItem { Text = "Hardback", Value = "Hardback" },
            new SelectListItem { Text = "Pocket", Value = "Pocket" },
            new SelectListItem { Text = "Ebook", Value = "Ebook" },
        };
    }

    // Select all books
    public static List<Book> SelectBookList()
    {
      return bookList;
    }

    // Create
    public static void InsertBookList(Book book)
    {
      bookList.Add(book);
    }

    // Update
    public static void UpdateBookList(Book book)
    {
      Book? bookToUpdate = bookList.Find(b => b.Id == book.Id);

      if (bookToUpdate != null)
      {
        bookToUpdate.Title = book.Title;
        bookToUpdate.Author = book.Author;
        bookToUpdate.Stock = book.Stock;
        bookToUpdate.Price = book.Price;
        bookToUpdate.Language = book.Language;
        bookToUpdate.SelectedTypes = book.SelectedTypes;
      }
    }

    // Delete
    public static void DeleteBookList(int id)
    {
      Book? bookToDelete = bookList.Find(b => b.Id == id);

      if (bookToDelete != null)
      {
        bookList.Remove(bookToDelete);
      }
    }
  }
}