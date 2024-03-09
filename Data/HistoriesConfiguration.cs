using BankSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BankSystem.Data;
public class HistoriesConfiguration : IEntityTypeConfiguration<History>
{
    public void Configure(EntityTypeBuilder<History> historiesBuilder)
    {
        historiesBuilder
            .ToTable("Histories");

        historiesBuilder
            .HasKey(history => history.HistoryId);

        historiesBuilder
            .Property(history => history.HistoryId)
            .ValueGeneratedNever();

        historiesBuilder
            .Property<string>(history => history.Option);

        historiesBuilder
            .Property<float>(history => history.Value);

        historiesBuilder
            .HasOne(history => history.Sent)
            .WithOne()
            .HasForeignKey<Account>(account => account.AccountId)
            .IsRequired();

        historiesBuilder
            .HasOne(history => history.Received)
            .WithOne()
            .HasForeignKey<Account>(account => account.AccountId);
    }
}
