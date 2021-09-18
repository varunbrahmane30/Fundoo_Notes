using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class Collaboration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id  { get; set; }
        public long CollaborationID { get; set; }
        public long Userid { get; set; }
        public User User { get; set; }
        public long Noteid { get; set; }
        public Notes Note { get; set; }
    }
}
