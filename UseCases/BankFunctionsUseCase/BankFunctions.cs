using BankSystem.Data;
using BankSystem.InterfaceFuncs;
using BankSystem.Models;
using BankSystem.UseCases.HistoryUseCases;
namespace BankSystem.UseCases.BankFunctionsUseCase;
public class BankFunctions
{
    public static void Deposit(Account account)
    {
        while (true)
        {
            try
            {
                Interface.Line();
                Console.Write("Value: ");
                float value = float.Parse(Console.ReadLine()!);

                if (value < 0.01) 
                    Console.WriteLine("The value does not less than $0.01");
                else if (value > 5000.00) 
                    Console.WriteLine($"The max value of deposit is $5000.00");
                else 
                {
                    using var db = new DataContext();
                    db.Accounts.First(x => account.Cpf == x.Cpf).Balance += value;
                    CreateHistory.Create("Deposit", value, db, account);
                    Console.WriteLine("Deposit made successfully");
                    Thread.Sleep(3000);
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Type only numbers");
                continue;
            }
        }
    }

    public static void Withdraw(Account account)
    {
        while (true)
        {
            try
            {
                using var db = new DataContext();
                Interface.Line();

                Console.Write("Value: ");
                float value = float.Parse(Console.ReadLine()!);

                if (value < 0.01)
                    Console.WriteLine("The value don't can less than $0.01");
                else if (db.Accounts.First(x => account.Cpf == x.Cpf).Balance - value < 0)
                    Console.WriteLine("The withdraw value exceeds the balance");
                else
                {
                    db.Accounts.First(x => account.Cpf == x.Cpf).Balance -= value;
                    CreateHistory.Create("Withdraw", value, db, account);
                    Console.WriteLine("Withdraw made successfully");
                    Thread.Sleep(3000);
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Type only numbers");
                continue;
            }
        }
    }

    public static void Transfer(Account account)
    {
        Account destinationAccount = new();
        using var db = new DataContext();
        while (true)
        {
            Interface.Line();

            Console.Write("Destination CPF: ");
            destinationAccount.Cpf = Console.ReadLine()!;

            if (db.Accounts.FirstOrDefault(x => x.Cpf == destinationAccount.Cpf && destinationAccount.Cpf != account.Cpf) is null)
            { 
                Console.WriteLine("CPF don't found, check and try again");
                continue;
            }
            break;
        }
        while (true)
        {
            try
            {
                Interface.Line();

                Console.Write("Value: ");
                float value = float.Parse(Console.ReadLine()!);

                if (value < 0.01)
                    Console.WriteLine("The value don't can less than $0.01");
                else if (value > 5000.00)
                    Console.WriteLine($"The max value of transfer is $5000.00"); 
                else if (db.Accounts.First(x => x.Cpf == account.Cpf).Balance - value < 0)
                    Console.WriteLine("The value of transfer exceeds the balance");
                else 
                { 
                    db.Accounts.First(x => x.Cpf == account.Cpf).Balance -= value;
                    db.Accounts.First(x => x.Cpf == destinationAccount.Cpf).Balance += value;
                    CreateHistory.Create("Transfer", value, db, account, destinationAccount);
                    Console.WriteLine("Transfer made successfully");
                    Thread.Sleep(3000);
                    break; 
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Type only numbers");
                continue;
            }
        }
    }
}
