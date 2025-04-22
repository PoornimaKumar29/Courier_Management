using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.exception
{
    public class InvalidEmployeeIdException : Exception
    {
        public InvalidEmployeeIdException() : base("Invalid Employee ID.")
        {
        }

        public InvalidEmployeeIdException(string message) : base(message)
        {
        }

        public InvalidEmployeeIdException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
