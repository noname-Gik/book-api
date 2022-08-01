using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookAPI.Models
{
    public class BookAuthor
    {
        [JsonIgnore]
        [Key]
        public int id { get; set; }
        [ForeignKey("AuthorsId")]
        public int AuthorsId { get; set; }
    }
}
