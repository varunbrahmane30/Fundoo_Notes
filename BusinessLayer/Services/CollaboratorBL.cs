using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class CollaboratorBL : ICollaboratorBL
    {
        private INotesRL _notesRL;
        private IUserRL _userRL;
        private ICollaboratorRL _collaboratorRL;
        public CollaboratorBL(INotesRL notesRL, IUserRL userRL, ICollaboratorRL collaboratorRL)
        {
            this._notesRL = notesRL;
            _userRL = userRL;
            _collaboratorRL = collaboratorRL;
        }

       

        public bool AddCollborators(long userId, long id, AddCollaboratorRequest collaborator)
        {
            // check note is of userId
            // check collaborator email exists
            // add collaborator entry into table
            var note = _notesRL.GetNote(id);
            if (!note.Userid.Equals(userId))
            {
                // userId is not author of note with given id
                return false;
            }
            var user = _userRL.GetUserByEmail(collaborator.EmailId);
            if (user == null)
            {
                // no user found with given emailId
                return false;
            }
            return _collaboratorRL.AddCollaborator(id, user.Id);
        }

        public bool DeleteCollborators(long userId, long id, AddCollaboratorRequest collaborator)
        {
            // check note is of userId
            // check collaborator email exists
            // add collaborator entry into table
            var note = _notesRL.GetNote(id);
            if (!note.Userid.Equals(userId))
            {
                // userId is not author of note with given id
                return false;
            }
            var user = _userRL.GetUserByEmail(collaborator.EmailId);
            if (user == null)
            {
                // no user found with given emailId
                return false;
            }
            return _collaboratorRL.DeleteCollaborator(id, user.Id);
        }

        public List<string> GetCollaboratorsId(long noteId)
        {
             try
                {
                    return this._collaboratorRL.GetCollaboratorsId(noteId);
                }
                catch (Exception)
                {
                    throw;
                }  
        }
    }
}
