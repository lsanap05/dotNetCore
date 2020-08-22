using eShopping.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopping.Repositories
{
    public class CustomerRepository : IRepository<Customer, int>
    {
        private readonly ShoppingDbContext context;
        public async Task<Customer> CreateAsync(Customer entity)
        {
            //var res = await context._Customer.AllAsync(entity);
            //await context.SaveChangesAsync();
            //return res.Entity;
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> UpdateAsync(int id, Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
