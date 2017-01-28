
using Microsoft.Win32.TaskScheduler;
using ScheduledTaskMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScheduledTaskMonitor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Task> tasks = new List<Task>() { };
            /*
            using (TaskService ts = new TaskService("", "", "", ""))
            {
                tasks = ts.AllTasks;   
            }*/
            return View(tasks);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult _SidebarModel()
        {
            TaskManagementEntities taskEntities = new TaskManagementEntities();
            return PartialView(new SidebarModel(
                taskEntities.TaskInfoNames,
                taskEntities.MachineInfoNames
             ));
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET: ScheduledTask/Details/5
        public ActionResult Details()
        {

            return View();
        }


        // GET: ScheduledTask/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScheduledTask/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ScheduledTask/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ScheduledTask/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ScheduledTask/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ScheduledTask/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
