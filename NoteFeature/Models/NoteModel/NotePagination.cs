using NoteFeature.Models.NoteModel;
//Pagination template from P'TAR project

namespace NoteFeature.Models.NotePagination
{
    public class NotePagination
    {
        public int PerPage { get; set; } = 10;
        public int Page { get; set; } = 1;
        public int Offset { get; set; } = 0;
        public int Total { get; set; } = 0;

        // Display
        public List<Note> Notes { get; set; } = new List<Note>(); //GET Note data

    }
}