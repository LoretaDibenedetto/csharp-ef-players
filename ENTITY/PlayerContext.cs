using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public  class PlayerContext:DbContext
    {
        public DbSet<Player> Player { get; set; }
        public DbSet<Team> Teamer { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=EfPlayer;" +
                "Integrated Security=True;TrustServerCertificate=True");
        }
    }
}

