using bookAPI.Models.Back;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

// Создать отдельный слой для API - видно всю информацию
namespace bookAPI.Models.Front
{
    public class Books
    {
        // используется для заполнения ID
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public List<BookGenre> BookGenre { get; set; }
        public List<BookAuthor> BookAuthor { get; set; }
    }
}
