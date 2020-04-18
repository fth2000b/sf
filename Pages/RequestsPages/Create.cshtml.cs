using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopFinder.Data;
using ShopFinder.Model;

namespace ShopFinder.Pages.RequestsPages
{
    public class CreateModel : PageModel
    {
        private readonly ShopFinder.Data.ShopFinderContext _context;
        private int _shopId;

        public CreateModel(ShopFinder.Data.ShopFinderContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string geoLocations { get; set; }


        [BindProperty]
        public User User { get; set; }

        public IActionResult OnGet(int? id)
        {
            _shopId = (int)id;
            Shop shop = _context.Shop.Include(u => u.City).Include(u => u.ShopCatagory).FirstOrDefault<Shop>(m => m.ID == id);



            ViewData["shop_name"] = shop.ShopName;
            ViewData["shop_address"] = shop.Address + "," + shop.Address2 + shop.City.Name;

            User = HttpContext.Session.GetObjectFromJson<User>("User");
            HttpContext.Session.SetString("shopId", _shopId + "");
            ViewData["address"] = User.Address + "," + User.Address2 + "," + User.City.Name;

            //  geoLocations;
            return Page();
        }

        [BindProperty]
        public CustRequest Requests { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _shopId = Int32.Parse(HttpContext.Session.GetString("shopId"));

            var user = HttpContext.Session.GetObjectFromJson<User>("User");
            Requests.ShopID = _shopId;
            Requests.UserID = user.ID;
            Requests.RequestSendOn = DateTime.Now;
            Requests.RequestStatus = RequestStatus.Send.ToString();
            Requests.Updated = DateTime.Now;
            Requests.MobileNo = user.MobileNo;

            _context.Request.Add(Requests);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
