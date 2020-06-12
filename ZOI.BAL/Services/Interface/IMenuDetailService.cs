using System;
using System.Collections.Generic;
using System.Text;
using ZOI.BAL.Models;

namespace ZOI.BAL.Services.Interface
{
    public interface IMenuDetailService
    {
        IEnumerable<MenuDetail> ListAllMenuDetails();
        MenuDetail FindMenuDetail(int? id);
        void DeleteMenuDetail(MenuDetail MenuDetail);
        int SaveMenuDetail(MenuDetail MenuDetail);
    }
}
