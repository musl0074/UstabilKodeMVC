using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UstabilkodeApi.Data;

namespace UstabilkodeApi.Models
{
    public class UstabilkodeContext : DbContext
    {
        public UstabilkodeContext(DbContextOptions<UstabilkodeContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<UstabilkodeApi.Data.Post> Post { get; set; }

        public DbSet<UstabilkodeApi.Data.Comment> Comment { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany((p) => p.Comments)
                .WithOne((c) => c.Post)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne((c) => c.Post)
                .WithMany((p) => p.Comments)
                .OnDelete(DeleteBehavior.Restrict);


            // Respect identity columns
            modelBuilder.Entity<Post>().Property((p) => p.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Comment>().Property((c) => c.ID).ValueGeneratedOnAdd();

        }
    }
}
