using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using System.Collections.Generic;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private static List<Task> Tasks = new List<Task>();

        public IActionResult Index()
        {
            return View(Tasks);
        }

        [HttpPost]
        public IActionResult AddTask(string description)
        {
            if (!string.IsNullOrEmpty(description))
            {
                Tasks.Add(new Task { Id = Tasks.Count + 1, Description = description });
            }
            return RedirectToAction("Index");
        }

        public IActionResult CompleteTask(int id)
        {
            var task = Tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTask(int id)
        {
            Tasks.RemoveAll(t => t.Id == id);
            return RedirectToAction("Index");
        }
    }
}
