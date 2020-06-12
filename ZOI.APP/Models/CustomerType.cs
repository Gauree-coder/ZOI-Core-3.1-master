using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOI.APP.Models
{
   
    public class CustomerType : Base.BaseViewModel
    {
       
        [Required]
        [StringLength(100)]
        [Display(Name = "Customer Type")]
        public string CustType { get; set; }
        

    }
}
