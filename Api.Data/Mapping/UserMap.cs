using Api.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("TB_USER");

            builder.HasKey(p => p.Id);

            builder.HasIndex(p => p.Cpf)
                    .IsUnique();

            builder.Property(u => u.Name)
                    .IsRequired()
                    .HasColumnName("nm_name")
                    .HasMaxLength(60);

            builder.Property(u => u.Cpf)
                    .IsRequired()
                    .HasColumnName("ds_cpf")
                    .HasMaxLength(11);

            builder.Property(u => u.Email)
                    .IsRequired()
                    .HasColumnName("ds_email")
                    .HasMaxLength(100);

            builder.Property(u => u.CreateAt)
                    .IsRequired()
                    .HasColumnName("dt_create");

            builder.Property(u => u.UpdateAt)
                    .HasColumnName("dt_update");
        }
    }
}
