namespace Nanabills.Application.Common.Interfaces;

public interface IUserRepository
{
    Task<bool> ExistsAsync(Guid userId);
}
