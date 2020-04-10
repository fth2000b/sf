using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopFinder.Data;
using ShopFinder.Model;

namespace ShopFinder.Pages.CityPages
{
    public class DetailsModel : PageModel
    {
        private readonly ShopFinder.Data.ShopFinderContext _context;

        public DetailsModel(ShopFinder.Data.ShopFinderContext context)
        {
            _context = context;
        }

        public City City { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City = await _context.City.FirstOrDefaultAsync(m => m.ID == id);

            if (City == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
