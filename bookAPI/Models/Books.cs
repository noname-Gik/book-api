using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookAPI.Models
{
    // Используется для демонстрации информации
    public class Books
    {
        [Key]
        public int id { get; protected set; }
        [Required]
        public string name { get; set; }
        public List<BookGenre> BookGenre { get; set; }
        public List<BookAuthor> BookAuthor { get; set; }
    }
}
