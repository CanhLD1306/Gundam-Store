using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GundamStore.Datas;
using GundamStore.Models;
using Firebase.Storage;
using Firebase.Auth;

namespace GundamStore.Controllers
{
    public class BannersController : Controller
    {
        private readonly GundamStoreDBContext _context;

        private static string ApiKey = "AIzaSyApy62oQH7xaIKN7U8NmrTwIuxFbfODJ9Y";
        private static string Bucket = "gundam-store-4967f.appspot.com";
        private static string AuthEmail = "canhld1306@gmail.com";
        private static string AuthPassword = "Canhld_Firebase_31148";
        
        public BannersController(GundamStoreDBContext context)
        {
            _context = context;
        }

        // GET: Banners
        public async Task<IActionResult> Index()
        {
            if (_context.Banners != null)
            {
                var banners = await _context.Banners
                                            .Where(b => b.DeleteFlag == false) // Filter banners with deleteFlag set to false
                                            .ToListAsync();

                return View(banners);
            }
            else
            {
                return Problem("Entity set 'GundamStoreDBContext.Banners' is null.");
            }
        }

        // // POST: Banners/Create
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create(Banner banner, IFormFile image)
        // {
            
        // }

        // GET: Banners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Banners == null)
            {
                return NotFound();
            }

            var banner = _context.Banners.FirstOrDefault(b => b.Id == id);

            if (banner == null)
            {
                return NotFound(); // Or return appropriate error response
            }

            return Json(banner);
        }

        // POST: Banners/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image")] Banner banner)
        {
            
            if (id != banner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingBanner = await _context.Banners.FindAsync(id);
                if (existingBanner == null)
                {
                    return NotFound();
                }

                existingBanner.Image = banner.Image;

                await UpdateBanner(existingBanner);
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banner = await _context.Banners.FindAsync(id);
            if (banner == null)
            {
                return NotFound();
            }

            banner.DeleteFlag = true;
            
            await UpdateBanner(banner);
            return NoContent();
        }
    
        private bool BannerExists(int id)
        {
          return (_context.Banners?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task<IActionResult> UpdateBanner(Banner banner)
        {
            try
            {
                banner.UpdateAt = DateTime.Now;
                //banner.UpdateBy = GetCurrentUser();

                _context.Update(banner);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BannerExists(banner.Id))
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
    }
}
