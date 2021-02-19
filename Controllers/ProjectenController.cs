using ProjectBeheerder.Models;
using ProjectBeheerder.Models.TrueModels;
using ProjectBeheerder.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ProjectBeheerder.Controllers
{
    public class ProjectenController : Controller
    {
        private ApplicationDbContext ctx;

        public ProjectenController()
        {
            ctx = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            ctx.Dispose();
        }

        // GET: Projecten
        public ActionResult Index()
        {
            var projecten = ctx.Projecten.Include(x => x.Categorie).ToList();
            return View(projecten);
        }

        public ActionResult ProjectenForm()
        {
            var category = ctx.Categories.ToList();

            var vm = new ProjectFormViewModel
            {
                Categories = category
            };

            return View("ProjectenForm", vm);
        }

        [HttpPost]
        public ActionResult Opslaan(Project project)
        {
            if (!ModelState.IsValid)
            {
                var category = ctx.Categories.ToList();

                var vm = new ProjectFormViewModel
                {
                    Categories = category
                };
                return View("ProjectenForm", vm);
            }

            if (project.Id == 0)
            {
                ctx.Projecten.Add(project);
            }
            else
            {
                var proDb = ctx.Projecten.Single(x => x.Id == project.Id);

                proDb.Name = project.Name;
                proDb.CategorieId = project.CategorieId;
                proDb.DatumToegevoegd = project.DatumToegevoegd;
            }
            ctx.SaveChanges();

            return RedirectToAction("Index", "Projecten");
        }

        public ActionResult Details(int Id)
        {
            var project = ctx.Projecten.Include(x => x.Categorie).SingleOrDefault(x => x.Id == Id);

            if (project == null)
            {
                return HttpNotFound();
            }

            return View(project);
        }

      
        public ActionResult Edit(int id)
        {
            var project = ctx.Projecten.SingleOrDefault(x => x.Id == id);

            if (project == null)
            {
                return HttpNotFound();
            }

            var categories = ctx.Categories.ToList();
            var vm = new ProjectFormViewModel
            {
                Categories = categories
            };
            return View("ProjectenForm", vm);
        }

        public ViewResult New()
        {
            var categories = ctx.Categories.ToList();

            var vm = new ProjectFormViewModel
            {
                Categories = categories
            };
            return View("ProjectenForm", vm);
        }

       
    }
}