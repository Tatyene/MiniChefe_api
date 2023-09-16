using Microsoft.EntityFrameworkCore;
using SistemasDeReceitasMiniChefeAPI.Data.Map;
using SistemasDeReceitasMiniChefeAPI.Models;

namespace SistemasDeReceitasMiniChefeAPI.Data
{
    public class SistemaReceitasDbContex : DbContext
    {
        public SistemaReceitasDbContex(DbContextOptions<SistemaReceitasDbContex>options) : base(options)
        {

        }

        public DbSet<ReceitaModel> receita { get; set; }
        public DbSet<UsuarioModel> usuario { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>().ToTable("usuario");
            modelBuilder.Entity<ReceitaModel>().ToTable("receita");
           
        }
    }
}
