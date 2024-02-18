using Entidades.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entidades.ConfigEntidades
{
    //internal class NoticiaConfiguration : IEntityTypeConfiguration<Noticia>
    //{
    //    public void Configure(EntityTypeBuilder<Noticia> builder)
    //    {
    //        builder.ToTable("Noticias");

    //        builder.HasKey(x => x.Id);

    //        builder.Property(x => x.Titulo)
    //               .IsRequired()
    //               .HasMaxLength(255);

    //        builder.Property(x => x.Informacao)
    //               .IsRequired()
    //               .HasMaxLength(255);

    //        builder.HasOne(c => c.ApplicationUser)
    //              .WithMany(p => p.Noticias)
    //              .HasForeignKey(c => c.UserId);

    //    }
    //}
}
