namespace RepositoryLayer.Context
{
    using Microsoft.EntityFrameworkCore;
    using RepositoryLayer.Entity;

    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Notes> Notes { get; set; }

        /// <summary>
        /// Gets or sets the collaborators.
        /// </summary>
        /// <value>
        /// The collaborators.
        /// </value>
        public DbSet<Collaborator> Collaborators { get; set; }

        /// <summary>Gets or sets the label.</summary>
        /// <value>The label.</value>
        public DbSet<Label> Label { get; set; }

        /// <summary>
        /// Gets or sets the notes label.
        /// </summary>
        /// <value>
        /// The notes label.
        /// </value>
        public DbSet<NotesLabel> NotesLabel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            builder.Entity<NotesLabel>(entity =>
            {
                entity.HasKey(e => new { e.NotesId, e.LabelId });
            });
           
            builder.Entity<Collaborator>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.NoteId });
            });
        }

       
    }
}
