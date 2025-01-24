using SQLite;
using SqlLiteDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLiteDemo.Repositories
{
    public class CustomerRepository
    {
        private SQLiteConnection _connection = new SQLiteConnection(Constants.DatabasePath, Constants.flags);

        public string StatusMessage { get; set; }
        public CustomerRepository()
        {
            _connection.CreateTable<Customer>();
        }

        public void AddOrUpdate(Customer customer)
        {
            try
            {
                if (customer.Id == 0)
                {
                    int rows = _connection.Insert(customer);
                    StatusMessage = $"Added: {rows}";
                }
                else
                {
                    int rows = _connection.Update(customer);
                    StatusMessage = $"Updated: {rows}";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex}";

            }
        }
        public List<Customer>? GetAll(Func<Customer, bool> value)
        {
            try
            {
                return _connection.Table<Customer>().Where(value).ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex}";
            }
            return null;
        }
        public List<Customer>? GetAll()
        {
            try
            {
                return _connection.Table<Customer>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex}";
            }
            return null;
        }

        public List<Customer> GettbyQuery()
        {
            return _connection.Query<Customer>("SELECT * FROM Customer")
                .ToList();
        }

        public Customer? GetById(int id)
        {
            return _connection.Table<Customer>().FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            try
            {
                _connection.Delete<Customer>(id);
            }
            catch(Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }
    }
   
}
