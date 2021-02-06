using Api.Domain.Entities.CurrentAccount;
using Api.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CurrentAccountMap : IEntityTypeConfiguration<CurrentAccountEntity>
    {
        public void Configure(EntityTypeBuilder<CurrentAccountEntity> builder)
        {
            builder.ToTable("TB_CURRENT_ACCOUNT");

            builder.HasKey(c => c.Id);

            builder.HasIndex(c => c.UserId)
                .IsUnique();

            builder.Property(c => c.UserId)
                .IsRequired()
                .HasColumnName("id_user");

            builder.Property(c => c.Balance)
                .IsRequired()
                .HasColumnName("vl_balance")
                .HasColumnType("decimal(10,2)");

            builder.Property(c => c.CreateAt)
                .IsRequired()
                .HasColumnName("dt_create");

            builder.Property(c => c.UpdateAt)
                .HasColumnName("dt_update");
        }
    }
}
