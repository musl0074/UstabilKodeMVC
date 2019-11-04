using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UstabilkodeApi.Models
{
    public class UstabilkodeContext : DbContext
    {
        public UstabilkodeContext(DbContextOptions<UstabilkodeContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
