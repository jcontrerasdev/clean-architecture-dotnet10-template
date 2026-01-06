namespace Nanabills.Application.Common.Interfaces;

public interface IUnitOfWork
{
    Task<int> CommitChangesAsync();
}