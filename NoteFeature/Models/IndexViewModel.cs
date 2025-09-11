using NoteFeature.Models.NoteModel;
using NoteFeature.Models.FilterModel;
using System.Collections.Generic;

namespace NoteFeature.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Note> Notes { get; set; } = new List<Note>();
        public IndexFilterModel Filter { get; set; } = new IndexFilterModel();
        //public NotePagination.NotePagination Pagination { get; set; } = new NotePagination.NotePagination();
    }
}
