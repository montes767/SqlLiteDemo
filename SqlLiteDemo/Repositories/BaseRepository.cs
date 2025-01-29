using SQLite;
using SQLiteNetExtensions.Extensions;
using SqlLiteDemo.Abstractions;
using SqlLiteDemo.MVVM.Models;
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
        private static SQLiteConnection _connection;
            
        static BaseRepository(){
           _connection= new SQLiteConnection(Constants.DatabasePath, Constants.flags);
         





        public string StatusMessage { get; set; }= string.Empty;

        public BaseRepository()
        {
            _connection.CreateTable<T>();
            _connection.CreateTable<CustomerPassport>();
        }

        public void Delete(T item, bool recursive= true)
        {
            try
            {
                _connection.Delete(item, recursive);
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

            return _connection.GetAllWithChildren<T>();
           
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

        public void SaveWithChildren(T item, bool recursive=false)
        {
            try
            {
                if (item.Id == 0)
                {
                    _connection.InsertWithChildren(item, recursive);
                    StatusMessage = $"Added: ";
                }
                else
                {
                    _connection.UpdateWithChildren(item);
                    StatusMessage = $"Updated:";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex}";
            }
        
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
