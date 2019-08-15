using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using ToDoList.Models;
using ToDoList.Models.DB;
using ToDoList.Models.Entities;
using ToDoList.Models.Identity;
using ToDoList.Models.MVC;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        private ApplicationUser GetUser()
        {
            return UserManager.Users.First(u => u.UserName == User.Identity.Name);
        }

        public ActionResult Index()
        {
            var id = GetUser().Id;
            var categories = db.Categories.Where(c => c.ApplicationUserId == id).Select(category => new MVCCategory
            {
                Id = category.Id,
                Value = category.Value,
                TasksCount = category.Tasks.Count
            }).ToList();
            return View(categories);
        }

        public ActionResult Create()
        {
            var id = GetUser().Id;
            ICollection<MVCPriority> priorities = db.Priorities
                .Select(p => new MVCPriority
                {
                    Id = p.Id,
                    Value = p.Value
                }).ToList();
            ICollection<MVCCategory> categories = db.Categories.Where(c => c.ApplicationUserId == id)
                .Select(p => new MVCCategory
                {
                    Id = p.Id,
                    Value = p.Value                    
                }).ToList();
            return View(new TaskModel
            {
                MyListPriorities = new SelectList(priorities, "Id", "Value", 1),
                MyListCategories = new SelectList(categories, "Id", "Value", 1)
            });
        }

        [HttpPost]
        public ActionResult Create(TaskModelPost task)
        {
            var id = GetUser().Id;
            if (ModelState.IsValid)
            {
                int category = int.Parse(task.MyListCategories) + 1;
                int priority = int.Parse(task.MyListPriorities) + 1;
                Task mytask = new Task()
                {
                    Name = task.Name,
                    Text = task.Text,
                    StartDate = task.StartDate.ToShortDateString(),
                    EndDate = task.EndDate.ToShortDateString(),
                    Category = db.Categories.Where(c => c.ApplicationUserId == id && c.Id == category).FirstOrDefault(),
                    Priority = db.Priorities.First(p => p.Id == priority),
                    Status = db.Statuses.First(p => p.Id == 1)
                };
                db.Tasks.Add(mytask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            TaskModel taskModel = new TaskModel
            {
                Name = task.Name,
                Text = task.Text,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                MVCStatus = task.Status,
                MyListCategories = new SelectList(db.Categories.Where(c => c.ApplicationUserId == id).Select(p => new MVCPriority
                {
                    Id = p.Id,
                    Value = p.Value
                }).ToList(), "Id", "Value", 1),
                MyListPriorities = new SelectList(db.Priorities.Select(p => new MVCCategory
                {
                    Id = p.Id,
                    Value = p.Value
                }).ToList(), "Id", "Value", 1)
            };
            return View(taskModel);
        }

        [HttpPost]
        public ActionResult GetTasks(int id)
        {
            var i = id;
            var tasks = db.Tasks
                .Where(t => t.Category.Id == id)
                .Select(task => new MVCTask
                {
                    Id = task.Id,
                    Name = task.Name,
                    Text = task.Text,
                    Status = task.Status.Value,
                    StartDate = task.StartDate,
                    EndDate = task.EndDate,
                    Category = task.Category.Value,
                    Priority = task.Priority.Value
                }).ToList();
            if (tasks.Count > 0)
                return PartialView("GetTasks", tasks);
            else
                return new HttpStatusCodeResult(404);
        }

        [HttpPost]
        public ActionResult GetFindTasks(string findtask)
        {
            JsonClass find = new JavaScriptSerializer().Deserialize<JsonClass>(findtask);
            int id = Int32.Parse(find.id);
            var tasks = db.Tasks
                .Where(t => t.Category.Id == id && t.Name.Contains(find.name))
                .Select(task => new MVCTask
                {
                    Id = task.Id,
                    Name = task.Name,
                    Text = task.Text,
                    Status = task.Status.Value,
                    StartDate = task.StartDate,
                    EndDate = task.EndDate,
                    Category = task.Category.Value,
                    Priority = task.Priority.Value
                }).ToList();
            if (tasks.Count > 0)
                return PartialView("GetTasks", tasks);
            else
                return new HttpStatusCodeResult(404);
        }

        [HttpPost]
        public ActionResult DoneTask(int[] tasks)
        {
            int ID = 0;
            foreach (var item in db.Tasks.Where(t => tasks.Contains(t.Id)).ToList())
            {
                ID = item.Category.Id;
                item.Status = db.Statuses.Where(s => s.Id == 2).First();
            }
            db.SaveChanges();

            return PartialView("DoneTask", db.Tasks
                .Where(t => t.Category.Id == ID)
                .Select(task => new MVCTask
                {
                    Id = task.Id,
                    Name = task.Name,
                    Text = task.Text,
                    Status = task.Status.Value,
                    StartDate = task.StartDate,
                    EndDate = task.EndDate,
                    Category = task.Category.Value,
                    Priority = task.Priority.Value
                }).ToList());
        }

        [HttpPost]
        public ActionResult MaskTask(int[] tasks)
        {
            return PartialView("MaskTask", db.Tasks
                .Where(t => tasks.Contains(t.Id))
                .Select(task => new MVCTask
                {
                    Id = task.Id,
                    Name = task.Name,
                    Text = task.Text,
                    Status = task.Status.Value,
                    StartDate = task.StartDate,
                    EndDate = task.EndDate,
                    Category = task.Category.Value,
                    Priority = task.Priority.Value
                }).ToList());
        }

        [HttpPost]
        public ActionResult DeleteTask(int[] tasks)
        {
            int ID = 0;
            foreach (var item in db.Tasks.Where(t => tasks.Contains(t.Id)).ToList())
            {
                ID = item.Category.Id;
                db.Tasks.Remove(item);
            }
            db.SaveChanges();

            return PartialView("DeleteTask", db.Tasks
                .Where(t => t.Category.Id == ID)
                .Select(task => new MVCTask
                {
                    Id = task.Id,
                    Name = task.Name,
                    Text = task.Text,
                    Status = task.Status.Value,
                    StartDate = task.StartDate,
                    EndDate = task.EndDate,
                    Category = task.Category.Value,
                    Priority = task.Priority.Value
                }).ToList());
        }

        [HttpPost]
        public ActionResult CreateCategory(string cat)
        {
            ICollection<string> CatNames = GetUser().Categories.Select(p => p.Value).ToList();
            if (!CatNames.Contains(cat))
            {
                db.Categories.Add(new Category { Value = cat, ApplicationUserId = GetUser().Id });
                db.SaveChanges();
                var id = GetUser().Id;
                return PartialView("CreateCategory", db.Categories.Where(c => c.ApplicationUserId == id).Select(category => new MVCCategory
                {
                    Id = category.Id,
                    Value = category.Value,
                    TasksCount = category.Tasks.Count
                }).ToList());
            }
            return new HttpStatusCodeResult(403);
        }

        [HttpPost]
        public ActionResult EditCategory(string cat)
        {
            var jsons = new JavaScriptSerializer().Deserialize<ICollection<JsonClass>>(cat).ToArray();
            int count = 0;
            foreach (var item in GetUser().Categories.ToList())
            {
                if (item.Id == Int32.Parse(jsons[count].id) && item.Value != jsons[count].name)
                {
                    db.Categories.Where(i => i.Id == item.Id).Single().Value = jsons[count].name;
                    item.Value = jsons[count].name;
                }
                ++count;
            }
            db.SaveChanges();
            var id = GetUser().Id;
            return PartialView("EditCategory", db.Categories.Where(c => c.ApplicationUserId == id).Select(category => new MVCCategory
            {
                Id = category.Id,
                Value = category.Value,
                TasksCount = category.Tasks.Count
            }).ToList());
        }

        [HttpPost]
        public ActionResult DeleteCategory(int[] cat)
        {
            foreach (var item in db.Categories.Where(t => cat.Contains(t.Id)).ToList())
            {
                db.Categories.Remove(item);
            }
            db.SaveChanges();
            var id = GetUser().Id;
            return PartialView("DeleteCategory", db.Categories.Where(c => c.ApplicationUserId == id).Select(category => new MVCCategory
            {
                Id = category.Id,
                Value = category.Value,
                TasksCount = category.Tasks.Count
            }).ToList());
        }

        [HttpPost]
        public ActionResult InfoTask(int info)
        {
            return PartialView("MoreInfo", db.Tasks.Where(t => t.Id == info).Select(task => new MVCTask
            {
                Id = task.Id,
                Name = task.Name,
                Status = task.Status.Value,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                Category = task.Category.Value,
                Priority = task.Priority.Value,
                Text = task.Text
            }).Single());
        }
    }
}