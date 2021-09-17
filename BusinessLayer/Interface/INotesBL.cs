using System.Collections.Generic;
using CommonLayer;
using RepositoryLayer.Entity;

namespace BusinessLayer.Interface
{
    public interface INotesBL 
    {
        List<Notes> getAllNotes(long token);
        public bool CreateNotes(NotesModel notesModel, long userId);
        public bool DeleteNotes(long id, long userId);
        public bool UpdateNotes(long id,long userId, NotesModel notesModel);
    }
}
