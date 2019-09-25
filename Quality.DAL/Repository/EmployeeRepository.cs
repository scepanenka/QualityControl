using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using Quality.DAL.Entities;

namespace Quality.DAL.Repository
{
    public class EmployeeRepository : Repository<Employee>
    {
        private DbContext _context;
        public EmployeeRepository(DbContext dataContext) : base(dataContext)
        {
            _context = dataContext;
        }

        public override IEnumerable<Employee> GetAll()
        {
            return _context.Set<Employee>().Include(e=>e.Position).ToList();
        }
    }
}
