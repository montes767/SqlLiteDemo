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

    public class ApiCustomerRepository<T> : IBaseRepository<Customer> where T : TableData, new()
    {
        public void Delete(Customer item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAll(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Customer? GetByExpression(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Customer? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
