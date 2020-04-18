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
    public class IndexModel : PageModel
    {
        private readonly ShopFinder.Data.ShopFinderContext _context;

        public IndexModel(ShopFinder.Data.ShopFinderContext context)
        {
            _context = context;
        }

        public IList<CustRequest> Request { get;set; }

        public async Task OnGetAsync()
        {
           User user =  HttpContext.Session.GetObjectFromJson<User>("User");
            Request = await _context.Request
                .Include(r => r.Shop).Where(r => r.UserID == user.ID).ToListAsync();
        }
    }
}
