using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookAPI.Models.Back
{
    // Создать отдельный слой для API - видно всю информацию
    public class BookGenre
    {
        [JsonIgnore]
        [Key]
        public int id { get; set; }
        [ForeignKey("GenresId")]
        public int GenresId { get; set; }
    }
}
