using System.ComponentModel.DataAnnotations;

namespace bookAPI.Models
{
    public class BookAuthor
    {
        [Key]
        public int id { get; set; }
        public Authors authid { get; set; }
    }
}
