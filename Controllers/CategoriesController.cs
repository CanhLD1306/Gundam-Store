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
    public class CategoriesController : Controller
    {
        private readonly GundamStoreDBContext _context;

        public CategoriesController(GundamStoreDBContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            if (_context.Categories != null)
            {
                var categories = await _context.Categories
                                            .Where(c => c.DeleteFlag == false) // Filter banners with deleteFlag set to false
                                            .ToListAsync();

                return View(categories);
            }
            else
            {
                return Problem("Entity set 'GundamStoreDBContext.Banners' is null.");
            }
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.CreateAt = DateTime.Now;
                category.UpdateAt = DateTime.Now;
                
                // category.CreateBy = GetCurrentUser();
                // category.UpdateBy = GetCurrentUser();
                
                category.DeleteFlag = false;
                
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NoContent();
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound(); // Or return appropriate error response
            }

            return Json(category);
        }


        private async Task<IActionResult> UpdateCategory(Category category)
        {
            try
            {
                category.UpdateAt = DateTime.Now;
                //category.UpdateBy = GetCurrentUser();

                _context.Update(category);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(category.Id))
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Category category)
        {
            
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingCategory = await _context.Categories.FindAsync(id);
                if (existingCategory == null)
                {
                    return NotFound();
                }

                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;

                await UpdateCategory(existingCategory);
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            category.DeleteFlag = true;
            
            await UpdateCategory(category);
            return NoContent();
        }
    

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
