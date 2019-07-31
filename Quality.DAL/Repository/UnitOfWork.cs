using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Quality.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quality.DAL.Repository
{
    public class UnitOfWork : IDisposable
    {
        private DbContext _context;
        private bool _disposed;
        private IRepository<Order> _ordersRepository;
        private IRepository<Employer> _employersRepository;
        private IRepository<Organization> _orgnizationsRepository;

        public IRepository<Order> OrdersRepository
        {
            get
            {
                if (_ordersRepository == null)
                    _ordersRepository = new Repository<Order>(_context);
                return _ordersRepository;
            }
        }

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
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
