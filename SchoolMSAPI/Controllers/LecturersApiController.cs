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
using SchoolMSAPI.Models;

namespace SchoolMSAPI.Controllers
{
    public class LecturersApiController : ApiController
    {
        private SchoolManagmentS_DBEntities db = new SchoolManagmentS_DBEntities();

        // GET: api/LecturersApi
        public IQueryable<Lecturer> GetLecturers()
        {
            return db.Lecturers;
        }

        // GET: api/LecturersApi/5
        [ResponseType(typeof(Lecturer))]
        public IHttpActionResult GetLecturer(int id)
        {
            Lecturer lecturer = db.Lecturers.Find(id);
            if (lecturer == null)
            {
                return NotFound();
            }

            return Ok(lecturer);
        }

        // PUT: api/LecturersApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLecturer(int id, Lecturer lecturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lecturer.Id)
            {
                return BadRequest();
            }

            db.Entry(lecturer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LecturerExists(id))
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

        // POST: api/LecturersApi
        [ResponseType(typeof(Lecturer))]
        public IHttpActionResult PostLecturer(Lecturer lecturer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Lecturers.Add(lecturer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lecturer.Id }, lecturer);
        }

        // DELETE: api/LecturersApi/5
        [ResponseType(typeof(Lecturer))]
        public IHttpActionResult DeleteLecturer(int id)
        {
            Lecturer lecturer = db.Lecturers.Find(id);
            if (lecturer == null)
            {
                return NotFound();
            }

            db.Lecturers.Remove(lecturer);
            db.SaveChanges();

            return Ok(lecturer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LecturerExists(int id)
        {
            return db.Lecturers.Count(e => e.Id == id) > 0;
        }
    }
}