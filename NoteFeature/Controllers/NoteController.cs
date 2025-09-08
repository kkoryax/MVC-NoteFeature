using Microsoft.AspNetCore.Mvc;
using NoteFeature.Data;
using NoteFeature.Models;

namespace NoteFeature.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationDBContext _db;

        public NoteController(ApplicationDBContext db)
        {
            _db = db;
        }
        //DEPENDENCY INJECTION

        public IActionResult Index()
        {
            var note_1 = new Note
            {
                Id = 1,
                Title = "Note 1",
                Content = "This is the content of note 1.",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var note_2 = new Note
            {
                Id = 1,
                Title = "Note 2",
                Content = "This is the content of note 2.",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            List<Note> notes = new List<Note>();
            notes.Add(note_1);
            notes.Add(note_2);

            return View(notes);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
