using SQLite;
using SqlLiteDemo.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteDemo.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : TableData, new()
    {
        /// <summary>
        /// Connection to database
        /// </summary>
        private SQLiteConnection _connection = 
            new SQLiteConnection(Constants.DatabasePath, Constants.flags);

        public string StatusMessage { get; set; }= string.Empty;

        public BaseRepository()
        {
            _connection.CreateTable<T>();
        }

        public void Delete(T item)
        {
            try
            {
                _connection.Delete(item);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public List<T> GetAll()
        {
            
                return _connection.Table<T>().ToList();
           
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            
                return _connection.Table<T>().Where(predicate).ToList();
           
        }

        public T GetByExpression(Expression<Func<T, bool>> predicate)
        {
            return _connection.Table<T>().Where(predicate).FirstOrDefault(); 
        
        }

        public T GetById(int id)
        {
            return _connection.Table<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Save(T item)
        {
            try
            {
                if (item.Id == 0)
                {
                    int rows = _connection.Insert(item);
                    StatusMessage = $"Added: {rows}";
                }
                else
                {
                    int rows = _connection.Update(item);
                    StatusMessage = $"Updated: {rows}";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex}";

            }
        }
    }

}
