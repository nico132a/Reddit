using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace shared.model { 

public class CommentDataContext : DbContext
{
        public DbSet<Comment> comments { get; set; }
        public string DbPath { get; }
        public CommentDataContext()
        {
            DbPath = "Users/Nicol/OneDrive/Skrivebord/Projekt reddit/shared/bin/Comments.db";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().ToTable("Kommentarer");
        }

 
}
}

