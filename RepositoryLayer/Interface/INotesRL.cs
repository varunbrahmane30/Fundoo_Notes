using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface INotesRL
    {
        List<Notes> getAllNotes(long id);
        public bool CreateNotes(NotesModel notesModel, long userId);
        public bool DeleteNotes(long id, long userId);
        public bool UpdateNotes(long id, long userId, NotesModel notesModel);
        public bool IsPinned(long Id, long noteId, bool value);
        public bool ChangeColor(long id, long noteId, string color);
        public bool IsArchive(long id, long noteId, bool value);
        public bool IsTrash(long id, long noteId, bool value);
        public bool AddReminder(long id, long userId, ReminderModel reminderModel);
        public Notes GetNote(long id);
    }
}