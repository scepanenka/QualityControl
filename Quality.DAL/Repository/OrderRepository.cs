using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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

        public IQueryable GetAllOrdersClients()
        {
            var orders = _context.Set<Order>().Include(e => e.Employee.Name)
                    .Include(o => o.Organization.Name)
                .Join(_context.Set<ClientOrders>(),
                    o => o.Id,
                    c => c.IdOrder,
                    (o, c) => new
                    {
                        OrderNumber = o.Number,
                        DateReciept = o.DateReceipt,
                        DateExecution = o.DateExecution,
                        Employee = o.Employee.Name,
                        Client = c.Client.Surname +' ' + c.Client.Name
                    });
            return orders;
        }
    }
}
