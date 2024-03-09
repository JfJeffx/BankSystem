namespace BankSystem.Models;
public class History
{
    public int HistoryId { get; set; }
    public string Option { get; set; } = string.Empty;
    public float Value { get; set; }
    public virtual Account? Sent { get; set; }
    public virtual Account? Received { get; set; }
}
