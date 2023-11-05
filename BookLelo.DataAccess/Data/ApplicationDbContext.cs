using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookLelo.Model;
using System.Threading.Tasks;

namespace BookLelo.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public object Covertype;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) { 
        }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<CoverType> CoverType{ get; set; }
    }
}
