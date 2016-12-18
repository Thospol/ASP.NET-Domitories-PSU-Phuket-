using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Room.Models;

namespace Room.Controllers
{
    public class RoomaddsController : Controller
    {
        private RoomContext db = new RoomContext();

        // GET: Roomadds

        /*public ActionResult Index()
        {
            return View(db.Roomadds.ToList());
        }
        */

        public ActionResult Room(string movieGenre, string searchString) {

            var Roomadds = from m in db.Roomadds
                           select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                if (movieGenre == "1")
                {

                    Roomadds = Roomadds.Where(s => s.RoomNo.Contains(searchString));
                }
                else if (movieGenre == "2")
                {
                    Roomadds = Roomadds.Where(s => s.Roomtype.Contains(searchString));
                }
                else if (movieGenre == "3")
                {
                    Roomadds = Roomadds.Where(s => s.StudentID.Contains(searchString));
                }


                //Roomadds = Roomadds.Where(s => s.Price.Contains(searchString));
                //Roomadds = Roomadds.Where(s => s.Status.Contains(searchString));
                //Roomadds = Roomadds.Where(s => s.StudentID.Contains(searchString));
            }



            return View(Roomadds);
        }

        public ActionResult Index(string movieGenre, string searchString)
        {

          

            var Roomadds = from m in db.Roomadds
                         select m;
            

            if (!String.IsNullOrEmpty(searchString))
            {
                if (movieGenre == "1") {

                    Roomadds = Roomadds.Where(s => s.RoomNo.Contains(searchString));
                } else if (movieGenre == "2")
                {
                    Roomadds = Roomadds.Where(s => s.Roomtype.Contains(searchString));
                }
                else if (movieGenre == "3")
                {
                    Roomadds = Roomadds.Where(s => s.StudentID.Contains(searchString));
                }


                //Roomadds = Roomadds.Where(s => s.Price.Contains(searchString));
                //Roomadds = Roomadds.Where(s => s.Status.Contains(searchString));
                //Roomadds = Roomadds.Where(s => s.StudentID.Contains(searchString));
            }

           

          

            
            return View(Roomadds);
        }

        [HttpPost]
        public string Index(FormCollection fc, string searchString)
        {
            return "<h3> From [HttpPost]Index: " + searchString + "</h3>";
        }



       


        // GET: Roomadds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roomadd roomadd = db.Roomadds.Find(id);


          


            if (roomadd == null)
            {
                return HttpNotFound();
            }
            return View(roomadd);
        }

        // GET: Roomadds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roomadds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RoomNo,Roomtype,Price,Status,StudentID,StudentID2")] Roomadd roomadd)
        {
            if (ModelState.IsValid)
            {
                db.Roomadds.Add(roomadd);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        

            

            return View(roomadd);
        }

        // GET: Roomadds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roomadd roomadd = db.Roomadds.Find(id);

           


            if (roomadd == null)
            {
                return HttpNotFound();
            }

            return View(roomadd);

            
        }

        // POST: Roomadds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RoomNo,Roomtype,Price,Status,StudentID,StudentID2")] Roomadd roomadd)
        {
            //Roomadd roomadds = db.Roomadds.Find();
            if (ModelState.IsValid)
            {
                db.Entry(roomadd).State = EntityState.Modified;
                db.SaveChanges();

                var update = db.Students.Where(o => (o.StudentID == roomadd.StudentID)).FirstOrDefault();

                if (update != null)
                {
                    update.RoomNo = roomadd.RoomNo;
                    db.SaveChanges();
                }

                var update2 = db.Students.Where(o => (o.StudentID == roomadd.StudentID2)).FirstOrDefault();

                if (update2 != null)
                {
                    update2.RoomNo = roomadd.RoomNo;
                    db.SaveChanges();
                }

                var obj = db.Roomadds.Where(x => x.StudentID != null && x.StudentID2 != null && x.RoomNo == roomadd.RoomNo).FirstOrDefault(); ;
                if (obj != null)
                {
                    obj.Status = roomadd.Status = "Busy";
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

           


          

            return View(roomadd);
        }

        // GET: Roomadds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roomadd roomadd = db.Roomadds.Find(id);
            if (roomadd == null)
            {
                return HttpNotFound();
            }
            return View(roomadd);
        }

        // POST: Roomadds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Roomadd roomadd = db.Roomadds.Find(id);
            db.Roomadds.Remove(roomadd);
            db.SaveChanges();
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
