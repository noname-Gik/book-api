using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookAPI.Models
{
    // Используется для демонстрации информации
    public class Genres
    {
        [Key]
        public int id { get; protected set; }
        [Required]
        public string name { get; set; }
    }
}
