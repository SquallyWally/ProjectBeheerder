using ProjectBeheerder.Models;
using ProjectBeheerder.Models.TrueModels;
using ProjectBeheerder.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ProjectBeheerder.Controllers
{
    public class WerknemersController : Controller
    {
        private ApplicationDbContext ctx;

        public WerknemersController()
        {
            ctx = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
        }

        // GET: Werknemers
        public ActionResult Index()
        {
            var werknemers = ctx.Werknemers.Include(x => x.WerkPositie).ToList();
            return View(werknemers);
        }

        public ActionResult Details(int Id)
        {
            var werknemer = ctx.Werknemers.Include(x => x.WerkPositie).SingleOrDefault(x => x.Id == Id);

            if (werknemer == null)
            {
                return HttpNotFound();
            }

            return View(werknemer);
        }

        public ActionResult WerknemerForm()
        {
            var werkposities = ctx.Werkposities.ToList();

            var vm = new WerknemerFormViewModel
            {
                Werknemer = new Werknemer(),
                Werkposities = werkposities
            };

            return View("WerknemerForm", vm);
        }

        [HttpPost]
        public ActionResult Opslaan(Werknemer werknemer)
        {
            if (!ModelState.IsValid)
            {
                var werkposities = ctx.Werkposities.ToList();
                var vm = new WerknemerFormViewModel
                {
                    Werknemer = werknemer,
                    Werkposities = werkposities
                };
                return View("WerknemerForm", vm);
            }

            if (werknemer.Id == 0)
            {
                ctx.Werknemers.Add(werknemer);
            }
            else
            {
                var werkDb = ctx.Werknemers.Single(x => x.Id == werknemer.Id);

                werkDb.Name = werknemer.Name;
                werkDb.GeboorteDatum = werknemer.GeboorteDatum;
                werkDb.WerkpositieId = werknemer.WerkpositieId;
            }

            ctx.SaveChanges();
            return RedirectToAction("Index", "Werknemers");
        }

        
        public ActionResult Edit(int id)
        {
            var werknemer = ctx.Werknemers.SingleOrDefault(x => x.Id == id);

            if(werknemer == null)
            {
                return HttpNotFound();
            }

            var werkposities = ctx.Werkposities.ToList();
            var vm = new WerknemerFormViewModel
            {
                Werknemer = werknemer,
                Werkposities = werkposities
            };
            return View("WerknemerForm", vm);
        }
    }
}