using System.ComponentModel.DataAnnotations;

namespace bookAPI.Models
{
    public class Books
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public List<BookGenre> BookGenre { get; set; }
        [Required]
        public List<BookAuthor> BookAuthor { get; set; }
    }
}
