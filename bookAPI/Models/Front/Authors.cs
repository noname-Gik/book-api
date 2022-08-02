using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

// Создать отдельный слой для API - видно всю информацию
namespace bookAPI.Models.Front
{
    public class Authors
    {
        // используется для автоматического заполнения ID
        [Key]
        public int id { get; set; }
        [Required]
        public string fullname { get; set; }
    }
}
