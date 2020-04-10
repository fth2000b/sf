using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFinder.Model
{
    public class Province
    {
        public int ID
        {
            get; set;
        }
        public String Name
        {
            get; set;
        }
        public List<Distric> Districs
        {
            get; set;
        }
        


    }
   
}
