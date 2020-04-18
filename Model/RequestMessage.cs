using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFinder.Model
{
    public class RequestMessage
    {
        public int ID
        {
            get; set;
        }
        public String RequestsID
        {
            get; set;
        }
        public String Messsage
        {
            get; set;
        }
        public String MessageType
        {
            get; set;
        }

        [Display(Name = "Updated")]
        [DataType(DataType.Date)]
        public DateTime Updated { get; set; }

    }
}
