using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace bookAPI.Models
{
    public class Authors
    {
        [Required]
        [Key]
        public int id { get; set; }
        [Required]
        public string fullname { get; set; }
    }
}
