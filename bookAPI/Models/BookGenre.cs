using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookAPI.Models
{
    public class BookGenre
    {
        [JsonIgnore]
        [Required]
        [Key]
        public int id { get; set; }
        [ForeignKey("GenresId")]
        [Required]
        public int GenresId { get; set; }
    }
}
