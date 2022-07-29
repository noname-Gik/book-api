using System.Text.Json.Serialization;

namespace bookAPI.Models
{
    public class Connections
    {
        public int id { get; set; }
        public Books Book { get; set; }
        public Genres Genre { get; set; }
        public Authors Author { get; set; }
    }
}
