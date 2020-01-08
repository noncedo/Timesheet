using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BeautySystem.Models;
using WebGrease.Css.Extensions;

namespace BeautySystem.Controllers
{
    public class EmployeeProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        //public string CalculateProjectHours()
        //{
          
        //    var result = db.EmployeeProjects.Select(x => new TimeSheetViewModel()
        //    {
        //        //ProjectId = x.ProjectId,
              
        //        ////FullName = x.Employee.FullName,
        //        ////Surname = x.Employee.Surname,
        //        ////Name = x.Employee.Name,
                
        //        //HoursWorked = x.HoursWorked,
        //        //ClientId = x.ClientId
        //        Employee = x.Employee,
        //        Project = x.Project,
        //        Client = x.Client
                

        //    }).GroupBy(x => x.Project.ProjectId).Select(x => new TimeSheetViewModel()
        //    {
        //        //ProjectId = x.FirstOrDefault().ProjectId,
        //        ////FullName = x.FirstOrDefault().FullName,
        //        //Name = x.FirstOrDefault().Name,
        //        //Surname = x.FirstOrDefault().Surname,
        //        HoursWorked = x.Sum(y=>y.HoursWorked),
        //        //ClientId = x.FirstOrDefault().ClientId


        //    }).ToList();

        //    return result;

        //}


        // GET: EmployeeProjects
        public async Task<ActionResult> Index()
        {
            var employeeProjects = db.EmployeeProjects.Include(e => e.Client).Include(e => e.Employee).Include(e => e.Project);
            return View(await employeeProjects.ToListAsync());
           
        }

        public ActionResult ProjectHours()
        {
            var result = db.EmployeeProjects.Include(x => x.Client)
                .Include(x => x.Employee).Include(x => x.Project).ToList();

            var query = result.Select(x => new TimeSheetViewModel()
            {
                ProjectId = x.ProjectId,
                FullName = x.Employee.FullName,
                Name = x.Client.Name,
                HoursWorked = x.HoursWorked,
                ClientId = x.ClientId,
                ProjectName = x.Project.ProjectName,
                Date = x.Date,


                Employee = x.Employee,
                Project = x.Project,
                Client = x.Client

            }).GroupBy(x => x.Project.ProjectId).Select(x => new TimeSheetViewModel()
            {

                ProjectId = x.FirstOrDefault().ProjectId,
                FullName = x.FirstOrDefault().FullName,
                Name = x.FirstOrDefault().Client.Name,
                Surname = x.FirstOrDefault().Surname,
                HoursWorked = x.Sum(y => y.HoursWorked),
                ClientId = x.FirstOrDefault().ClientId,
                ProjectName = x.FirstOrDefault().ProjectName,
                Date = x.FirstOrDefault().Date


            }).ToList();

            return View(query.ToList());
        }

        // GET: EmployeeProjects/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProject employeeProject = await db.EmployeeProjects.FindAsync(id);
            if (employeeProject == null)
            {
                return HttpNotFound();
            }
            return View(employeeProject);
        }

        // GET: EmployeeProjects/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name");
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name");
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName");
            return View();
        }

        // POST: EmployeeProjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmployeeProjectId,EmployeeId,ProjectId,ClientId,HoursWorked,Date")] EmployeeProject employeeProject)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeProjects.Add(employeeProject);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name", employeeProject.ClientId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", employeeProject.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", employeeProject.ProjectId);
            return View(employeeProject);
        }

        // GET: EmployeeProjects/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProject employeeProject = await db.EmployeeProjects.FindAsync(id);
            if (employeeProject == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name", employeeProject.ClientId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", employeeProject.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", employeeProject.ProjectId);
            return View(employeeProject);
        }

        // POST: EmployeeProjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EmployeeProjectId,EmployeeId,ProjectId,ClientId,HoursWorked,Date")] EmployeeProject employeeProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeProject).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name", employeeProject.ClientId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", employeeProject.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", employeeProject.ProjectId);
            return View(employeeProject);
        }

        // GET: EmployeeProjects/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeProject employeeProject = await db.EmployeeProjects.FindAsync(id);
            if (employeeProject == null)
            {
                return HttpNotFound();
            }
            return View(employeeProject);
        }

        // POST: EmployeeProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EmployeeProject employeeProject = await db.EmployeeProjects.FindAsync(id);
            db.EmployeeProjects.Remove(employeeProject);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
