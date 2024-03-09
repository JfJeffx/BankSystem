using BankSystem.Data;
using BankSystem.InterfaceFuncs;
using BankSystem.Models;
using BankSystem.UseCases.AccountUseCases;
using BankSystem.UseCases.BankFunctionsUseCase;
using BankSystem.UseCases.DataUseCases;
namespace BankSystem;
public class Program
{
    public static void Main(string[] args)
    {
        CreateData.DataMigration();
        Account account = new();
        while (true)
        {
            var menuOptionsChoice = Interface.Options("Bank System", ["New account", "Login", "Exit"]);
            switch (menuOptionsChoice)
            {
                case "1": account.Cpf = CreateAccount.Create(); break;
                case "2": account.Cpf =  LoginAccount.Login(); break;
                case "3": Environment.Exit(0); break;
                default: Console.WriteLine("Type only valid options"); continue;
            }
            break;
        }
        while (true)
        {
            var bankFunctionsChoice = Interface.Options("Menu", ["Deposit", "Withdraw", "Transfer", "Exit"], account.Cpf);
            using var db = new DataContext();
            switch (bankFunctionsChoice)
            {
                case "1": BankFunctions.Deposit(db.Accounts.First(x => x.Cpf == account.Cpf)); break;
                case "2": BankFunctions.Withdraw(db.Accounts.First(x => x.Cpf == account.Cpf)); break;
                case "3": BankFunctions.Transfer(db.Accounts.First(x => x.Cpf == account.Cpf)); break;
                case "4": Environment.Exit(0); break;
                default: Console.WriteLine("Type only valid options"); continue;
            }
        }
    }
}