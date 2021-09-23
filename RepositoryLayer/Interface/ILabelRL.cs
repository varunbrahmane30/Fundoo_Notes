using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ILabelRL
    {
        public bool AddLabel(long noteId,AddLabelRequest label);
        public bool DeleteLabel(long labelId);
        public bool UpdateLabel(long labelId, AddLabelRequest label);

    }
}
