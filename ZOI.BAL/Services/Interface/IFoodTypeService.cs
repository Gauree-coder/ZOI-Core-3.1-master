using System;
using System.Collections.Generic;
using System.Text;
using ZOI.BAL.Models;

namespace ZOI.BAL.Services.Interface
{
    public interface IFoodTypeService
    {
        IEnumerable<FoodType> ListAllFoodTypes();
        FoodType FindFoodType(int? id);
        void DeleteFoodType(FoodType foodType);
        int SaveFoodType(FoodType foodType);
    }
}
