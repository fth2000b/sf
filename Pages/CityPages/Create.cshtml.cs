﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopFinder.Data;
using ShopFinder.Model;

namespace ShopFinder.Pages.CityPages
{
    public class CreateModel : PageModel
    {
        private readonly ShopFinder.Data.ShopFinderContext _context;

        public CreateModel(ShopFinder.Data.ShopFinderContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ProvinceID"] = new SelectList(_context.Province, "ID", "ID");
            ViewData["DistricID"] = new SelectList(_context.Distric, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public City City { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                
                return Page();
            }

            _context.City.Add(City);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}