using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopFinder.Data;
using ShopFinder.Model;

namespace ShopFinder.Pages.ShopCatagoryPages
{
    public class DeleteModel : PageModel
    {
        private readonly ShopFinder.Data.ShopFinderContext _context;

        public DeleteModel(ShopFinder.Data.ShopFinderContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShopCatagory ShopCatagory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShopCatagory = await _context.ShopCatagory.FirstOrDefaultAsync(m => m.ID == id);

            if (ShopCatagory == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShopCatagory = await _context.ShopCatagory.FindAsync(id);

            if (ShopCatagory != null)
            {
                _context.ShopCatagory.Remove(ShopCatagory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
