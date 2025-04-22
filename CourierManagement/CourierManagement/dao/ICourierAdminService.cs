using CourierManagement.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.dao
{
    public interface ICourierAdminService
    {
        int AddCourierStaff(Employee employeeObj);    
    }
}
