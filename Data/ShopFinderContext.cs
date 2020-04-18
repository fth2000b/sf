

using Microsoft.EntityFrameworkCore;
using ShopFinder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShopFinder.Data
{
    public class ShopFinderContext : DbContext
    {
        public ShopFinderContext(DbContextOptions<ShopFinderContext> options)
            : base(options)
        {
        }
        public DbSet<Customer > Customer { get; set; }
        public DbSet<CustRequest> Request { get; set; }
        public DbSet<Shop> Shop { get; set; }
        public DbContextOptions<ShopFinderContext> Options { get; }
        public DbSet<ShopFinder.Model.Province> Province { get; set; }
        public DbSet<ShopFinder.Model.Distric> Distric { get; set; }
        public DbSet<ShopFinder.Model.City> City { get; set; }
        public DbSet<ShopFinder.Model.User> User { get; set; }
        public DbSet<ShopFinder.Model.UserRole> UserRole { get; set; }
        public DbSet<ShopFinder.Model.ShopCatagory> ShopCatagory { get; set; }
        public DbSet<ShopFinder.Model.RequestMessage> RequestMessage { get; set; }
    }
}
