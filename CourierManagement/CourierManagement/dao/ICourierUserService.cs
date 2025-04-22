using CourierManagement.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement.dao
{
    public interface ICourierUserService
    {
        long PlaceOrder(Courier courierObj);          
        string GetOrderStatus(long trackingNumber);
        bool CancelOrder(long trackingNumber);
        List<Courier> GetAssignedOrder(int courierStaffId);
        List<Courier> ViewDeliveryHistory();
        Dictionary<string, int> GenerateReport();
        List<Employee> GetAllEmployees();
        List<Courier> GetAllCouriers();
    }

}
