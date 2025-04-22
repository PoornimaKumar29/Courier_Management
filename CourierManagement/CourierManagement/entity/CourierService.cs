using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.entity
{
    public class CourierService
    {
        public int Service_id { get; set; }
        public string ServiceName { get; set; }
        public decimal Cost { get; set; }

        public override string ToString()
        {
            return $"{Service_id} - {ServiceName}: ₹{Cost}";
        }
    }
}
