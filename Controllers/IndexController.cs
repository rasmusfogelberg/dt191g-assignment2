using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCBookstore.Models;
using MVCBookstore.Repository;
using Microsoft.AspNetCore.Authorization;

namespace MVCBookstore.Controllers;

[Authorize]
public class IndexController : Controller
{

  BookRepository bookRepo = new BookRepository();
  public IndexController()
  {
  }

  public IActionResult Index()
  {
    IEnumerable<Book> books = bookRepo.SelectBooks();
    return View(books);
  }

  public IActionResult About()
  {
    IList<Book> books = bookRepo.SelectBooks();
    IEnumerable<Book> sortedBookList = books.OrderByDescending(book => book.Price).ToList();

    ViewData["Title"] = "About";
    ViewBag.Books = sortedBookList;
    ViewBag.UniqueBooks = books.Count();

    return View();
  }

  public IActionResult Details(int id)
  {
    Book? book = bookRepo.SelectBookById(id);

    if (book == null)
    {
      throw new HttpRequestException();
    }

    return View(book);
  }

  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Create([Bind("Id,Title,Author,Stock,Price,Language")] Book book)
  {
    if (ModelState.IsValid)
    {
      try
      {
        bookRepo.InsertBook(book);
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    return View(book);
  }

  // GET - display edit view for the book (loads the data into the form)
  public IActionResult Edit(int id)
  {
    Book? book = bookRepo.SelectBookById(id);

    return View(book);
  }

  // POST - edit the book values
  [HttpPost]
  [ValidateAntiForgeryToken]
  public IActionResult Edit(int id, [Bind("Id,Title,Author,Stock,Price,Language")] Book book)
  {
    if (id != book.Id)
    {
      return NotFound();
    }

    if (ModelState.IsValid)
    {
      try
      {
        bookRepo.UpdateBook(book);
        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    return View(book);
  }

  // GET - view the delete confirmation screen for a book
  public IActionResult Delete(int id)
  {
    Book? book = bookRepo.SelectBookById(id);

    return View(book);
  }

  // POST - deletes the book
  [HttpPost, ActionName("Delete")]
  [ValidateAntiForgeryToken]
  public IActionResult DeleteConfirmed(int id)
  {
    try
    {
      bookRepo.DeleteBook(id);
      return RedirectToAction(nameof(Index));
    }
    catch
    {
      return View();
    }
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }

}
