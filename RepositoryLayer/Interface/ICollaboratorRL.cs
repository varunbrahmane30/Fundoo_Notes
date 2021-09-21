using RepositoryLayer.Entity;
using System.Collections.Generic;

namespace RepositoryLayer.Interface
{
    public interface ICollaboratorRL
    {
        
        public bool AddCollaborator(long noteId, long collaboratorId);
        public List<string> GetCollaboratorsId(long noteId);
        public bool DeleteCollaborator(long noteId, long collaboratorId);

    }
}
