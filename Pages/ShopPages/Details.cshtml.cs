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
    public class DetailsModel : PageModel
    {
        private readonly ShopFinder.Data.ShopFinderContext _context;
        public static int _shopId;
        public DetailsModel(ShopFinder.Data.ShopFinderContext context)
        {
            _context = context;
        }

        public Shop Shop { get; set; }
        public List<CustRequest> Requests { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, String Action)
        {
           
            if (id == null)
            {
                return NotFound();
            }
            if (Action == null)
            {
                Shop = await _context.Shop
                .Include(s => s.City)
                .Include(s => s.ShopCatagory).FirstOrDefaultAsync(m => m.ID == id);
                HttpContext.Session.SetObjectAsJson("Shop", Shop);
                Requests = _context.Request.Where(s => s.ShopID == Shop.ID).ToList();
                _shopId = Shop.ID;

            }
            else if (Action == "Accept")
            {
                CustRequest custRequest = _context.Request.Where(s => s.ID == id).FirstOrDefault();
                custRequest.RequestStatus = RequestStatus.Accpeted.ToString();
                custRequest.RequestAcceptedOn = DateTime.Now;
                _context.Request.Update(custRequest);
                _context.SaveChanges();

                Shop = HttpContext.Session.GetObjectFromJson<Shop>("Shop");

                Requests = _context.Request.Where(s => s.ShopID == Shop.ID).ToList();
                return Page();
            }
            else if (Action == "Decline")
            {
                Shop = HttpContext.Session.GetObjectFromJson<Shop>("Shop");
                CustRequest custRequest = _context.Request.Where(s => s.ID == id).FirstOrDefault();
                custRequest.RequestStatus = RequestStatus.Decline.ToString();
                custRequest.Updated = DateTime.Now;
                _context.Request.Update(custRequest);
                _context.SaveChanges();

                Shop = HttpContext.Session.GetObjectFromJson<Shop>("Shop");

                Requests = _context.Request.Where(s => s.ShopID == Shop.ID).ToList();
                return Page();
            }
            else if (Action == "Message")
            {
                CustRequest custRequest = _context.Request.Where(s => s.ID == id).FirstOrDefault();
                Dictionary<string, int> hash = new Dictionary<string, int>();

                hash.Add("requestId", custRequest.ID);
                hash.Add("shopId", custRequest.ShopID);
                // tring pageName, string pageHandler, object routeValues

                return RedirectToPage("/MessagePages/index", "", custRequest);
            }
            return Page();
        }
    }
}
