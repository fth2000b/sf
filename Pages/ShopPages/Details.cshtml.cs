﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopFinder.Data;
using ShopFinder.Model;

namespace ShopFinder.Pages.ShopPages
{
    public class DetailsModel : PageModel
    {
        private readonly ShopFinder.Data.ShopFinderContext _context;

        public DetailsModel(ShopFinder.Data.ShopFinderContext context)
        {
            _context = context;
        }

        public Shop Shop { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shop = await _context.Shop
                .Include(s => s.City)
                .Include(s => s.ShopCatagory).FirstOrDefaultAsync(m => m.ID == id);

            if (Shop == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
