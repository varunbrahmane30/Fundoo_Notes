namespace RepositoryLayer.Interface
{
    using System.Collections.Generic;

    public interface ICollaboratorRL
    {
        
        public bool AddCollaborator(long noteId, long collaboratorId);
        public List<string> GetCollaboratorsId(long noteId);
        public bool DeleteCollaborator(long noteId, long collaboratorId);

    }
}
