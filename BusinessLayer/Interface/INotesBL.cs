//-----------------------------------------------------------------------
// <copyright file="INotesBL.cs" 
// </copyright>
// <author>Varun Brahmane</author>
//-----------------------------------------------------------------------

namespace BusinessLayer.Interface
{
    using System.Collections.Generic;
    using CommonLayer;
    using Microsoft.AspNetCore.Http;
    using RepositoryLayer.Entity;

    public interface INotesBL 
    {
        List<Notes> GetAllNotes(long id);
        List<Notes> GetBinNotes(long id);

        List<Notes> GetArchiveNotes(long id);

        public bool CreateNotes(NotesModel notesModel, long userId);

        public bool DeleteNotes(long id, long userId);

        public bool UpdateNotes(long id, long userId, NotesModel notesModel);

        public bool IsPinned(long id, long noteId);

        public bool ChangeColor(long id, long noteId, string color);

        public bool IsArchive(long id, long noteId);

        public bool IsTrash(long id, long noteId);

        public bool AddReminder(long id, long userId, ReminderModel reminderModel);

        public bool UploadImage(IFormFile file, long noteid);
        public bool DeleteImage(long noteid);
    } 
}
