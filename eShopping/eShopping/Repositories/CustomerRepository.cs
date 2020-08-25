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

        public CustomerRepository(ShoppingDbContext context)
        {
            this.context = context;
        }
        public async Task<Customer> CreateAsync(Customer entity)
        {
            var res = await context._Customer.AddAsync(entity);
            await context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cust = await context._Customer.FindAsync(id);
            if (cust == null) return false;

            context._Customer.Remove(cust);
            context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Customer>> GetAsync()
        {
            return await context._Customer.ToListAsync();
        }

        public async Task<Customer> GetAsync(int id)
        {
            return await context._Customer.FindAsync(id);
        }

        public async Task<Customer> UpdateAsync(int id, Customer entity)
        {
            var cat = await context._Customer.FindAsync(id);
            if (cat != null)
            {
                cat.CustomerId = entity.CustomerId;
                cat.CustomerName = entity.CustomerName;
                cat.CustomerDOB = entity.CustomerDOB;
                cat.CustomerEmailAddress = entity.CustomerEmailAddress;
                cat.CustomerPhoneNumber = entity.CustomerPhoneNumber;
                cat.CustomerAddress = entity.CustomerAddress;
                await context.SaveChangesAsync();
                return cat;
            }
            return entity;
        }
    }
}
