using Microsoft.AspNetCore.Mvc;
using NoteFeature.Data;
using NoteFeature.Migrations;
using NoteFeature.Models.FilterModel;
using NoteFeature.Models.ViewModels;
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

        public IActionResult Index(IndexFilterModel filter)
        {
            if (filter == null)
            {
                filter = new IndexFilterModel();
            }

            List<Note> notes;
            if (!string.IsNullOrEmpty(filter.SearchTitle)
                || !string.IsNullOrEmpty(filter.SortBy)
                || filter.FromDate.HasValue
                || filter.ToDate.HasValue)
            {
                notes = _noteRepo.FilterNote(filter);
            }
            else
            {
                notes = _noteRepo.GetAllNote();
            }

            var ViewModel = new IndexViewModel
            {
                Notes = notes,
                Filter = filter
            };

            return View(ViewModel);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                _noteRepo.AddNote(note);
            }

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var note = _noteRepo.GetNoteByID(id.Value).FirstOrDefault();
            return View(note);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note note)
        {
            if (ModelState.IsValid)
            {
                _noteRepo.UpdateNote(note);
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var note = _noteRepo.GetNoteByID(id.Value).FirstOrDefault();
            if (note == null)
            {
                return NotFound();
            }
            _noteRepo.DeleteNote(note);

            return RedirectToAction("Index");
        }
        public IActionResult Detail(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var note = _noteRepo.GetNoteByID(id.Value).FirstOrDefault();
            return View(note);
        }
    }
}
