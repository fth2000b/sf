using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopFinder.Model;

namespace ShopFinder.Pages.FindShop
{
    public class FindShopModel : PageModel
    {
        private readonly ShopFinder.Data.ShopFinderContext _context;

        public FindShopModel(ShopFinder.Data.ShopFinderContext context)
        {
            _context = context;
        }
       

        [BindProperty]
        public string geoLocations { get; set; }

        public IList<Shop> Shop { get; set; }


        public IActionResult OnGet()
        {

            Shop = _context.Shop.Include(u => u.ShopCatagory).Include(u => u.Requests).ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return RedirectToPage("./Index");
        }

        }
    }