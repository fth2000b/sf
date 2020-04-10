using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFinder.Model
{
    public class Requests
    {
        public int ID
        {
            get; set;
        }
        public int CustomerID
        {
            get; set;
        }
        public int ShopID
        {
            get; set;
        }

        public String BuyingItems
        {
            get; set;
        }

        public bool IsCreditCardRequiredOnDlivery
        {
            get; set;
        }
        public String GPSLocation
        {
            get; set;
        }
        [Display(Name = "Updated")]
        [DataType(DataType.Date)]
        public DateTime RequestSendOn
        {
            get; set;
        }
        [Display(Name = "Updated")]
        [DataType(DataType.Date)]
        public DateTime RequestAcceptedOn
        {
            get; set;
        }

        public DateTime RequestStatus
        {
            get; set;
        }


        [Display(Name = "Updated")]
        [DataType(DataType.Date)]
        public DateTime Updated { get; set; }
    }
}
