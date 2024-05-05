using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamanApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Components;

namespace ExamanApp.Controllers
{
    [Authorize]
    public class ProjetsController : Controller
    {
        private readonly Context context;

        public ProjetsController(Context context)
        {
            this.context = context;
        }

        // GET: Projets
        public ActionResult Index()
        {
            List<Projet> Projets = context.Projet.ToList();
            foreach (var item in Projets)
            {

                item.Client = context.Client.Where(e => e.ClientId == item.ClientId).FirstOrDefault();
            }
            return View(Projets);
        }

        // GET: Projets/Details/5
        public ActionResult Details(int id)
        {
            var Projets = context.Projet.Find(id);
            ViewBag.ListClient = context.Client.ToList();
            return View(Projets);
        }

        // GET: Projets/Create
        public ActionResult Create()
        {
            ViewBag.ListClient = context.Client.ToList();
            return View();
        }

        // POST: Projets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Projet projet )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    /*if (context.Projet.Where(x => x.NomProjet == projet.NomProjet).Count() > 0)
                    {
                        ViewBag.ListClient = context.Projet.ToList();

                        ViewBag.error = "Projet already exists";
                        return View(projet);
                    }*/
                   
                    context.Projet.Add(projet);
                    context.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Projets/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ListClient = context.Client.ToList();

            Projet projet = context.Projet.Find(id);
            return View(projet);
        }

        // POST: Projets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Projet projet)
        {
            try
            {

                Projet existingLivreur = context.Projet.Find(id);
                existingLivreur.NomProjet = projet.NomProjet;
                existingLivreur.addresseProjet = projet.addresseProjet;
                existingLivreur.Description = projet.Description;
                existingLivreur.StatutProjet = projet.StatutProjet;
                existingLivreur.ClientId = existingLivreur.ClientId;



                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: Projets/Delete/5
        public ActionResult Delete(int id)
        {
            var projet = context.Projet.Find(id);
            ViewBag.ListClient = context.Client.ToList();
            return View(projet);
        }

        // POST: Projets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Projet projet)
        {
            try
            {
                context.Projet.Remove(projet);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
    }
}
