using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFinder.Model
{
    public class Customer
    {
        public int ID
        {
            get; set;
        }
        public String ContactName
        {
            get; set;
        }
        public String ContactNo
        {
            get; set;
        }
        public String Password
        {
            get; set;
        }

        public String Address1
        {
            get; set;
        }
        public String Address2
        {
            get; set;
        }
        public String Province
        {
            get; set;
        }
        public String Distric
        {
            get; set;
        }

        [Display(Name = "Updated")]
        [DataType(DataType.Date)]
        public DateTime Updated { get; set; }
    }
}
