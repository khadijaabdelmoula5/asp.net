using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamanApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace ExamanApp.Controllers
{
    [Authorize]
    public class FacturesController : Controller
    {
        private readonly Context context;

        public FacturesController(Context context)
        {
            this.context = context;
        }

        // GET: Factures
        public ActionResult Index()
        {
            List<Facture> Factures = context.Facture.ToList();
            foreach (var item in Factures)
            {

                item.Projet = context.Projet.Where(e => e.ProjetId == item.ProjetId).FirstOrDefault();
            }
            return View(Factures);
        }
        // GET: Factures/Details/5
        public ActionResult Details(int id)
        {
            var Factures = context.Facture.Find(id);
            ViewBag.ListProjet = context.Projet.ToList();

            return View(Factures);
        }

        // GET: Factures/Create
        public ActionResult Create()
        {
            ViewBag.ListProjet = context.Projet.ToList();
            return View();
        }

        // POST: Factures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Facture facture)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   /* if (context.Facture.Where(x => x.ProjetId  == facture.ProjetId).Count() > 0)
                    {
                        ViewBag.ListProjet = context.Facture.ToList();

                        ViewBag.error = "Facture already exists";
                        return View(facture);
                    }*/
                    context.Facture.Add(facture);
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


        // GET: Factures/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ListProjet = context.Projet.ToList();

            Facture facture = context.Facture.Find(id);
            return View(facture);
        }

        // POST: Factures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Facture facture)
        {
            try
            {

                Facture existingLivreur = context.Facture.Find(id);
                existingLivreur.FactureId = facture.FactureId;
                existingLivreur.Montant = facture.Montant;
                existingLivreur.ProjetId = existingLivreur.ProjetId;

                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Factures/Delete/5
        public ActionResult Delete(int id)
        {
            var facture = context.Facture.Find(id);
            ViewBag.ListProjet = context.Projet.ToList();


            return View(facture);
        }

        // POST: Factures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Facture facture)
        {
            try
            {
                context.Facture.Remove(facture);
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
