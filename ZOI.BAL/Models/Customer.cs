using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZOI.BAL.Models
{
    [Table("Customer")]
    public class Customer : Base.BaseModel
    {
        
               
        [Display(Name = "Customer Type")]
        public int? TypeID { get; set; }
        [ForeignKey("TypeID")]
        public virtual CustomerType  CustomerType { get; set; }
        
        [Required]
        [RegularExpression(@"^([a-zA-Z][\w.]+|[0-9][0-9_.]*[a-zA-Z]+[\w.]*)$", ErrorMessage = "1. Must contain at least one letter; digits are allowed but not required  2. Cannot contain spaces 3. Special characters other than underscore and '.' (dot) are not allowed 4. Cannot start with a space or underscore or dot  ")]
        [StringLength(30, MinimumLength = 8)]
        public string LoginName { get; set; }
        


        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.!@$%^&*]*$", ErrorMessage = "1. Alphabelts, Numbers and Special Characters ''_.!@$%^&*'' are allowed. 2.Password length must be between 8 to 30 characters ")]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }
        
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.!@$%^&*]*$", ErrorMessage = "1. Alphabelts, Numbers and Special Characters ''_.!@$%^&*'' are allowed. 2.Password length must be between 8 to 30 characters ")]
        [StringLength(50, MinimumLength = 8)]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Only Numbers allowed")]
        public string CustomerMobileNo { get; set; }
        // Numbers Only

        [Required]
        [StringLength(150)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string CustomerEmail { get; set; }


        [Required]
        [StringLength(100)]
        public string Address1 { get; set; }
        [StringLength(100)]
        public string Address2 { get; set; }
        [StringLength(100)]
        public string Address3 { get; set; }
        
        [StringLength(50)]
        public string City { get; set; }

        [StringLength(6)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Only Numbers allowed")]
        public string Pin { get; set; }
        // Numbers Only

        [StringLength(10)]
        public string PaymentTerms { get; set; }
        public bool  IsMobileVerified { get; set; }
        public bool  IsEmailVerified { get; set; }

    }
}
