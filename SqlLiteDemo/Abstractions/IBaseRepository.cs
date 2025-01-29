using System.Linq.Expressions;

namespace SqlLiteDemo.Abstractions
{
    public interface IBaseRepository<T> : IDisposable where T : TableData, new()
    {
        void Save(T item);
        void SaveWithChildren(T item, bool recursive = false);
        void Delete(T item, bool recursive= true);
        T? GetById(int id);
        T? GetByExpression(Expression<Func<T, bool>> predicate);
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate);

    }
}
