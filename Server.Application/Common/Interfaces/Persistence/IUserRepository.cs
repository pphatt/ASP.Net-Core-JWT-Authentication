using Server.Domain.Entity.Identity;

namespace Server.Application.Common.Interfaces.Repositories;

public interface IUserRepository
{
    AppUsers? GetUserByEmail(string email);
    void AddUser(AppUsers user);
}
