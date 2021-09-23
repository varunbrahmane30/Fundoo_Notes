using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class Notes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime? Remainder { get; set; }

        public string Color { get; set; }

        public string image { get; set; }

        public bool isArchive { get; set; }

        public bool isPin { get; set; }

        public bool isTrash { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        // navigation property.
        public long Userid { get; set; }
        public User User { get; set; }
        public List<Collaborator> collaborations { get; set; }
        public List<NotesLabel> NotesLabel { get; set; }
    }
}
