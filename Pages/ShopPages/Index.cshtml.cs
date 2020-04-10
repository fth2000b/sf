using System;
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
    public class IndexModel : PageModel
    {
        private readonly ShopFinder.Data.ShopFinderContext _context;

        public IndexModel(ShopFinder.Data.ShopFinderContext context)
        {
            _context = context;
        }

        public IList<Shop> Shop { get;set; }

        public IActionResult OnGet()
        {
            Shop = _context.Shop.Include(s => s.City).Include(s => s.ShopCatagory).ToList();

            var myComplexObject = HttpContext.Session.GetObjectFromJson<User>("User");
            // Shop = await _context.Shop.ToListAsync();
            Shop = _context.Shop.Where(s => s.UserID == myComplexObject.ID).ToList(); ;
            if (Shop.Count == 0)
            {
                return RedirectToPage("./Create");
            }
            return Page();
        }


    }
}
