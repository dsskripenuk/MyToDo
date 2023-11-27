using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Test_Task_Shop_Express.Models;

namespace Test_Task_Shop_Express.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string sortOrder, string filter)
        {
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Title_desc" : "";

            var tasks = _context.Tasks.ToList();

            switch (sortOrder)
            {
                case "Title_desc":
                    tasks = tasks.OrderByDescending(t => t.Title).ToList();
                    break;
                default:
                    tasks = tasks.OrderBy(t => t.Title).ToList();
                    break;
            }

            if (filter == "completed")
            {
                tasks = tasks.Where(t => !t.IsDone).ToList();
            }

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Update(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(task);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
