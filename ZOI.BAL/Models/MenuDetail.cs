using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOI.BAL.Models
{
    [Table("MenuDetail")]
    public class MenuDetail : Base.BaseModel
    {

        [Required]
        [Display(Name = "Food Type")]
        [StringLength(50)]
        public string FoodType { get; set; }

        // public int TimeSlotId { get; set; }
        [Required]
        [Display(Name = "Menu Time Slot")]
        [StringLength(50)]

        public string SlotID { get; set; }
       
        [Required]
        [Display(Name = "Menu Item")]
        [StringLength(100)]
        public string MenuItem { get; set; }

        [Required]
        [Display(Name = "Menu Date")]
        [DataType(DataType.Date)]
        public DateTime  MenuDate { get; set; }

        [Display(Name = "Description")]
        public string MenuItemDescription { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal MRP { get; set; }


    }
}
