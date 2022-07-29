using System.ComponentModel.DataAnnotations;

namespace bookAPI.Models
{
    public class Books
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
    }
}
