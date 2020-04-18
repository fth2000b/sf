using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopFinder.Data;
using ShopFinder.Model;

namespace ShopFinder.Pages.MessagePages
{
    public class DeleteModel : PageModel
    {
        private readonly ShopFinder.Data.ShopFinderContext _context;

        public DeleteModel(ShopFinder.Data.ShopFinderContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RequestMessage RequestMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RequestMessage = await _context.RequestMessage.FirstOrDefaultAsync(m => m.ID == id);

            if (RequestMessage == null)
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

            RequestMessage = await _context.RequestMessage.FindAsync(id);

            if (RequestMessage != null)
            {
                _context.RequestMessage.Remove(RequestMessage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
