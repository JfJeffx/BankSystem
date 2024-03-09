using BankSystem.Data;
using BankSystem.InterfaceFuncs;
namespace BankSystem.UseCases.AccountUseCases;
public class LoginAccount
{
    public static string Login()
    {
        while (true)
        {
            Interface.Line();
            Console.Write("CPF: ");
            var cpf = Console.ReadLine();

            Interface.Line();
            Console.Write("Password: ");
            var password = Console.ReadLine();

            var account = new DataContext().Accounts.FirstOrDefault(x => x.Cpf == cpf);
            if (account?.Password == password)
            { 
                Console.WriteLine("Login made successfully!");
                return cpf!;
            }
            Console.WriteLine("Your CPF or password is wrong, check and try again");
        }
    }
}
