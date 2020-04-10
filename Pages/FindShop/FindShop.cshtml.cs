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


        public IList<Shop> Shop { get; set; }


        public IActionResult OnGet()
        {
            Shop = _context.Shop.Include(u => u.ShopCatagory).ToList();
            return Page();
        }
    }
}