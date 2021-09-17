using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface INotesRL
    {
        List<Notes> getAllNotes(long token);
        public bool CreateNotes(NotesModel notesModel, long userId);
        public bool DeleteNotes(long id, long userId);
        public bool UpdateNotes(long id, long userId, NotesModel notesModel);

    }
}