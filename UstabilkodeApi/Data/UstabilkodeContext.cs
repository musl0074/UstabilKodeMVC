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


        
    }
}
