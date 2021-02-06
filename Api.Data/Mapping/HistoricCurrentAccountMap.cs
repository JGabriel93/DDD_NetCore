using Api.Domain.Entities.CurrentAccount;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class HistoricCurrentAccountMap : IEntityTypeConfiguration<HistoricCurrentAccountEntity>
    {
        public void Configure(EntityTypeBuilder<HistoricCurrentAccountEntity> builder)
        {
            builder.ToTable("TB_HISTORIC_CURRENT_ACCOUNT");

            builder.HasKey(h => h.Id);

            builder.Property(h => h.CurrentAccountId)
                .IsRequired()
                .HasColumnName("id_current_account");

            builder.Property(h => h.Movement)
                .IsRequired()
                .HasColumnName("ds_movement")
                .HasMaxLength(1);

            builder.Property(h => h.AmountMoved)
                .IsRequired()
                .HasColumnName("vl_amount_moved")
                .HasColumnType("decimal(10,2)");

            builder.Property(h => h.CreateAt)
                .IsRequired()
                .HasColumnName("dt_create");

            builder.Property(c => c.UpdateAt)
                .HasColumnName("dt_update");

            builder.HasOne(h => h.CurrentAccount)
                .WithMany(c => c.Historic)
                .HasForeignKey(h => h.CurrentAccountId);
        }
    }
}
