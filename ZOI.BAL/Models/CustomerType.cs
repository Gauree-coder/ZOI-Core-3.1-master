using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOI.BAL.Models
{
    [Table("CustomerType")] 
    public class CustomerType : Base.BaseModel
    {
       
        [Required]
        [StringLength(100)]
        [Display(Name = "Customer Type")]
        public string CustType { get; set; }
        

    }
}
