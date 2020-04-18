using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFinder.Model
{
    public class User
    {
      

        public User()
        {
         
        }

        public int ID
        {
            get; set;
        }

        public int UserRoleID
        {
            get; set;
        }
       
        public String Address
        {
            get; set;
        }
        public String Address2
        {
            get; set;
        }
        public int CityID
        {
            get; set;
        }

        public City City
        {
            get; set;
        }
        public virtual UserRole UserRole
        {
            get; set;
        }

        [DataType(DataType.PhoneNumber)]
        public int MobileNo
        {
            get; set;
        }
      
        public String Name
        {
            get; set;
        }
        [DataType(DataType.Password)]
        public String Password
        {
            get; set;
        }

        [Display(Name = "Updated")]
        [DataType(DataType.DateTime)]
        public DateTime Updated { get; set; }

    }
}
