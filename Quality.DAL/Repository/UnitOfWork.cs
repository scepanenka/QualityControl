﻿using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Quality.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Quality.DAL.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly DbContext _context;
        private bool _disposed;
        private OrderRepository _ordersRepository;
        private EmployeeRepository _employeesRepository;
        private IRepository<Organization> _orgnizationsRepository;
        private IRepository<Position> _positionsRepository;
        private IRepository<ClientOrders> _clientOrdersRepository;

        public OrderRepository GetOrderRepository
        {
            get
            {
                if (_ordersRepository == null)
                    _ordersRepository = new OrderRepository(_context);
                return _ordersRepository;
            }
        }

        public EmployeeRepository GetEmployeeRepository
        {
            get
            {
                if (_employeesRepository == null)
                    _employeesRepository = new EmployeeRepository(_context);
                return _employeesRepository;
            }
        }

        public IRepository<Organization> GetOrganizationRepository
        {
            get
            {
                if (_orgnizationsRepository == null)
                    _orgnizationsRepository = new Repository<Organization>(_context);
                return _orgnizationsRepository;
            }
        }

        public IRepository<Position> GetPositionRepository
        {
            get
            {
                if (_positionsRepository == null)
                    _positionsRepository = new Repository<Position>(_context);
                return _positionsRepository;
            }
        }


        public IRepository<ClientOrders> GetClientOrdersRepository
        {
            get
            {
                if (_clientOrdersRepository == null)
                    _clientOrdersRepository = new Repository<ClientOrders>(_context);
                return _clientOrdersRepository;
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
