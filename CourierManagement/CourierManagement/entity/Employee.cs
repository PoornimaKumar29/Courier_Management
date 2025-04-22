using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.entity
{
    public class Employee
    {
        public int Employee_id { get; set; }
        public string Employee_Name { get; set; }
        public string Employee_Email { get; set; }
        public long Employee_phone { get; set; }
        public string Employee_Role { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            return $"{Employee_id} - {Employee_Name}, {Employee_Role}, ₹{Salary}";
        }
    }
}
