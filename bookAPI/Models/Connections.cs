﻿namespace bookAPI.Models
{
    public class Connections
    {
        public int id { get; set; }
        public Authors Authors { get; set; }
        public Genres Genres { get; set; }
        public Books Books { get; set; }
    }
}
