using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bookAPI.Models
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
