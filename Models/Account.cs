namespace BankSystem.Models;
public class Account
{
    public string AccountId { get; set; } = Guid.NewGuid().ToString()[..8];
    public string Name { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public float Balance { get; set; } = 0.0f;
}
