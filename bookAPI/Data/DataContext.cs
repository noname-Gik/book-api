﻿using bookAPI.Models.Back;
using bookAPI.Models.Front;
using Microsoft.EntityFrameworkCore;

namespace bookAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<Books> Books { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Authors> Authors { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
    }
}
