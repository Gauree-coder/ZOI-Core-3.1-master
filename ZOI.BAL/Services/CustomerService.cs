using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ZOI.DAL;
using ZOI.DAL.DatabaseUtility;
using ZOI.BAL.DBContext;
using ZOI.BAL.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZOI.BAL.Services.Interface;
using ZOI.DAL.DatabaseUtility.Interface;

namespace ZOI.BAL.Services
{
   public class CustomerService : ICustomerService
    {
        private readonly DBContext.DatabaseContext databaseContext;


        public CustomerService(DBContext.DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public IEnumerable<Customer> ListAllCustomers()
        {

            // return _adoDataFunction.ExecSQL<Customer>("Select * from Customer");
            return databaseContext.Customer.ToList();

        }


        public Customer FindCustomer(int? id)
        {

            return databaseContext.Customer.FirstOrDefault(u => u.Id == id);


        }



        public int SaveCustomer(Customer Customer)
        {
            try
            {
                if (Customer.Id == 0)
                {
                    databaseContext.Customer.Add(Customer);
                }
                else
                {
                    databaseContext.Customer.Update(Customer);

                }
                databaseContext.SaveChanges();

                return 1;
            }
            catch (Exception Ex)
            {
                //throw Ex;
                return 0;

            }
        }

        public void DeleteCustomer(Customer Customer)
        {

            int status;
            databaseContext.Customer.Remove(Customer);
            databaseContext.SaveChangesAsync();


        }
    }
}
