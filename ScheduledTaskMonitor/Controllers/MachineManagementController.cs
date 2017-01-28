using ScheduledTaskMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScheduledTaskMonitor.Controllers
{
    public class MachineManagementController : Controller
    {
        public ActionResult Index()
        {
            TaskManagementEntities machineInfoModel = new TaskManagementEntities();
            return View(machineInfoModel.MachineInfos);
        }
        // GET: MachineManagement
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(MachineInfo machineInfo)
        {
            try
            {
                // TODO: Add insert logic here
                machineInfo.Created_By = "WEB_API_POST";
                machineInfo.Created_Date = System.DateTime.Now.ToShortDateString();
                using (var taskEntities = new TaskManagementEntities())
                {
                    taskEntities.MachineInfos.Add(machineInfo);
                    taskEntities.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch { return View(); }
        }
    }
}