using HackYeah.App;
using HackYeah.Infra.User;

namespace HackYeah.Domain.User;

public class UserAggregate : IAggregateBase
{
    private readonly string _email;
    private readonly string _firstName;
    private readonly string _lastName;
    private readonly MessageBus _messageBus;

    public UserAggregate(string email, string firstName, string lastName, decimal currentBalance, MessageBus messageBus)
    {
        Id = Guid.NewGuid();
        _email = email;
        _firstName = firstName;
        _lastName = lastName;
        Balance = currentBalance;
        _messageBus = messageBus;
    }

    private decimal Balance { get; }

    public Guid Id { get; init; }

    public string GetFullName()
    {
        return $"{_firstName} {_lastName}";
    }

    public string GetEmail()
    {
        return _email;
    }

    public void Charge(decimal amount)
    {
        if (Balance < amount)
            throw new InvalidOperationException("Insufficient balance.");

        var message = new TransactionMessage(Id, amount);
        _messageBus.Publish(message);
    }

    public void Deposit(decimal amount)
    {
        if (amount < 0)
            throw new InvalidOperationException("Deposit amount must be positive.");

        var message = TransactionMessage.Create(Id, amount);
        _messageBus.Publish(message);
    }
}