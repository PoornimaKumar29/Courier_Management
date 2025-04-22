using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.entity
{
    public class User
    {
        public int User_id { get; set; }
        public string User_Name { get; set; }
        public string User_Email { get; set; }
        public string User_Password { get; set; }
        public long User_Phone { get; set; }
        public string User_Address { get; set; }

        public override string ToString()
        {
            return $"{User_id}, {User_Name}, {User_Email}, {User_Phone}, {User_Address}";
        }
    }
}
