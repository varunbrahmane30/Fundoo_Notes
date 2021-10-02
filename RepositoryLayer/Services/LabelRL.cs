namespace RepositoryLayer.Services
{
    using System;
    using System.Linq;
    using CommonLayer;
    using RepositoryLayer.Context;
    using RepositoryLayer.Entity;
    using RepositoryLayer.Interface;
    public class LabelRL : ILabelRL
    {
        readonly private UserContext _labelContext;

        public LabelRL(UserContext labelContext)
        {
            _labelContext = labelContext;
        }
        public bool AddLabel(long noteId, AddLabelRequest label)
        {
            try
            {
                Label labels = new Label()
                {
                    Name = label.Label
                };
               
                _labelContext.Add(labels);

                int result = _labelContext.SaveChanges();
                var labelData = this.GetByName(labels.Name);
                AddLabelToNote(noteId, labelData);

                if (result > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public bool DeleteLabel(long labelId)
        {
            try
            {
                var result = _labelContext.Label.FirstOrDefault(e => e.Id == labelId);
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

        public bool UpdateLabel(long labelId, AddLabelRequest label)
        {
            try
            {
                var result = _labelContext.Label.FirstOrDefault(e => e.Id == labelId);
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

        private void AddLabelToNote(long noteId,Label label)
        {
            NotesLabel notesLabel = new NotesLabel()
            {
                NotesId = noteId,
                LabelId = label.Id
            };

            _labelContext.NotesLabel.Add(notesLabel);

            _labelContext.SaveChanges();
        }

        private Label GetByName(string name)
        {
            return _labelContext.Label.FirstOrDefault(e => e.Name.Equals(name));
        }
    }
}
