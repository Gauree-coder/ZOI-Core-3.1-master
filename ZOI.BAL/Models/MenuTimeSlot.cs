using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ZOI.BAL.Models
{
    [Table("MenuTimeSlot")]
    public class MenuTimeSlot : Base.BaseModel
    {
     
        [StringLength(100)]
        [Display(Name = "Time Slot Name")]
        public string TimeslotName { get; set; }
        [StringLength(10)]
        [Display(Name = "Start Time")]
        public string StartTime { get; set; }
        [StringLength(10)]
        [Display(Name = "End Time")]
        public string EndTime { get; set; }

    }
}
