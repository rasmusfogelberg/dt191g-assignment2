using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public enum Language { Swedish, English, Czech };

        [Required]
        [EnumDataType(typeof(Language))]
        public Language BookLanguage { get; set; }
    }
}