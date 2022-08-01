using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bookAPI.Models
{
    public class Books
    {
        [JsonIgnore]
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public List<BookGenre> BookGenre { get; set; }
        public List<BookAuthor> BookAuthor { get; set; }
    }
}
