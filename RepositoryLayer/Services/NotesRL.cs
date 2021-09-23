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


        public List<Notes> getAllNotes(long userId)
        {
            try
            {
                var result = _notesContext.Notes.Where(e => e.Userid == userId).ToList();
                result.AddRange(GetSharedNotes(userId));
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<Notes> GetSharedNotes(long userId)
        {
            var noteIds = _notesContext.Collaborators.Where(e => e.UserId == userId).Select(e => e.NoteId);
            var sharedNotes = new List<Notes>();
            foreach(var noteId in noteIds)
            {
                sharedNotes.Add(_notesContext.Notes.FirstOrDefault(note => note.Id.Equals(noteId)));
            }
            return sharedNotes;
        }

        public bool CreateNotes(NotesModel notesModel, long userId)
        {
            try
            {
                Notes notes = new Notes();

                notes.Title = notesModel.Title;
                notes.Message = notesModel.Message;
                notes.Remainder = null;
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

        public bool IsPinned(long id, long noteId)
        {

            var result = _notesContext.Notes.FirstOrDefault(e => e.Userid == id && e.Id== noteId);
            
                if (result != null)
                {
                    if(result.isPin == true)
                    {
                        result.isPin = false;
                    }
                    else
                    {
                        result.isPin = true;
                    }
                   
                    _notesContext.SaveChanges();
                    return true;
                }
               
                return false;  
        }

        public bool ChangeColor(long id, long noteId, string color)
        {

            var result = _notesContext.Notes.FirstOrDefault(e => e.Userid == id && e.Color != color && e.Id == noteId);

            if (result != null)
            {
                result.Color = color;
                _notesContext.SaveChanges();
                return true;
            }

            return false;
        }

        public bool IsArchive(long id, long noteId)
        {

            var result = _notesContext.Notes.FirstOrDefault(e => e.Userid == id && e.Id == noteId);

            if (result != null)
            {
                if (result.isArchive == true)
                {
                    result.isArchive = false;
                }
                else
                {
                    result.isArchive = true;
                }
                _notesContext.SaveChanges();
                return true;
            }

            return false;
        }

        public bool IsTrash(long id, long noteId)
        {

            var result = _notesContext.Notes.FirstOrDefault(e => e.Userid == id && e.Id == noteId);

            if (result != null)
            {
                if (result.isTrash == true)
                {
                    result.isTrash = false;
                }
                else
                {
                    result.isTrash = true;
                }
                _notesContext.SaveChanges();
                return true;
            }

            return false;
        }

        public Notes GetNote(long id)
        {
            return _notesContext.Notes.Find(id);
        }

        public bool AddReminder(long id, long userId, ReminderModel reminderModel)
        {

            var result = _notesContext.Notes.FirstOrDefault(e => e.Id == id && e.Userid == userId);

            if (result != null)
            {
                //DateTime date = new DateTime();
                result.Remainder = reminderModel.ReminderDate;
                _notesContext.SaveChanges();

                return true;
            }

            return false;


        }
    }
}
