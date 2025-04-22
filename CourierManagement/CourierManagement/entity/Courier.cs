using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.entity
{
    public class Courier
    {
        public int Courier_id { get; set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public decimal Weight { get; set; }
        public string Status { get; set; }
        public long Tracking_Number { get; set; }
        public DateTime Delivary_Date { get; set; }
        public int Employee_id { get; set; }

        public override string ToString()
        {
            return $"{Courier_id}, {Tracking_Number}, {SenderName} → {ReceiverName}, Status: {Status}";
        }
    }
}
