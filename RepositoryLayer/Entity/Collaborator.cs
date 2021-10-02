
namespace RepositoryLayer.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class Collaborator
    {
        [Key, Column(Order = 0)]
        public long UserId { get; set; }
        public User User { get; set; }

        [Key, Column(Order = 1)]
        public long NoteId { get; set; }
        public Notes Note { get; set; }

    }
}
