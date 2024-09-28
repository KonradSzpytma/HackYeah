namespace HackYeah.App;

public class TransactionConsumer : IMessageConsumer<TransactionMessage>
{
    public void Consume(TransactionMessage message)
    {
        Console.WriteLine($"Processing transaction for UserId: {message.UserId}, Amount: {message.Amount}");
    }
}