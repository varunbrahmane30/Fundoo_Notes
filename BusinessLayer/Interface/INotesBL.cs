using System.Collections.Generic;
using CommonLayer;
using RepositoryLayer.Entity;

namespace BusinessLayer.Interface
{
    public interface INotesBL 
    {
        List<Notes> getAllNotes(long id);
        public bool CreateNotes(NotesModel notesModel, long userId);
        public bool DeleteNotes(long id, long userId);
        public bool UpdateNotes(long id,long userId, NotesModel notesModel);
        public bool IsPinned(long Id, long noteId,bool value);
        public bool ChangeColor(long Id, long noteId,string color);
        public bool IsArchive(long Id, long noteId, bool value);
        public bool IsTrash(long Id, long noteId, bool value);
        public bool AddReminder(long id, long userId, ReminderModel reminderModel);

    } 
}
