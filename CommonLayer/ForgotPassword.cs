using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class ForgotPassWord
    {
        [Required]
        [EmailAddress]
        public String Email { get; set; }
    }
}
