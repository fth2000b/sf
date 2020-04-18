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
    public class IndexModel : PageModel
    {
        private readonly ShopFinder.Data.ShopFinderContext _context;

        public IndexModel(ShopFinder.Data.ShopFinderContext context)
        {
            _context = context;
        }

        public IList<RequestMessage> RequestMessage { get; set; }

        //public async Task OnGetAsync()
        //{
        //    RequestMessage = await _context.RequestMessage.ToListAsync();
        //}


        public IActionResult OnGet(int id)
        {
            if (id == 1)
            {
                User user = HttpContext.Session.GetObjectFromJson<User>("User");
                if (user != null)
                {
                    HttpContext.Session.SetObjectAsJson("User", null);
                }

            }

            return null;
        }
    }
}
