using BankSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace BankSystem.Data;
public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> accountBuilder)
    {
        accountBuilder
            .ToTable("Accounts");

        accountBuilder
            .HasKey(account => account.AccountId);

        accountBuilder
            .Property(account => account.AccountId)
            .ValueGeneratedNever();

        accountBuilder
            .Property<string>(account => account.Name)
            .HasMaxLength(60);

        accountBuilder
            .Property<string>(account => account.Cpf)
            .HasMaxLength(11);

        accountBuilder
            .Property<string>(account => account.Password)
            .HasMaxLength(20);

        accountBuilder
            .Property<float>(account => account.Balance);

    }
}
