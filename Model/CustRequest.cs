using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFinder.Model
{
    public class CustRequest
    {
        public int ID
        {
            get; set;
        }
        public int UserID
        {
            get; set;
        }
        public int ShopID
        {
            get; set;
        }
        public Shop Shop
        {
            get; set;
        }
        public int MobileNo
        {
            get; set;
        }
        public String RequestStatus
        {
            get; set;
        }

        public RequestMessage RequestMessage
        {
            get; set;
        }
        public String DeliverAddress
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
        [DataType(DataType.DateTime)]
        public DateTime RequestSendOn
        {
            get; set;
        }
        [Display(Name = "Updated")]
        [DataType(DataType.DateTime)]
        public DateTime RequestAcceptedOn
        {
            get; set;
        }
        [Display(Name = "Updated")]
        [DataType(DataType.DateTime)]
        public DateTime DilveryStarted
        {
            get; set;
        }
        [Display(Name = "Updated")]
        [DataType(DataType.DateTime)]
        public DateTime Dilverd
        {
            get; set;
        }

        [Display(Name = "Updated")]
        [DataType(DataType.DateTime)]
        public DateTime Updated { get; set; }
    }
}
