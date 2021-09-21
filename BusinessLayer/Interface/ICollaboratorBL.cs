using CommonLayer;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface ICollaboratorBL
    {
        public List<string> GetCollaboratorsId(long noteId);
        public bool AddCollborators(long userId, long id, AddCollaboratorRequest collaborators);
        public bool DeleteCollborators(long userId, long id, AddCollaboratorRequest collaborators);
    }

}
