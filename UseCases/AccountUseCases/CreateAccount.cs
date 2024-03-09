using BankSystem.Models;
using BankSystem.Data;
using BankSystem.InterfaceFuncs;
namespace BankSystem.UseCases.AccountUseCases;
public class CreateAccount
{
    public static string Create()
    {
        Account account = new();
        while (true)
        {
            Interface.Line();
            Console.Write("Full name: ");
            var name = Console.ReadLine();
            try
            {
                if (name!.Length < 8) 
                { 
                    Console.WriteLine("Your name must have 8 characters");
                    continue; 
                }
                else if (name!.Length > 60)
                {
                    Console.WriteLine("Your name length is greater than 60");
                }
            }
            finally { account.Name = name!; }
            break;
        }
        using var db = new DataContext();
        while (true)
        {
            Interface.Line();
            Console.Write("CPF: ");
            var cpf = Console.ReadLine();
            try
            {
                if (cpf!.Length != 11)
                {
                    Console.WriteLine("Your CPF must have 11 numbers");
                    continue;
                }
                else if (!Int64.TryParse(cpf, out _))
                {
                    Console.WriteLine("Your CPF must have 11 numbers");
                    continue;
                }
                else if (db.Accounts.FirstOrDefault(x => x.Cpf == cpf)?.Cpf is not null)
                {
                    Console.WriteLine("This CPF is already used");
                    continue;
                }
            }
            finally { account.Cpf = cpf!; }
            break;
        }
        while (true)
        {
            Interface.Line();
            Console.Write("Password: ");
            var password = Console.ReadLine();
            try
            {
                if (password!.Length < 8)
                {
                    Console.WriteLine("Your password must have 8 characters");
                    continue; 
                }
                else if (password!.Length > 20)
                {
                    Console.WriteLine("Your password length is greater than 20");
                }
            }
            finally { account.Password = password!; }
            break;
        }
        db.Accounts.Add(account);
        db.SaveChanges();
        return account.Cpf;
    }
}
