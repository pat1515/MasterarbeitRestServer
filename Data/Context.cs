using Microsoft.EntityFrameworkCore;
using MasterarbeitRestServer.Models;

namespace MasterarbeitRestServer.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> opt) : base(opt)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buch>().HasOne<Autor>(b => b.AUTOR).WithMany(a => a.BUECHER).HasForeignKey(s => s.AUTOR_ID);
        }
        
        
        public DbSet<Autor> AUTOR { get; set; }

        public DbSet<Buch> BUCH { get; set; }

    }
}