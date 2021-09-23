using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class NotesLabel
    {
        [Key, Column(Order = 0)]
        public long NotesId { get; set; }
        public Notes Notes { get; set; }

        [Key, Column(Order = 1)]
        public long LabelId { get; set; }
        public Label Label { get; set; }
    }
}
