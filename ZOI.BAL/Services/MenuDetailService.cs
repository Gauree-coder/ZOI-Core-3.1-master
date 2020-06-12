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
    public class MenuDetailService : IMenuDetailService
    {
        private readonly DBContext.DatabaseContext databaseContext;


        public MenuDetailService(DBContext.DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }

        public IEnumerable<MenuDetail> ListAllMenuDetails()
        {

            return databaseContext.MenuDetail.ToList();

        }

        public MenuDetail FindMenuDetail(int? id)
        {

            return databaseContext.MenuDetail.FirstOrDefault(u => u.Id == id);

        }

        public int SaveMenuDetail(MenuDetail MenuDetail)
        {
            try
            {
                if (MenuDetail.Id == 0)
                {
                    databaseContext.MenuDetail.Add(MenuDetail);
                }
                else
                {
                    databaseContext.MenuDetail.Update(MenuDetail);

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



        public void DeleteMenuDetail(MenuDetail MenuDetail)
        {

            int status;
            databaseContext.MenuDetail.Remove(MenuDetail);
            databaseContext.SaveChangesAsync();


        }

    }
}
