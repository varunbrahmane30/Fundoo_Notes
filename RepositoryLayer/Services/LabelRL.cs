using CommonLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Linq;

namespace RepositoryLayer.Services
{
    public class LabelRL : ILabelRL
    {
        private UserContext _labelContext;

        public LabelRL(UserContext labelContext)
        {
            _labelContext = labelContext;
        }
        public bool AddLabel(long noteId, AddLabelRequest label)
        {
            try
            {
                Label labels = new Label();
                labels.Name = label.Label;

                _labelContext.Add(labels);

                int result = _labelContext.SaveChanges();
                var labelData = GetByName(labels.Name);
                addLabelToNote(noteId, labelData);

                if (result > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch
            {
                throw;
            }
        }

        public bool DeleteLabel(long noteId, AddLabelRequest label)
        {
            try
            {
                var result = _labelContext.Label.FirstOrDefault(e => e.Id == noteId && e.Name == label.Label);
                if (result != null)
                {
                    _labelContext.Label.Remove(result);
                    _labelContext.SaveChanges();

                    return true;
                }

                return false;

            }
            catch
            {
                throw;
            }
        }

        public bool UpdateLabel(long noteId, AddLabelRequest label)
        {
            try
            {
                var result = _labelContext.Label.FirstOrDefault(e => e.Id == noteId);
                if (result != null)
                {
                    result.Name = label.Label;
                    _labelContext.SaveChanges();

                    return true;
                }

                return false;

            }
            catch
            {
                throw;
            }
        }

        private void addLabelToNote(long noteId, Label label)
        {
            NotesLabel notesLabel = new NotesLabel();
            notesLabel.NotesId = noteId;
            notesLabel.LabelId = label.Id;
            _labelContext.NotesLabel.Add(notesLabel);

            _labelContext.SaveChanges();
        }

        private Label GetByName(string name)
        {
            return _labelContext.Label.FirstOrDefault(e => e.Name.Equals(name));
        }
    }
}
