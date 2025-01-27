using System.Linq.Expressions;

namespace SqlLiteDemo.Abstractions
{
    public interface IBaseRepository<T> : IDisposable where T : TableData, new()
    {
        void Save(T item);
        void Delete(T item);
        T? GetById(int id);
        T? GetByExpression(Expression<Func<T, bool>> predicate);
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate);
    }
}
