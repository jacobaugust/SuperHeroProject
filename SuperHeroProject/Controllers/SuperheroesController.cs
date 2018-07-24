using SuperHeroProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace SuperHeroProject.Controllers
{
    public class SuperheroesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Superheroes
        public ViewResult Index()
        {
            return View(db.superheroes.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Superhero superhero = db.superheroes.Find(id);
            if (superhero == null)
            {
                return HttpNotFound();
            }
            return View(superhero);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuperHeroName, AlterEgoName, PrimaryAbility, SecondaryAbility, CatchPhrase")]Superhero superhero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.superheroes.Add(superhero);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch 
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            return View(superhero);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var superheroToUpdate = db.superheroes.Find(id);
            if (TryUpdateModel(superheroToUpdate, "", new string[] { "SuperHeroName, AlterEgoName, PrimaryAbility, SecondaryAbility, CatchPhrase" }))
            {
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
        }
            
    }
}