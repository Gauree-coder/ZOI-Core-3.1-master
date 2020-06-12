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
    public class FoodTypeService : IFoodTypeService
    {
        private readonly DBContext.DatabaseContext databaseContext;
       

        public FoodTypeService(DBContext.DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public IEnumerable<FoodType> ListAllFoodTypes()
        {
            
            // return _adoDataFunction.ExecSQL<FoodType>("Select * from FoodType");
            return databaseContext.FoodType.ToList();

        }


        public FoodType FindFoodType(int?id)
        {
            
            return databaseContext.FoodType.FirstOrDefault(u => u.Id == id);
        

        }

       

        public int SaveFoodType(FoodType foodType)
        {
            try
            {
                if (foodType.Id == 0)
                {
                    databaseContext.FoodType.Add(foodType);
                }
                else
                {
                    databaseContext.FoodType.Update(foodType);

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

        public void DeleteFoodType(FoodType foodType)
        {

            int status;
            databaseContext.FoodType.Remove(foodType);
            databaseContext.SaveChangesAsync();
            

        }

    }
}
