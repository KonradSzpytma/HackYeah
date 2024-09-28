namespace HackYeah.App;

public class TransactionMessage(Guid userId, decimal amount): IMessage
{
    public static TransactionMessage Create(Guid userId, decimal amount) => new(userId, amount);
    public Guid UserId { get; set; } = userId;
    public decimal Amount { get; set; } = amount;
    public Guid MessageId { get; init; }
}