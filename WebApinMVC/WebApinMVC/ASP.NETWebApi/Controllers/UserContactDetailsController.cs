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
using ASP.NETWebApi.Models;

namespace ASP.NETWebApi.Controllers
{
    public class UserContactDetailsController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/UserContactDetails
        public IQueryable<UserContactDetail> GetUserContactDetails()
        {
            return db.UserContactDetails;
        }

        // GET: api/UserContactDetails/5
        [ResponseType(typeof(UserContactDetail))]
        public IHttpActionResult GetUserContactDetail(int id)
        {
            UserContactDetail userContactDetail = db.UserContactDetails.Find(id);
            if (userContactDetail == null)
            {
                return NotFound();
            }

            return Ok(userContactDetail);
        }

        // PUT: api/UserContactDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserContactDetail(int id, UserContactDetail userContactDetail)
        {           
            if (id != userContactDetail.UserContactDetailUID)
            {
                return BadRequest();
            }

            db.Entry(userContactDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserContactDetailExists(id))
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

        // POST: api/UserContactDetails
        [ResponseType(typeof(UserContactDetail))]
        public IHttpActionResult PostUserContactDetail(UserContactDetail userContactDetail)
        {           
            db.UserContactDetails.Add(userContactDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = userContactDetail.UserContactDetailUID }, userContactDetail);
        }

        // DELETE: api/UserContactDetails/5
        [ResponseType(typeof(UserContactDetail))]
        public IHttpActionResult DeleteUserContactDetail(int id)
        {
            UserContactDetail userContactDetail = db.UserContactDetails.Find(id);
            if (userContactDetail == null)
            {
                return NotFound();
            }

            db.UserContactDetails.Remove(userContactDetail);
            db.SaveChanges();

            return Ok(userContactDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserContactDetailExists(int id)
        {
            return db.UserContactDetails.Count(e => e.UserContactDetailUID == id) > 0;
        }
    }
}