namespace HackYeah.Infra.User;

public interface IUserService
{
    Guid AddUser(UserEntity? user);
    UserEntity? GetUser(Guid id);
    void UpdateBalance(Guid id, decimal amount);
}