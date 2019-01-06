using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CyrensService.Models;

namespace CyrensService.Models
{
    public class CyrensDbContext : DbContext
    {
        public CyrensDbContext(DbContextOptions<CyrensDbContext> options)
            : base(options)
        { }

        //public DbSet<Persons> Persons { get; set; }
        //public DbSet<Stories> Stories { get; set; }
        public DbSet<Users> Users { get; set; }

        //public DbSet<Persons> Persons { get; set; }
        public DbSet<CyrensService.Models.Stories> Stories { get; set; }
        public DbSet<CyrensService.Models.Persons> Persons { get; set; }
        //public DbSet<UMLExcercises> UMLExcercises { get; set; }
        
    }
}
