using FluentAssertions;
using HackYeah.App;
using HackYeah.Domain.User;
using JetBrains.Annotations;

namespace HackHeah.UnitTest.Domain.User;

[TestSubject(typeof(UserAggregate))]
public class UserAggregateTest
{
    [Fact]
    public void X()
    {
        var messageBus = GetEventBus();

        var userAggregate = new UserAggregate("email.email@test.pl", "John", "Doe", 0, messageBus);
        userAggregate.Deposit(100);

        var consumedMessages = messageBus.GetConsumedMessages();
        consumedMessages.Count.Should().Be(1);
    }

    private static MessageBus GetEventBus()
    {
        var messageBus = new MessageBus();
        var transactionConsumer = new TransactionConsumer();
        messageBus.Subscribe(transactionConsumer);
        return messageBus;
    }
}