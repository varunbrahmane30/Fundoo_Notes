using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    class CollaborationModel
    {
        [Required]
        public String Email { get; set; }
    }
}
