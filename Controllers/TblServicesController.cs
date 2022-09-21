using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrgOffering.Data;
using OrgOffering.Models;
using OrgOffering.Repository;

namespace OrgOffering.Controllers
{
    public class TblServicesController : Controller
    {
        private readonly GTMContext _context;

        public TblServicesController(GTMContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            tblServiceRepository tblServiceRepository = new tblServiceRepository();

            var results = tblServiceRepository.GetAll();

            return View(results);
        }

        // GET: TblServices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblService = await _context.TblService
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (tblService == null)
            {
                return NotFound();
            }

            return View(tblService);
        }

        // GET: TblServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceId,ServiceName,ServiceDescription,CreatedDate")] TblService tblService)
        {
            if (ModelState.IsValid)
            {
                tblService.ServiceId = Guid.NewGuid();
                _context.Add(tblService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblService);
        }

        // GET: TblServices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblService = await _context.TblService.FindAsync(id);
            if (tblService == null)
            {
                return NotFound();
            }
            return View(tblService);
        }

        // POST: TblServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ServiceId,ServiceName,ServiceDescription,CreatedDate")] TblService tblService)
        {
            if (id != tblService.ServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblServiceExists(tblService.ServiceId))
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
            return View(tblService);
        }

        // GET: TblServices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblService = await _context.TblService
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (tblService == null)
            {
                return NotFound();
            }

            return View(tblService);
        }

        // POST: TblServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblService = await _context.TblService.FindAsync(id);
            _context.TblService.Remove(tblService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblServiceExists(Guid id)
        {
            return _context.TblService.Any(e => e.ServiceId == id);
        }
    }
}
