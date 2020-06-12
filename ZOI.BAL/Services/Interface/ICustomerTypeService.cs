using System;
using System.Collections.Generic;
using System.Text;
using  ZOI.BAL.Models;

namespace ZOI.BAL.Services.Interface
{
    public interface ICustomerTypeService
    {
        IEnumerable<CustomerType> ListAllCustomerTypes();
        CustomerType FindCustomerType(int? id);
        void DeleteCustomerType(CustomerType customerType);
        int SaveCustomerType(CustomerType customerType);
    }
}
