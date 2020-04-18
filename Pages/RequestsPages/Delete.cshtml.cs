using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopFinder.Data;
using ShopFinder.Model;

namespace ShopFinder.Pages.RequestsPages
{
    public class DeleteModel : PageModel
    {
        private readonly ShopFinder.Data.ShopFinderContext _context;

        public DeleteModel(ShopFinder.Data.ShopFinderContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustRequest Request { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Request = await _context.Request
                .Include(r => r.Shop).FirstOrDefaultAsync(m => m.ID == id);

            if (Request == null)
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

            Request = await _context.Request.FindAsync(id);

            if (Request != null)
            {
                _context.Request.Remove(Request);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
