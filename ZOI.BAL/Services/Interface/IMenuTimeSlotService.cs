using System;
using System.Collections.Generic;
using System.Text;
using  ZOI.BAL.Models;

namespace ZOI.BAL.Services.Interface
{
    public interface IMenuTimeSlotService
    {
        IEnumerable<MenuTimeSlot> ListAllMenuTimeSlots();
        MenuTimeSlot FindMenuTimeSlot(int? id);
        void DeleteMenuTimeSlot(MenuTimeSlot menuTimeSlot);
        int SaveMenuTimeSlot(MenuTimeSlot menuTimeSlot);
    }
}
