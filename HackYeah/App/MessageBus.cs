namespace HackYeah.App;

public class MessageBus
{
    private readonly Dictionary<Type, List<object>> _consumers = new();
    private readonly List<IMessage> _consumedMessages = [];
    
    public void Subscribe<T>(IMessageConsumer<T> consumer)
    {
        var messageType = typeof(T);
        if (!_consumers.TryGetValue(messageType, out var value))
        {
            value = [];
            _consumers[messageType] = value;
        }

        value.Add(consumer);
    }

    public void Publish<T>(T message) where T : IMessage
    {
        var messageType = typeof(T);
        if (!_consumers.TryGetValue(messageType, out var consumers)) return;
        foreach (var consumer in consumers) ((IMessageConsumer<T>)consumer).Consume(message);
        _consumedMessages.Add(message);
    }
    
    public List<IMessage> GetConsumedMessages()
    {
        return _consumedMessages;
    }
}