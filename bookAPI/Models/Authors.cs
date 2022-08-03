using System.ComponentModel.DataAnnotations;

namespace bookAPI.Models
{
    public class Authors
    {
        [Key]
        public int id { get; protected set; }
        [Required]
        public string fullname { get; set; }
    }
}
