using CommonLayer;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;

namespace RepositoryLayer.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Label> Label { get; set; }
        public DbSet<NotesLabel> NotesLabel { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            builder.Entity<NotesLabel>(builder =>
            {
                 builder.HasNoKey();
                 builder.ToTable("NotesLabel");
            });

            //builder.Entity<Notes>()
            //.Property(e => e.Labels)
            //.HasConversion(
            //    v => string.Join(',', v),
            //    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
            builder.Entity<Collaborator>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.NoteId });
            });
        }

       
    }
}
