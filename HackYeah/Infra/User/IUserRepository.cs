namespace HackYeah.Infra.User;

public interface IUserRepository
{
    Guid AddUser(UserEntity? user);
    UserEntity? GetUser(Guid id);
    void UpdateBalance(Guid id, decimal amount);
}

public class UserEntity
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public decimal Balance { get; set; }
}