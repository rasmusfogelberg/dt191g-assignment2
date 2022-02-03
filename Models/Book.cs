using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCBookstore.Models
{
  public class Book
  {
    private static int bookId = 1;
    public int Id { get; set; } = ++bookId;

    [StringLength(100, MinimumLength = 2)]
    [Required]
    public string Title { get; set; } = string.Empty;

    [StringLength(100, MinimumLength = 5)]
    [Required]
    public string Author { get; set; } = string.Empty;

    [Range(0, 100)]
    [Required]
    public int Stock { get; set; } = 0;

    [Range(1, 100)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public enum _Language { Czech, English, Swedish };

    [Required]
    [EnumDataType(typeof(_Language))]
    public _Language Language { get; set; }

    // two lists
    // first list tracks items that are currently "selected"/"checked"
    // second list tracks all available options to "select"/"check"

    // List of strings for types of books
    public List<string> SelectedTypes { get; set; } = new List<string>();
    public List<SelectListItem> AvailableTypes { get; set; } = new List<SelectListItem>();

  }
}