using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class NotesModel
    {
        
        public string Title { get; set; }
        
        public String Message { get; set; }

        public string Color { get; set; }

        public string Image { get; set; }

        public bool IsArchive { get; set; }

        public bool IsTrash { get; set; }
        public List<string> Labels { get; set; }

    }
}
