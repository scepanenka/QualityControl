using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Quality.DAL.Entities;

namespace Quality.DAL.Repository
{
    public class OrderRepository : Repository<Order>
    {
        private readonly DbContext _context;
        public OrderRepository(DbContext dataContext) : base(dataContext)
        {
            _context = dataContext;
        }

        public IQueryable<Order> GetAllOrders()
        {
            return _context.Set<Order>().Include(e => e.Employee.Name).Include(o => o.Organization.Name);
        }
    }
}
