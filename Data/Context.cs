using Microsoft.EntityFrameworkCore;
using MasterarbeitRestServer.Models;

namespace MasterarbeitRestServer.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt)
        {
            
        }

        
        public DbSet<Autor> AUTOR { get; set; }

        public DbSet<Buch> Buch { get; set; }

        public DbSet<Rezension> Rezension { get; set; }
    }
}