using DataAccess.Repository;
using Quality.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quality.DAL.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        OrderRepository GetOrderRepository { get;  }
        EmployeeRepository GetEmployeeRepository { get; }
        IRepository<Organization> GetOrganizationRepository { get; }
        IRepository<Position> GetPositionRepository { get; }
        IRepository<ClientOrders> GetClientOrdersRepository { get; }
        
    }
}
