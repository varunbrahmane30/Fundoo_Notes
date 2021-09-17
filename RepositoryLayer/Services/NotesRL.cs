using CommonLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NotesRL : INotesRL
    {
        private UserContext _notesContext;

        public NotesRL(UserContext noteContext)
        {
            _notesContext = noteContext;
        }


        public List<Notes> getAllNotes(long token)
        {
            try
            {
                var result = _notesContext.Notes.ToList();

                return result;
            }
            catch
            {
                throw;
            }
        }
        public bool CreateNotes(NotesModel notesModel, long userId)
        {
            try
            {
                //var decrept = UserContext;
                Notes notes = new Notes();

                notes.Title = notesModel.Title;
                notes.Message = notesModel.Message;
                notes.Remainder = DateTime.Now;
                notes.Color = notesModel.Color;
                notes.image = notesModel.image;
                notes.isArchive = notesModel.isArchive;
                notes.isTrash = notesModel.isTrash;
                notes.CreatedAt = DateTime.Now;
                notes.ModifiedAt = null;
                notes.Userid = userId;
             
                this._notesContext.Notes.Add(notes);
                int result = _notesContext.SaveChanges();

                if (result > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteNotes(long id,long userId)
        {
            //var result = _notesContext.Notes.Find(id);
            var result = _notesContext.Notes.FirstOrDefault(e => e.Id == id && e.Userid == userId);
            if (result != null)
            {
                _notesContext.Notes.Remove(result);
                _notesContext.SaveChanges();

                return true;
            }

            return false;

        }

        public bool UpdateNotes(long id, long userId, NotesModel notesModel)
        {

            var result = _notesContext.Notes.FirstOrDefault(e => e.Id == id && e.Userid == userId);

            if (result != null)
            {
                if (notesModel.Title !=null)
                {
                    result.Title = notesModel.Title;
                }
                if(notesModel.Message!= null)
                {
                    result.Message = notesModel.Message;
                }
                
                result.ModifiedAt = DateTime.Now;
                _notesContext.SaveChanges();

                return true;
            }

            return false;

        }
    }
}
