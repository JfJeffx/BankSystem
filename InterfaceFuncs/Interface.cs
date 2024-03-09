using BankSystem.Data;
using BankSystem.Models;

namespace BankSystem.InterfaceFuncs;
public class Interface
{
    public static void Line()
    {
        for (int i = 0; i < 50; i += 1)
        {
            Console.Write("═");
        }
        Console.WriteLine();
    }

    private static void Top(string text)
    {
        Console.Write("╔");
        for (int i = 0; i < text.Length + 10; i += 1)
        {
            Console.Write("═");
        }
        Console.WriteLine("╗");
        Console.WriteLine($"║     {text.ToUpper()}     ║");
    }

    private static void Floor(string text)
    {
        Console.Write("╚");
        for (int i = 0; i < text.Length + 10; i += 1)
        {
            Console.Write("═");
        }
        Console.WriteLine("╝");
    }

    private static void Header(string text)
    {
        Console.Clear();
        Top(text);
        Floor(text);
    }

    public static string Options(string headerText, string[] optionsList, string cpf = "")
    {
        Header(headerText);
        if (cpf != "") Console.WriteLine($"Balance: {new DataContext().Accounts.First(x => x.Cpf == cpf).Balance:C}");
        int num = 1;
        foreach (var item in optionsList)
        {
            Console.WriteLine($"{num} - {item}");
            num += 1;
        }
        Console.Write("Your option: ");
        var option = Console.ReadLine();
        return option!;
    }
}
