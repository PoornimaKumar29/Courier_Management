using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.entity
{
    public class Location
    {
        public int Location_id { get; set; }
        public string Location_Name { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"{Location_id} - {Location_Name}, {Address}";
        }
    }
}
