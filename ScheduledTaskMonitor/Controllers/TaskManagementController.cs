
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using ScheduledTaskMonitor.Models;
using Microsoft.Win32.TaskScheduler;

namespace ScheduledTaskMonitor.Controllers
{
    public class TaskManagementController : Controller
    {
        //
        // GET: /
        [AllowAnonymous]
        public ActionResult TaskList()
        {
            TaskManagementEntities taskEntities = new TaskManagementEntities();
            return View(taskEntities.TaskInfos);
        }

        //
        // POST: /Add
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Add(TaskInfo tInfo)
        {
            try
            {
                using (var taskEntities = new TaskManagementEntities())
                {
                    taskEntities.TaskInfos.Add(tInfo);
                    taskEntities.SaveChanges();
                    return View(taskEntities.TaskInfos);
                }
            }
            catch { return View(); }
        }

        [AllowAnonymous]
        public ActionResult FindTask(string MachineName, string taskName)
        {
            TaskService tServ = new TaskService(MachineName);
            Microsoft.Win32.TaskScheduler.Task t = tServ.FindTask(taskName);
            TaskInfo tInfo = new TaskInfo(t);
            return View();
        }
    }
}
