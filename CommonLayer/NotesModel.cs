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

        public string image { get; set; }

        public bool isArchive { get; set; }

        public bool isTrash { get; set; }
        public List<string>? Labels { get; set; }

    }
}
