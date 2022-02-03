using Microsoft.AspNetCore.Mvc.Rendering;

using MVCBookstore.Models;

namespace MVCBookstore.Repository
{
    public class BookRepository
    {
        public List<Book> SelectBooks()
        {
            return BookList.SelectBookList();
        }

        public List<SelectListItem> SelectTypes()
        {
            return BookList.SelectBookTypes();
        }

        public Book? SelectBookById(int id)
        {
            return BookList.SelectBookList().Find(b => b.Id == id);
        }

        public void InsertBook(Book book)
        {
            BookList.InsertBookList(book);
        }

        public void UpdateBook(Book book)
        {
            BookList.UpdateBookList(book);
        }

        public void DeleteBook(int id)
        {
            BookList.DeleteBookList(id);
        }
    }
}