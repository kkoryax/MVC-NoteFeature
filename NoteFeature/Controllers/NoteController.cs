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
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Notes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note obj)
        {
            _db.Notes.Update(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
