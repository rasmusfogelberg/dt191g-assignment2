using Microsoft.AspNetCore.Mvc.Rendering;

using MVCBookstore.Models;

namespace MVCBookstore.Repository
{

  // Basically this class is a naive implementation of the repository pattern. 
  // It serves to hide details on how data is being fetched/stored and to provide a uniform way of
  // retrieving, updating, saving and deleting data.

  // In this case the underlaying "storage" is completely done in memory using a List<T>.

  public class BookRepository
  {
    // Retrieve all the books
    public List<Book> SelectBooks()
    {
      return BookList.SelectBookList();
    }

    // Retrieve all the book types (i.e. hardback, pocket etc.)
    public List<SelectListItem> SelectTypes()
    {
      return BookList.SelectBookTypes();
    }

    // Retrieve specific book by id
    public Book? SelectBookById(int id)
    {
      return BookList.SelectBookList().Find(b => b.Id == id);
    }

    // Insert a new book in the list of books
    public void InsertBook(Book book)
    {
      BookList.InsertBookList(book);
    }

    // Update an existing book
    public void UpdateBook(Book book)
    {
      BookList.UpdateBookList(book);
    }

    // Delete a book
    public void DeleteBook(int id)
    {
      BookList.DeleteBookList(id);
    }
  }
}