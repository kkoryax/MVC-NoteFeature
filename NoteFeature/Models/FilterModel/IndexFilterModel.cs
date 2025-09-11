namespace NoteFeature.Models.FilterModel
{
    public class IndexFilterModel
    {
        public string? SearchTitle { get; set; }
        //public string? SortBy  { get; set; }
        public string? SortDirection { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }


    }
}
