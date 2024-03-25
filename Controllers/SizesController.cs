using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GundamStore.Datas;
using GundamStore.Models;

namespace GundamStore.Controllers
{
    public class SizesController : Controller
    {
        private readonly GundamStoreDBContext _context;

        public SizesController(GundamStoreDBContext context)
        {
            _context = context;
        }

        // GET: Sizes
        public async Task<IActionResult> Index()
        {
            if (_context.Sizes != null)
            {
                var sizes = await _context.Sizes
                                            .Where(s => s.DeleteFlag == false)
                                            .ToListAsync();

                return View(sizes);
            }
            else
            {
                return Problem("Entity set 'GundamStoreDBContext.Banners' is null.");
            }
        }

        // POST: Sizes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Size size)
        {
            if (ModelState.IsValid)
            {
                size.CreateAt = DateTime.Now;
                size.UpdateAt = DateTime.Now;
                
                // Size.CreateBy = GetCurrentUser();
                // Size.UpdateBy = GetCurrentUser();
                
                size.DeleteFlag = false;
                
                _context.Add(size);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NoContent();
        }

        // GET: Sizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sizes == null)
            {
                return NotFound();
            }

            var size = _context.Sizes.FirstOrDefault(c => c.Id == id);

            if (size == null)
            {
                return NotFound(); // Or return appropriate error response
            }

            return Json(size);
        }


        private async Task<IActionResult> UpdateSize(Size size)
        {
            try
            {
                size.UpdateAt = DateTime.Now;
                //size.UpdateBy = GetCurrentUser();

                _context.Update(size);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SizeExists(size.Id))
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
        
        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Size size)
        {
            
            if (id != size.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingSize = await _context.Sizes.FindAsync(id);
                if (existingSize == null)
                {
                    return NotFound();
                }

                existingSize.Name = size.Name;

                await UpdateSize(existingSize);
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var size = await _context.Sizes.FindAsync(id);
            if (size == null)
            {
                return NotFound();
            }

            size.DeleteFlag = true;
            
            await UpdateSize(size);
            return NoContent();
        }
        private bool SizeExists(int id)
        {
          return (_context.Sizes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
