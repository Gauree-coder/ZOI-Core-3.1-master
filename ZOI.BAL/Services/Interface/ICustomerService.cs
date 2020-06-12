using System;
using System.Collections.Generic;
using System.Text;
using ZOI.BAL.Models;

namespace ZOI.BAL.Services.Interface
{
    public interface ICustomerService
    {
        IEnumerable<Customer> ListAllCustomers();
        Customer FindCustomer(int? id);
        void DeleteCustomer(Customer customer);
        int SaveCustomer(Customer customer);
    }
}
