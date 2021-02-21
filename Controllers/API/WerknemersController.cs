using ProjectBeheerder.Models;
using ProjectBeheerder.Models.TrueModels;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ProjectBeheerder.Controllers.API
{
    public class WerknemersController : ApiController
    {
        private ApplicationDbContext ctx;

        public WerknemersController()
        {
            ctx = new ApplicationDbContext();
        }

        //GetAll
        public IHttpActionResult GetWerknemers(string query = null)
        {
            var werknemerQuery = ctx.Werknemers.Include(x => x.WerkPositie);

            if (!String.IsNullOrWhiteSpace(query))
            {
                werknemerQuery = werknemerQuery.Where(x => x.Name.Contains(query));
            }

            var werk = werknemerQuery.Include(x => x.WerkPositie).ToList();

            return Ok(werk);
        }

        //GetOne

        public IHttpActionResult GetEnkelWerknemer(int Id)
        {
            var werknemer = ctx.Werknemers.SingleOrDefault(x => x.Id == Id);

            if (werknemer == null)
            {
                return NotFound();
            }

            return Ok(werknemer);
        }

        //Update

        [HttpPut]
        public void UpdateWerknemer(int Id, Werknemer w)
        {
            
            var db = ctx.Werknemers.SingleOrDefault(x => x.Id == Id);

            if (db == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                db.Name = w.Name;
                db.WerkpositieId = w.WerkpositieId;

                ctx.SaveChanges();
            }
        }

        //Make
        [HttpPost]
        public IHttpActionResult CreateWerknemer(Werknemer w)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (w.Id == 0)
            {
                ctx.Werknemers.Add(w);
            }
            else
            {
                var db = ctx.Werknemers.Single(x => x.Id == w.Id);

                db.Name = w.Name;
                db.WerkpositieId = w.WerkpositieId;
                db.GeboorteDatum = w.GeboorteDatum;
            }

            ctx.SaveChanges();

             return Created(new Uri(Request.RequestUri + "/" + w.Id),w);
          //  return Ok();
        }

        //Delete
        [HttpDelete]
        public void DeleteWerknemer(int Id)
        {
            var db = ctx.Werknemers.Single(x => x.Id == Id);

            if (db == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            ctx.Werknemers.Remove(db);
            ctx.SaveChanges();
        }
    }
}

