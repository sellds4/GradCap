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
using GradCap.DAL;
using GradCap.Models;

namespace GradCap.Controllers
{
    [Authorize]
    [RoutePrefix("api/School")]
    public class SchoolController : ApiController
    {
        private GradCapContext db = new GradCapContext();

        // GET: api/School
        public IQueryable<School> GetSchools()
        {
            return db.Schools;
        }

        // GET: api/School/5
        /*[ResponseType(typeof(School))]
        public IHttpActionResult GetSchool(int id)
        {
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return NotFound();
            }

            return Ok(school);
        }*/

        // GET api/School/Name/SchoolName
        [Route("Name/{schoolName}")]
        public IHttpActionResult GetSchoolDetailsByName(string schoolName)
        {
            School school = db.Schools.FirstOrDefault(x => x.Name == schoolName);
            
            return Ok(school);
        }

        // GET api/School/State/StateName
        [Route("State/{stateName}")]
        public IHttpActionResult GetSchoolByName(string stateName)
        {
            List<School> schools = new List<School>();
            schools = db.Schools.Where(x => x.State.ToString() == stateName).ToList();

            return Ok(schools);
        }

        // PUT: api/School/5
        /*[ResponseType(typeof(void))]
        public IHttpActionResult PutSchool(int id, School school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != school.Id)
            {
                return BadRequest();
            }

            db.Entry(school).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolExists(id))
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

        // POST: api/School
        [ResponseType(typeof(School))]
        public IHttpActionResult PostSchool(School school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Schools.Add(school);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = school.Id }, school);
        }

        // DELETE: api/School/5
        [ResponseType(typeof(School))]
        public IHttpActionResult DeleteSchool(int id)
        {
            School school = db.Schools.Find(id);
            if (school == null)
            {
                return NotFound();
            }

            db.Schools.Remove(school);
            db.SaveChanges();

            return Ok(school);
        }*/

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SchoolExists(int id)
        {
            return db.Schools.Count(e => e.Id == id) > 0;
        }
    }
}