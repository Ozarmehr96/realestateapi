namespace Ijora.Domain.Infrastructure
{
    public interface IRepositoryProvider
    {
        T GetRepository<T>() where T : IRepository;
    }
}
