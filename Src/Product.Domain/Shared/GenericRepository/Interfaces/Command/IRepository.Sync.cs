using Product.Domain.Shared.Base;

namespace Product.Domain.Shared.GenericRepository.GenericRepository.Command;

public partial interface IRepository<T> where T : IAggregateRoot
{
    void RollbackTransaction();
    void CommitTransaction();
    void Add(T model);
    void AddRange(IEnumerable<T> models);
    void Update(T model);
    void UpdateRange(IEnumerable<T> models);
    void Delete(long id);
    void Delete(T model);
    void DeleteRange(IEnumerable<T> models);

    void ClearChangeTracker();


}