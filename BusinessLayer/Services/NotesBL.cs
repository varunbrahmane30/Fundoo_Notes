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
        public NotesBL(INotesRL notesRL)
        {
            this._notesRL = notesRL;
        }

        public bool CreateNotes(NotesModel notesModel,long userId)
        {
            try
            {
                return this._notesRL.CreateNotes(notesModel,userId);
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
                return this._notesRL.DeleteNotes(id,userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateNotes(long id, long userId,NotesModel notesModel)
        {
            try
            {
                return this._notesRL.UpdateNotes(id,userId, notesModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Notes> getAllNotes(long token)
        {
            try
            {
                return this._notesRL.getAllNotes();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
