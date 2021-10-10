//-----------------------------------------------------------------------
// <copyright file="NotesBL.cs" 
// </copyright>
// <author>Varun Brahmane</author>
//-----------------------------------------------------------------------

namespace BusinessLayer.Services
{
    using System;
    using System.Collections.Generic;
    using BusinessLayer.Interface;
    using CommonLayer;
    using Microsoft.AspNetCore.Http;
    using RepositoryLayer.Entity;
    using RepositoryLayer.Interface;
 
    public class NotesBL : INotesBL
    {
        readonly private INotesRL _notesRL;
        readonly private IUserRL _userRL;
        public NotesBL(INotesRL notesRL, IUserRL userRL)
        {
            this._notesRL = notesRL;
            this._userRL = userRL;
        }

        public List<Notes> GetAllNotes(long id)
        {
            try
            {
                return this._notesRL.GetAllNotes(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Notes> GetBinNotes(long id)
        {
            try
            {
                return this._notesRL.GetBinNotes(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Notes> GetArchiveNotes(long id)
        {
            try
            {
                return this._notesRL.GetArchiveNotes(id);
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

        public bool AddReminder(long id,long userId,ReminderModel reminderModel)
        {
            try
            {
                return this._notesRL.AddReminder(id,userId,reminderModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UploadImage(IFormFile file, long noteid)
        {
            try
            {
                return this._notesRL.UploadImage(file, noteid);            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool DeleteImage(long noteid)
        {
            try
            {
                return this._notesRL.DeleteImage(noteid);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
