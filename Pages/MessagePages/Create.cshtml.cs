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
    public class CreateModel : PageModel
    {
        private readonly ShopFinder.Data.ShopFinderContext _context;


        public CreateModel(ShopFinder.Data.ShopFinderContext context)
        {
            _context = context;
        }
        [BindProperty]
        public CustRequest Request { get; set; }
        [BindProperty]
        public User User { get; set; }

        public IActionResult OnGet(CustRequest custRequest)
        {
            Request = custRequest;
            User = _context.User.FirstOrDefault(m => m.MobileNo == custRequest.MobileNo);

            return Page();
        }


        [BindProperty]
        public CustRequest CustRequest { get; set; }
        [BindProperty]
        public RequestMessage RequestMessage { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            RequestMessage.MessageType = MessageType.TO_BUYER.ToString();
            RequestMessage.Updated = DateTime.Now;
  
            _context.RequestMessage.Add(RequestMessage);
            await _context.SaveChangesAsync();

           // return RedirectToPage(".?id="+ CustRequest.ShopID);
            return RedirectToPage("/ShopPages/Details", "SingleOrder", new { id = CustRequest.ShopID});
        }
    }
                // To protect from overposting attacks, please enable the specific properties you want to bind to, f
}
