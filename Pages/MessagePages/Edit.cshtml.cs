using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopFinder.Data;
using ShopFinder.Model;

namespace ShopFinder.Pages.MessagePages
{
    public class EditModel : PageModel
    {
        private readonly ShopFinder.Data.ShopFinderContext _context;

        public EditModel(ShopFinder.Data.ShopFinderContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RequestMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestMessageExists(RequestMessage.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RequestMessageExists(int id)
        {
            return _context.RequestMessage.Any(e => e.ID == id);
        }
    }
}
