using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookAPI.Models
{
    // Используется для демонстрации информации
    public class BookGenre
    {
        [Key]
        public int id { get; protected set; }
        [ForeignKey("GenresId")]
        [Required]
        public int GenresId { get; set; }
    }
}
