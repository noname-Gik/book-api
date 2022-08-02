using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

// Создать отдельный слой для API - видно всю информацию
namespace bookAPI.Models.Front
{
    public class Genres
    {
        // используется для заполнения ID
        [Required]
        [Key]
        public int id { get; set; }
        [JsonIgnore]
        public string name { get; set; } = string.Empty;
    }
}
