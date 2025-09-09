using NoteFeature.Models.NoteModel;
using Microsoft.AspNetCore.Mvc;
using NoteFeature.Data;

namespace NoteFeature.Repositories
{
    public interface INoteRepo
    {
        List<Note> GetAllNote();
        List<Note> GetNotesByTitle(string title);
        List<Note> GetNoteByID(int id);
        void AddNote(Note note);
        void UpdateNote(Note note);
        void DeleteNote(Note note);
    }
    public class NoteRepo : INoteRepo
    {
        private readonly ApplicationDBContext _db;

        public NoteRepo(ApplicationDBContext db)
        {
            _db = db;
        }

        public List<Note> GetAllNote()
        {
            var allNote = _db.Notes
                            .Where(n => n.IsDeleted == false)
                            .ToList(); // All Note

            return allNote;
        }
        public List<Note> GetNotesByTitle(string title)
        {
            var notesByTitle = _db.Notes
                                .Where(n => n.Title.Contains(title) && n.IsDeleted == false)
                                .ToList(); // Notes filtered by title
            return notesByTitle;
        }
        public List<Note> GetNoteByID(int id)
        {
            var noteById = _db.Notes
                .Where(n => n.Id == id && n.IsDeleted == false)
                .ToList(); // Note filtered by ID
            return noteById;
        }
        public void AddNote(Note note)
        {
            note.IsDeleted = false;
            _db.Notes.Add(note);  //Add data to DB
            _db.SaveChanges();
        }
        public void UpdateNote(Note note)
        {
            note.UpdatedAt = DateTime.Now;
            _db.Notes.Update(note);

            _db.Entry(note).Property(x => x.CreatedAt).IsModified = false;

            _db.SaveChanges();
        }
        public void DeleteNote(Note note)
        {
            note.IsDeleted = true;
            note.UpdatedAt = DateTime.Now;
            _db.Notes.Update(note);
            _db.SaveChanges();
        }
    }
}
