using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intuit.Ipp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopFinder.Model;
using User = ShopFinder.Model.User;

namespace ShopFinder.Pages
{
    public class Login : PageModel
    {
        private readonly ShopFinder.Data.ShopFinderContext _context;

        public Login(ShopFinder.Data.ShopFinderContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int MobileNo { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Msg { get; set; }

   
       public IActionResult OnGet(String id)
        {

            return null;
        }
        


        public async Task<IActionResult> OnPost()
        {
           
            if (MobileNo ==0 || Password == null)
            {
                Msg = "Please Enter UserID and Password";
                return Page();
            }
            //User  user = await _context.User.Include(m => m.MobileNo == MobileNo).Include(m => m.UserRoleID = ).FirstOrDefaultAsync(m => m.UserRoleID == MobileNo);

            User user = await _context.User.Include(i => i.UserRole).FirstOrDefaultAsync(m => m.MobileNo == MobileNo);
            if (user == null)
            {
                Msg = "Invalid UserID";
                return Page();

            }
            else
            {
                if (user.MobileNo == MobileNo && user.Password == Password)
                {
                    user.UserRole.Users = null;

                    HttpContext.Session.SetObjectAsJson("User", user);

                    if (user.UserRole.Role == "Seller")
                    {
                        return RedirectToPage("ShopPages/Index");

                    }
                    else if (user.UserRole.Role == "Buyer")
                    {
                        return RedirectToPage("FindShop/FindShop");
                    }
                    return RedirectToPage("FindShop/FindShop");

                }  else
                {
                    Msg = "Invalid Login";
                    return Page();

                }

            }
           
        }

    }
}