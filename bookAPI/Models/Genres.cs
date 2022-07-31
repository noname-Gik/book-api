using System.ComponentModel.DataAnnotations;

namespace bookAPI.Models
{
    public class Genres
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
    }
}
