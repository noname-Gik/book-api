using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookAPI.Models
{
    public class BookAuthor
    {
        [JsonIgnore]
        [Required]
        [Key]
        public int id { get; set; }
        [ForeignKey("AuthorsId")]
        [Required]
        public int AuthorsId { get; set; }
    }
}
