using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace shared.model
{
    public class PostDataContext : DbContext
    {
        public DbSet<PostData> posts { get; set; }
        public string DbPath { get; }
        public PostDataContext()
        {
            DbPath = "Users/Nicol/OneDrive/Skrivebord/Projekt reddit/shared/bin/posts.db";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostData>()
                .HasKey(p => p.PostId); 

            modelBuilder.Entity<PostData>().ToTable("Tråde");
        }
    }
}