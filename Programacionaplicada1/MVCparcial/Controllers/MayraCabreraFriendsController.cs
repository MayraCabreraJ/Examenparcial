using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCparcial.Models;

namespace MVCparcial.Controllers
{
    public class MayraCabreraFriendsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: MayraCabreraFriends
        public ActionResult Index()
        {
            return View(db.MayraCabreraFriends.ToList());
        }

        // GET: MayraCabreraFriends/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MayraCabreraFriend mayraCabreraFriend = db.MayraCabreraFriends.Find(id);
            if (mayraCabreraFriend == null)
            {
                return HttpNotFound();
            }
            return View(mayraCabreraFriend);
        }

        // GET: MayraCabreraFriends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MayraCabreraFriends/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FriendId,Name,DateType,TipoAmigo")] MayraCabreraFriend mayraCabreraFriend)
        {
            if (ModelState.IsValid)
            {
                db.MayraCabreraFriends.Add(mayraCabreraFriend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mayraCabreraFriend);
        }

        // GET: MayraCabreraFriends/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MayraCabreraFriend mayraCabreraFriend = db.MayraCabreraFriends.Find(id);
            if (mayraCabreraFriend == null)
            {
                return HttpNotFound();
            }
            return View(mayraCabreraFriend);
        }

        // POST: MayraCabreraFriends/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FriendId,Name,DateType,TipoAmigo")] MayraCabreraFriend mayraCabreraFriend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mayraCabreraFriend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mayraCabreraFriend);
        }

        // GET: MayraCabreraFriends/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MayraCabreraFriend mayraCabreraFriend = db.MayraCabreraFriends.Find(id);
            if (mayraCabreraFriend == null)
            {
                return HttpNotFound();
            }
            return View(mayraCabreraFriend);
        }

        // POST: MayraCabreraFriends/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MayraCabreraFriend mayraCabreraFriend = db.MayraCabreraFriends.Find(id);
            db.MayraCabreraFriends.Remove(mayraCabreraFriend);
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
