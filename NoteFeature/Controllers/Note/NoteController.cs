using Microsoft.AspNetCore.Mvc;
using NoteFeature.Data;
using NoteFeature.Models.NoteModel;
using NoteFeature.Repositories;

namespace NoteFeature.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteRepo _noteRepo;

        public NoteController(INoteRepo noteRepo)
        {
            _noteRepo = noteRepo;
        }
        //DEPENDENCY INJECTION from Repositoies Constructor

        public IActionResult Index()
        {
            var notes = _noteRepo.GetAllNote();

            // Debug (Data check)
            foreach (var note in notes)
            {
                Console.WriteLine($"Id: {note.Id}, Title: {note.Title}, Content: {note.Content}");
            }

            return View(notes);
        }
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Note obj)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        _db.Notes.Add(obj);
        //        _db.SaveChanges();
        //    }

        //    return RedirectToAction("Index");
        //}
        public IActionResult Edit()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(Note obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        obj.UpdatedAt = DateTime.Now;
        //        _db.Notes.Update(obj);

        //        _db.Entry(obj).Property(x => x.CreatedAt).IsModified = false;

        //        _db.SaveChanges();
        //    }

        //    return RedirectToAction("Index");
        //}
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var obj = _db.Notes.Find(id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    _db.Notes.Remove(obj);
        //    _db.SaveChanges();

        //    return RedirectToAction("Index");
        //}
        //public IActionResult Detail(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    var obj = _db.Notes.Find(id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(obj);
        //}
    }
}
