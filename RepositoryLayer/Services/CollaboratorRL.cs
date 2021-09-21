using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer.Services
{
    public class CollaboratorRL: ICollaboratorRL
    {
        private UserContext _collaboratorContext;

        public CollaboratorRL(UserContext collaboratorContext)
        {
            _collaboratorContext = collaboratorContext;
        }

        public bool AddCollaborator(long noteId, long collaboratorId)
        {
            _collaboratorContext.Collaborators.Add(new Entity.Collaborator()
            {
                NoteId = noteId,
                UserId = collaboratorId
            }); 
            return _collaboratorContext.SaveChanges() > 0;
        }

        public bool DeleteCollaborator(long noteId, long collaboratorId)
        {
            _collaboratorContext.Collaborators.Remove(_collaboratorContext.Collaborators.Single(c => c.NoteId.Equals(noteId) && c.UserId.Equals(collaboratorId)));
            return _collaboratorContext.SaveChanges() > 0;
        }
        public List<string> GetCollaboratorsId(long noteId)
        {
            var result = _collaboratorContext.Collaborators.Where(c => c.NoteId.Equals(noteId)).Select(c => c.UserId).ToList();
            List<string> Emails = new List<string>();
            foreach(var item in result)
            {
                Emails.Add(GetUserEmailById(item));
            }

            return Emails;
        }
        public string GetUserEmailById(long id)
        {
           
           var userData= _collaboratorContext.Users.Find(id);

            return userData.Email;

        }
    }
}
