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
    public class CustomerTypeService : ICustomerTypeService
    {
        private readonly DBContext.DatabaseContext databaseContext;
       

        public CustomerTypeService(DBContext.DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public IEnumerable<CustomerType> ListAllCustomerTypes()
        {
            
            // return _adoDataFunction.ExecSQL<CustomerType>("Select * from CustomerType");
            return databaseContext.CustomerType.ToList();

        }


        public CustomerType FindCustomerType(int?id)
        {
            
            return databaseContext.CustomerType.FirstOrDefault(u => u.Id == id);
        

        }

       

        public int SaveCustomerType(CustomerType CustomerType)
        {
            try
            {
                if (CustomerType.Id == 0)
                {
                    databaseContext.CustomerType.Add(CustomerType);
                }
                else
                {
                    databaseContext.CustomerType.Update(CustomerType);

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

        public void DeleteCustomerType(CustomerType CustomerType)
        {

            int status;
            databaseContext.CustomerType.Remove(CustomerType);
            databaseContext.SaveChangesAsync();
            

        }

    }
}
