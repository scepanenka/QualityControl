using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quality.DAL.Entities;
using Quality.DAL.Repository;

namespace QualityControl.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public EmployeesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Employees
        public IActionResult Index()
        {
            var employees = _unitOfWork.GetEmployeeRepository.GetAll();
            return View(employees);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _unitOfWork.GetEmployeeRepository.GetByIdAsync((int)id);
            if (employee == null)
            {
                return NotFound();
            }

            return PartialView(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["IdPosition"] = new SelectList(_unitOfWork.GetPositionRepository.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GetEmployeeRepository.Insert(employee);
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPosition"] = new SelectList(_unitOfWork.GetPositionRepository.GetAll(), "Id", "Id", employee.IdPosition);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _unitOfWork.GetEmployeeRepository.GetByIdAsync((int) id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["IdPosition"] = new SelectList(_unitOfWork.GetPositionRepository.GetAll(), "Id", "Name", employee.IdPosition);
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.GetEmployeeRepository.Update(employee);
                    await _unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPosition"] = new SelectList(_unitOfWork.GetPositionRepository.GetAll(), "Id", "Id", employee.IdPosition);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _unitOfWork.GetEmployeeRepository.GetByIdAsync((int) id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _unitOfWork.GetEmployeeRepository.GetByIdAsync(id);
            _unitOfWork.GetEmployeeRepository.Delete(employee);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            var employee = _unitOfWork.GetEmployeeRepository.GetByIdAsync(id);
            if (employee != null)
                return true;
            return false;
        }
    }
}
