namespace HackYeah.Domain;

internal interface IAggregateBase
{
    public Guid Id { get; init; }
}