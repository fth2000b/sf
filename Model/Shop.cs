
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFinder.Model
{
    public class Shop {
   

        public int ID
        {
            get; set;
        }
        public int UserID
        {
            get; set;
        }

        public String ShopName
        {
            get; set;
        }
        public List<CustRequest> Requests
        {
            get; set;
        }
        public ShopCatagory ShopCatagory
        {
            get; set;
        }
        public int ShopCatagoryID
        {
            get; set;
        }

        public String Password
        {
            get; set;
        }

        public bool IsOpen
        {
            get; set;
        }

        public String ConatctPerson
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
        public String GPSLocation
        {
            get; set;
        }
        public String Email
        {
            get; set;
        }
        public int ContactNo1
        {
            get; set;
        }
        public int ContactNo2
        {
            get; set;
        }
        public int ContactNo3
        {
            get; set;
        }
 
        public bool IsDiliveryAvilabel
        {
            get; set;
        }
        public bool IsCreditCardAccept
        {
            get; set;
        }
        public bool IsCreditCardAcceptOnDeliveryLocation
        {
            get; set;
        }
        [Display(Name = "OpenTime")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:8:30}", ApplyFormatInEditMode = true)]
        public DateTime OpenTime
        {
            get; set;
        }
        [Display(Name = "ClosedTime")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:10:30}", ApplyFormatInEditMode = true)]
        public DateTime ClosedTime
        {
            get; set;
        }
        private DateTime _date = DateTime.Now;

        [Display(Name = "Updated")]
        [DataType(DataType.Date)]
        public DateTime Updated { get; set; }
    }
}
