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

namespace ShopFinder.Pages.UserPages
{
    public class CreateModel : PageModel
    {
        private readonly ShopFinder.Data.ShopFinderContext _context;

        public CreateModel(ShopFinder.Data.ShopFinderContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CityName"] = new SelectList(_context.City, "ID", "Name");
        ViewData["UserRole"] = new SelectList(_context.UserRole, "ID", "Role");
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            int  roleId = Int32.Parse(Request.Form["User.UserRole.Role"]);
            int cityId = Int32.Parse(Request.Form["User.City.Name"]) ;

            UserRole role =  await _context.UserRole.FirstOrDefaultAsync(m => m.ID == roleId);
            City city = await _context.City.FirstOrDefaultAsync(m => m.ID == cityId);

            User.Updated = DateTime.Now;
            User.UserRole = role;
            User.UserRoleID = role.ID;
            User.City = city;
            User.CityID = city.ID;

            _context.User.Add(User);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
