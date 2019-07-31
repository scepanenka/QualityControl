using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Quality.DAL.Entities;
using Quality.DAL.Repository;

namespace QualityControl.Controllers
{   
    public class OrdersController : Controller    {        
        private static TestDBContext _context;
        private UnitOfWork _unitOfWork;
        private IRepository<Order> _repository;

        public OrdersController(TestDBContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
            _repository = _unitOfWork.OrdersRepository;
        }

        public ActionResult Index()
        {
            return View(_unitOfWork.OrdersRepository.GetAll());
        }        
    }
}