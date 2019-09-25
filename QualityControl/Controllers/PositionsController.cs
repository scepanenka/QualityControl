using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quality.DAL.Entities;
using Quality.DAL.Repository;

namespace QualityControl.Controllers
{
    public class PositionsController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public PositionsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Positions
        public async Task<IActionResult> Index()
        {
            var positions = await _unitOfWork.GetPositionRepository.GetAllAsync();
            return View(positions);
        }

        // GET: Positions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _unitOfWork.GetPositionRepository.GetByIdAsync((int)id);
                
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // GET: Positions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Positions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Position position)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.GetPositionRepository.Insert(position);
                await _unitOfWork.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(position);
        }

        // GET: Positions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _unitOfWork.GetPositionRepository.GetByIdAsync((int)id);
            if (position == null)
            {
                return NotFound();
            }
            return View(position);
        }

        // POST: Positions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Position position)
        {
            if (id != position.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.GetPositionRepository.Update(position);
                    await _unitOfWork.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionExists(position.Id))
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
            return View(position);
        }

        // GET: Positions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var position = await _unitOfWork.GetPositionRepository.GetByIdAsync((int)id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var position = await _unitOfWork.GetPositionRepository.GetByIdAsync(id);
            _unitOfWork.GetPositionRepository.Delete(position);
            await _unitOfWork.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PositionExists(int id)
        {
            var position = _unitOfWork.GetPositionRepository.GetByIdAsync(id);
            if (position != null)
                return true;
            return false;
        }
    }
}
