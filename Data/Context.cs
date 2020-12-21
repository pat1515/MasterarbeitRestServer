using Microsoft.EntityFrameworkCore;
using MasterarbeitRestServer.Models;

namespace MasterarbeitRestServer.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
               modelBuilder.Entity<Buch>()
                    .HasOne(_ => _.Autor)
                    .WithMany(_ => _.Buchs)
                    .HasForeignKey(_ => _.AUTOR_ID);
            */
        }
        
        
        public DbSet<Autor> AUTOR { get; set; }

        public DbSet<Buch> BUCH { get; set; }

    }
}