using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopFinder.Data;
using ShopFinder.Model;

namespace ShopFinder.Pages.ShopPages
{
    public class MessageModel : PageModel
    {
        private readonly ShopFinder.Data.ShopFinderContext _context;

        public MessageModel(ShopFinder.Data.ShopFinderContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CityID"] = new SelectList(_context.City, "ID", "Name");
        ViewData["ShopCatagoryID"] = new SelectList(_context.ShopCatagory, "ID", "Name");
            var myComplexObject = HttpContext.Session.GetObjectFromJson<User>("User");
            ViewData["ContactNo1"] = myComplexObject.MobileNo;
            return Page();
        }

        [BindProperty]
        public Shop Shop { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var myComplexObject = HttpContext.Session.GetObjectFromJson<User>("User");
            Shop.UserID = myComplexObject.ID;
            Shop.Updated = DateTime.Now;
            _context.Shop.Add(Shop);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
