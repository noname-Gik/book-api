using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookAPI.Models
{
    // Используется для демонстрации информации
    public class BookAuthor
    {
        [Key]
        public int id { get; protected set; }
        [ForeignKey("AuthorsId")]
        [Required]
        public int AuthorsId { get; set; }
    }
}
