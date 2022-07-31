using System.ComponentModel.DataAnnotations;

namespace bookAPI.Models
{
    public class BookGenre
    {
        [Key]
        public int id { get; set; }
        public Genres genid { get; set; }
    }
}
