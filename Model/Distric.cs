using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopFinder.Model
{
    public class Distric
    {
        public int ID
        {
            get; set;
        }
        public int ProvinceID
        {
            get; set;
        }
        public String Name
        {
            get; set;
        }
        public List<City> Cites
        {
            get; set;
        }
    }
}
