using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCParentApplication.Models
{
    public class MVCuserModel
    {
        public int UserContactDetailUID { get; set; }
        [Required(ErrorMessage = "First Name is Required"), MaxLength(30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required"), MaxLength(30)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter Email ID")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]  
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string PhoneNumber { get; set; }

        public Nullable<bool> Inactive { get; set; }
    }
}