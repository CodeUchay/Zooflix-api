using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zooflix.Models;

namespace Zooflix.Data
{
    public class ZooflixContext : DbContext
    {
        public ZooflixContext (DbContextOptions<ZooflixContext> options)
            : base(options)
        {
        }

        public DbSet<Zooflix.Models.Movie> Movie { get; set; } = default!;

        public DbSet<Zooflix.Models.Star>? Star { get; set; }

        public DbSet<Zooflix.Models.User>? User { get; set; }

        public DbSet<Zooflix.Models.Order>? Order { get; set; }
    }
}
