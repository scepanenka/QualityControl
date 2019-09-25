using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quality.DAL.Entities;

namespace QualityControl.Controllers
{
    public class ClientOrdersController : Controller
    {
        private readonly QualityContext _context;

        public ClientOrdersController(QualityContext context)
        {
            _context = context;
        }

        // GET: ClientOrders
        public async Task<IActionResult> Index()
        {
            var qualityContext = _context.ClientOrders.Include(c => c.Client).Include(c => c.Order);
            return View(await qualityContext.ToListAsync());
        }

        // GET: ClientOrders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientOrders = await _context.ClientOrders
                .Include(c => c.Client)
                .Include(c => c.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientOrders == null)
            {
                return NotFound();
            }

            return View(clientOrders);
        }

        // GET: ClientOrders/Create
        public IActionResult Create()
        {
            ViewData["IdClient"] = new SelectList(_context.Clients, "Id", "Id");
            ViewData["IdOrder"] = new SelectList(_context.Orders, "Id", "Id");
            return View();
        }

        // POST: ClientOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdClient,IdOrder")] ClientOrders clientOrders)
        {
            if (ModelState.IsValid)
            {
                clientOrders.Id = Guid.NewGuid();
                _context.Add(clientOrders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdClient"] = new SelectList(_context.Clients, "Id", "Id", clientOrders.IdClient);
            ViewData["IdOrder"] = new SelectList(_context.Orders, "Id", "Id", clientOrders.IdOrder);
            return View(clientOrders);
        }

        // GET: ClientOrders/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientOrders = await _context.ClientOrders.FindAsync(id);
            if (clientOrders == null)
            {
                return NotFound();
            }
            ViewData["IdClient"] = new SelectList(_context.Clients, "Id", "Id", clientOrders.IdClient);
            ViewData["IdOrder"] = new SelectList(_context.Orders, "Id", "Id", clientOrders.IdOrder);
            return View(clientOrders);
        }

        // POST: ClientOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,IdClient,IdOrder")] ClientOrders clientOrders)
        {
            if (id != clientOrders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientOrders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientOrdersExists(clientOrders.Id))
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
            ViewData["IdClient"] = new SelectList(_context.Clients, "Id", "Id", clientOrders.IdClient);
            ViewData["IdOrder"] = new SelectList(_context.Orders, "Id", "Id", clientOrders.IdOrder);
            return View(clientOrders);
        }

        // GET: ClientOrders/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientOrders = await _context.ClientOrders
                .Include(c => c.Client)
                .Include(c => c.Order)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientOrders == null)
            {
                return NotFound();
            }

            return View(clientOrders);
        }

        // POST: ClientOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var clientOrders = await _context.ClientOrders.FindAsync(id);
            _context.ClientOrders.Remove(clientOrders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientOrdersExists(Guid id)
        {
            return _context.ClientOrders.Any(e => e.Id == id);
        }
    }
}
