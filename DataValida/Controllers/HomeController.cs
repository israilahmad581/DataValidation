using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataValida.Models;
using System.Net;

namespace DataValida.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        EmpContext emct = new EmpContext();

        public ActionResult Index()
        {
            return View(emct.EmpDetails.ToList());
        }



        // for create the record
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpDetail ed)
        {
            if (ModelState.IsValid)
            {
                emct.EmpDetails.Add(ed);
                emct.SaveChanges();
                return RedirectToAction("Index");
            }


            return View();
        }

        //for edit the record
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Emp id requierd....");
            }
            EmpDetail empdetail = emct.EmpDetails.Find(id);
            if (empdetail == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Emp id not found....");
            }
            return View(empdetail);
        }
        [HttpPost]
        public ActionResult Edit(int id)
        {
            EmpDetail empdetail = emct.EmpDetails.Find(id);
            UpdateModel(empdetail);
            emct.SaveChanges();
            return RedirectToAction("Index");
        }

        //for delete the record....
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Emp id requierd....");
            }
            EmpDetail empdetail = emct.EmpDetails.Find(id);
            if (empdetail == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Emp id not found....");
            }
            return View(empdetail);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmpDetail empdetail = emct.EmpDetails.Find(id);
            emct.EmpDetails.Remove(empdetail);
            emct.SaveChanges();
            return RedirectToAction("Index");
        }

        //for showing the details 
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Emp id requierd....");
            }
            EmpDetail empdetail = emct.EmpDetails.Find(id);
            if (empdetail == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Emp id not found....");
            }
            return View(empdetail);
        }
    
    } 
    }
