using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemasDeReceitasMiniChefeAPI.Models;

namespace SistemasDeReceitasMiniChefeAPI.Data.Map
{
    public class ReceitaMap : IEntityTypeConfiguration<ReceitaModel>
    {


        public void Configure(EntityTypeBuilder<ReceitaModel> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.titulo).HasMaxLength(255);
            builder.Property(x => x.descricao).HasMaxLength(10000);
            builder.Property(x => x.ingredientes);
            builder.Property(x => x.preparo);
            //builder.Property(x => x.imagem);

        }


    }
}
