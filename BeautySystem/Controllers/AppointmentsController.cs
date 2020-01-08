using BeautySystem.Models;
using DayPilot.Web.Mvc.Enums;
using DayPilot.Web.Mvc.Events.Calendar;
using DHTMLX.Scheduler;
using DHTMLX.Scheduler.Data;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautySystem.Controllers
{
    public class AppointmentsController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Appointments
        public async Task<ActionResult> Index()
        {
            //return View(await db.Appointments.ToListAsync());

            var sched = new DHXScheduler(this);
            sched.Skin = DHXScheduler.Skins.Terrace;
            sched.LoadData = true;
            sched.EnableDataprocessor = true;
            sched.Config.first_hour = 8;
            sched.Config.last_hour = 18;
            ///sched.InitialDate = DateTime.Today;
            sched.Config.start_on_monday = true;
            sched.DataAction = "Data";
            //sched.DataAction = context.RouteUrl(new {action = "Data", controller = "Appointment"});




            return View(sched);
            //return new Dps().CallBack(this);
        }

        //public JsonResult GetDiaryEvents(DateTime start, DateTime end)
        //{
        //    return Json(LoadAllAppointmentsInDateRange(start, end).Select(x => new
        //    {
        //        id = x.ID,
        //        title = x.Title,
        //        start = x.StartDateString,
        //        end = x.EndDateString,
        //        color = x.StatusColor,
        //        className = x.ClassName,
        //        someKey = x.SomeImportantKeyID,
        //        allDay = false
        //    }).ToArray(), JsonRequestBehavior.AllowGet);
        //}






        // GET: Appointments/Create
        public ActionResult Save(Event Event)

        {
            var data = context.Events.Add(Event);
            context.SaveChanges();
           // return View(data);
           return RedirectToAction("Index");
        }

        public ContentResult Data()
        {

            return (new SchedulerAjaxData(
                        context.Events.Select(e => new { id = e.id, start_date = e.start_date.ToString(), end_date = e.end_date, text = e.text })
                        // .Select(e => new { e.id, e.text, e.start_date, e.end_date })

                    )
                );
        }

        //public ActionResult Data()
        //{
        //    // var data = context.Events.ToList();

        //    var data= context.Events.ToList();


        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}


    }
}
