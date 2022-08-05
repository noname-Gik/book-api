using System.ComponentModel.DataAnnotations;

namespace BookAPI.Models
{
    public class Authors
    {
        [Key]
        public int id { get; protected set; }
        [Required]
        public string fullname { get; set; }
    }
}
