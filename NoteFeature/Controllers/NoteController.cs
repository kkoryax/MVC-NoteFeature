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
            IEnumerable <Note> allNote = _db.Notes;

            return View(allNote);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note obj)
        {
            _db.Notes.Add(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
