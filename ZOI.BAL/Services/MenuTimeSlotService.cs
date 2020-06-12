using System;
using System.Collections.Generic;
using System.Text;
using ZOI.DAL.DatabaseUtility;
using ZOI.BAL.DBContext;
using ZOI.BAL.Services.Interface;
using ZOI.BAL.Models;
using ZOI.DAL.DatabaseUtility.Interface;
using System.Linq;

namespace ZOI.BAL.Services
{
    public class MenuTimeSlotService : IMenuTimeSlotService
    {
        private readonly DBContext.DatabaseContext databaseContext;


        public MenuTimeSlotService(DBContext.DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public IEnumerable<MenuTimeSlot> ListAllMenuTimeSlots()
        {
           
            return databaseContext.MenuTimeSlot.ToList();

        }

        public MenuTimeSlot FindMenuTimeSlot(int? id)
        {

            return databaseContext.MenuTimeSlot.FirstOrDefault(u => u.Id == id);
        
        }

        public int SaveMenuTimeSlot(MenuTimeSlot menuTimeSlot)
        {
            try
            {
                if (menuTimeSlot.Id == 0)
                {
                    databaseContext.MenuTimeSlot.Add(menuTimeSlot);
                }
                else
                {
                    databaseContext.MenuTimeSlot.Update(menuTimeSlot);

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



        public void DeleteMenuTimeSlot(MenuTimeSlot menuTimeSlot)
        {

            int status;
            databaseContext.MenuTimeSlot.Remove(menuTimeSlot);
            databaseContext.SaveChangesAsync();


        }


    }
}
