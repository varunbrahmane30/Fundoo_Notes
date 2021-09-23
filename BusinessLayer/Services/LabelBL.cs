﻿using BusinessLayer.Interface;
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

        public bool DeleteLabel(long labelId)
        {
            try
            {
                return _labelRL.DeleteLabel(labelId);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool UpdateLabel(long labelId, AddLabelRequest label)
        {
            try
            {
                return _labelRL.UpdateLabel(labelId, label);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
