using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOI.BAL.Models
{
    [Table("FoodType")]
    public class FoodType : Base.BaseModel
    {
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        

    }
}
