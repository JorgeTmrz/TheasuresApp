using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tarea_Seis_y_Siete.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tesoro> Tesoros { get; set; }
    }
}
