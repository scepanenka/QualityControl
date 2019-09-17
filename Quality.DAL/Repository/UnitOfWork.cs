using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Quality.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quality.DAL.Repository
{
    public class UnitOfWork : IDisposable
    {
        private DbContext _context;
        private bool _disposed;
        private IRepository<Order> _ordersRepository;
        private IRepository<Employee> _employeesRepository;
        private IRepository<Organization> _orgnizationsRepository;
        private IRepository<Position> _positionsRepository;

        public IRepository<Order> OrdersRepository
        {
            get
            {
                if (_ordersRepository == null)
                    _ordersRepository = new Repository<Order>(_context);
                return _ordersRepository;
            }
        }

        public IRepository<Employee> EmployeeRepository
        {
            get
            {
                if (_employeesRepository == null)
                    _employeesRepository = new Repository<Employee>(_context);
                return _employeesRepository;
            }
        }

        public IRepository<Organization> OrganizationRepository
        {
            get
            {
                if (_orgnizationsRepository == null)
                    _orgnizationsRepository = new Repository<Organization>(_context);
                return _orgnizationsRepository;
            }
        }

        public IRepository<Position> PositionRepository
        {
            get
            {
                if (_positionsRepository == null)
                    _positionsRepository = new Repository<Position>(_context);
                return _positionsRepository;
            }
        }

        public UnitOfWork(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException("Context was not supplied");
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
