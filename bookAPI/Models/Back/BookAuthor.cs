using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace bookAPI.Models.Back
{
    // Создать отдельный слой для API - видно всю информацию
    public class BookAuthor
    {
        [JsonIgnore]
        [Key]
        public int id { get; set; }
        [ForeignKey("AuthorsId")]
        public int AuthorsId { get; set; }
    }
}
