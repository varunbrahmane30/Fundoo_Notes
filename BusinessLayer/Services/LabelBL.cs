using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class LabelBL : ILabelBL
    {
        
        private ILabelRL _labelRL;
        public LabelBL(ILabelRL labelRL)
        {
            this._labelRL = labelRL;
           
        }
        public bool AddLabel(long noteId,AddLabelRequest label)
        {
            try
            {
                return _labelRL.AddLabel(noteId,label);
            }
            catch (Exception)
            {
                throw;
            }

           
        }

        public bool DeleteLabel(long noteId, AddLabelRequest label)
        {
            try
            {
                return _labelRL.DeleteLabel(noteId, label);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool UpdateLabel(long noteId, AddLabelRequest label)
        {
            try
            {
                return _labelRL.UpdateLabel(noteId, label);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
