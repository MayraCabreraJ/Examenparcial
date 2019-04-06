using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIparcial1.Models;

namespace APIparcial1.Controllers
{
    public class MayraCabreraFriendsController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/MayraCabreraFriends
        public IQueryable<MayraCabreraFriend> GetMayraCabreraFriends()
        {
            return db.MayraCabreraFriends;
        }

        // GET: api/MayraCabreraFriends/5
        [ResponseType(typeof(MayraCabreraFriend))]
        public IHttpActionResult GetMayraCabreraFriend(int id)
        {
            MayraCabreraFriend mayraCabreraFriend = db.MayraCabreraFriends.Find(id);
            if (mayraCabreraFriend == null)
            {
                return NotFound();
            }

            return Ok(mayraCabreraFriend);
        }

        // PUT: api/MayraCabreraFriends/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMayraCabreraFriend(int id, MayraCabreraFriend mayraCabreraFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mayraCabreraFriend.FriendId)
            {
                return BadRequest();
            }

            db.Entry(mayraCabreraFriend).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MayraCabreraFriendExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MayraCabreraFriends
        [ResponseType(typeof(MayraCabreraFriend))]
        public IHttpActionResult PostMayraCabreraFriend(MayraCabreraFriend mayraCabreraFriend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MayraCabreraFriends.Add(mayraCabreraFriend);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mayraCabreraFriend.FriendId }, mayraCabreraFriend);
        }

        // DELETE: api/MayraCabreraFriends/5
        [ResponseType(typeof(MayraCabreraFriend))]
        public IHttpActionResult DeleteMayraCabreraFriend(int id)
        {
            MayraCabreraFriend mayraCabreraFriend = db.MayraCabreraFriends.Find(id);
            if (mayraCabreraFriend == null)
            {
                return NotFound();
            }

            db.MayraCabreraFriends.Remove(mayraCabreraFriend);
            db.SaveChanges();

            return Ok(mayraCabreraFriend);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MayraCabreraFriendExists(int id)
        {
            return db.MayraCabreraFriends.Count(e => e.FriendId == id) > 0;
        }
    }
}