namespace Product.Domain.Shared.GenericRepository.UnitOfWork;

public interface IUnitOfWork 
{ 
    Task<int> SaveAsync();
    int Save();
    Task DisposeAsync();
    void Dispose();
    Task RollbackTransactionAsync();
    Task CommitTransactionAsync();
}