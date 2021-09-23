using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class NotesBL : INotesBL
    {
        private INotesRL _notesRL;
        private IUserRL _userRL;
        public NotesBL(INotesRL notesRL, IUserRL userRL)
        {
            this._notesRL = notesRL;
            _userRL = userRL;
        }

        public List<Notes> getAllNotes(long id)
        {
            try
            {
                return this._notesRL.getAllNotes(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool CreateNotes(NotesModel notesModel, long userId)
        {
            try
            {
                return this._notesRL.CreateNotes(notesModel, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteNotes(long id, long userId)
        {
            try
            {
                return this._notesRL.DeleteNotes(id, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateNotes(long id, long userId, NotesModel notesModel)
        {
            try
            {
                return this._notesRL.UpdateNotes(id, userId, notesModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsPinned(long id, long noteId)
        {
            try
            {
                return this._notesRL.IsPinned(id, noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ChangeColor(long id, long noteId, string color)
        {
            try
            {
                return this._notesRL.ChangeColor(id, noteId, color);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsArchive(long id, long noteId)
        {
            try
            {
                return this._notesRL.IsArchive(id, noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsTrash(long id, long noteId)
        {
            try
            {
                return this._notesRL.IsTrash(id, noteId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddReminder(long id, long userId, ReminderModel reminderModel)
        {
            try
            {
                return this._notesRL.AddReminder(id, userId, reminderModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
