using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ILabelRL
    {
        public bool AddLabel(long noteId,AddLabelRequest label);
        public bool DeleteLabel(long noteId, AddLabelRequest label);
        public bool UpdateLabel(long noteId, AddLabelRequest label);

    }
}
