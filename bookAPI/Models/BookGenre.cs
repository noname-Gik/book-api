using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookAPI.Models
{
    public class BookGenre
    {
        [JsonIgnore]
        [Key]
        public int id { get; set; }
        [ForeignKey("GenresId")]
        public int GenresId { get; set; }
    }
}
