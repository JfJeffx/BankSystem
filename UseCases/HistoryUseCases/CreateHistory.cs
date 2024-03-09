using BankSystem.Data;
using BankSystem.Models;
namespace BankSystem.UseCases.HistoryUseCases;
public class CreateHistory
{
    public static void Create(string option, float value, DataContext db, Account sentAccount, Account receivedAccount = null!)
    {
        History history = new();
        if (receivedAccount != null)
        {
            history = new()
            {
                Option = option,
                Value = value,
                Sent = db.Accounts.First(x => x.Cpf == sentAccount.Cpf),
                Received = db.Accounts.First(x => x.Cpf == receivedAccount.Cpf)
            };
        }
        else
        {
            history = new()
            {
                Option = option,
                Value = value,
                Sent = db.Accounts.First(x => x.Cpf == sentAccount.Cpf),
                Received = null
            };
        }
        db.Histories.Add(history);
        db.SaveChanges();
    }
}
