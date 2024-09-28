namespace HackYeah.App;

public interface IMessageConsumer<in T>
{
    void Consume(T message);
}