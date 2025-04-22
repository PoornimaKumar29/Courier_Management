using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.entity
{
    public class Payment
    {
        public int Payment_id { get; set; }
        public int Courier_id { get; set; }
        public int Location_id { get; set; }
        public int Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public override string ToString()
        {
            return $"{Payment_id} - Courier: {Courier_id}, ₹{Amount}, Date: {PaymentDate.ToShortDateString()}";
        }
    }
}
