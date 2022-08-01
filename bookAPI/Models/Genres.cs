using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bookAPI.Models
{
    public class Genres
    {
        [Required]
        [Key]
        public int id { get; set; }
        [JsonIgnore]
        public string name { get; set; } = string.Empty;
    }
}
