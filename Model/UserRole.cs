using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFinder.Model
{
    public class UserRole
    {
   
        public UserRole()
        {
 
        }
        public int ID
        {
            get; set;
        }
        public String Role
        {
            get; set;
        }

        public List<User> Users
        {
            get; set;
        }

        [Display(Name = "Updated")]
        [DataType(DataType.DateTime)]
        public DateTime Updated { get; set; }
    }
}
