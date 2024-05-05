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

    public class ClientsController : Controller
    {
        private readonly Context context;

        public ClientsController(Context context)
        {
            this.context = context;
        }
        // GET: Client
        public ActionResult Index()
        {
            List<Client> Clients = context.Client.ToList();
            foreach (var item in Clients)
            {

                item.Architecte = context.Architecte.Where(e => e.ArchitecteId == item.ArchitecteId).FirstOrDefault();
            }
            return View(Clients);
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            var Clients = context.Client.Find(id);
            ViewBag.ListArchitecte = context.Architecte.ToList();

            return View(Clients);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            ViewBag.ListArchitecte = context.Architecte.ToList();
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    /*if (context.Client.Where(x => x.NomClient == client.NomClient).Count() > 0)
                    {
                        ViewBag.ListArchitecte = context.Client.ToList();
                        ViewBag.error = "Client already exists";
                        return View(client);
                    }*/

                    context.Client.Add(client);
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

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ListArchitecte = context.Architecte.ToList();

            Client client = context.Client.Find(id);
            return View(client);
        }

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Client client)
        {
            try
            {

                Client existingLivreur = context.Client.Find(id);
                existingLivreur.NomClient = client.NomClient;
                existingLivreur.prenom = client.prenom;
                existingLivreur.addresse = client.addresse;
                existingLivreur.telephone = client.telephone;
                existingLivreur.emailClient = client.emailClient;
                existingLivreur.ArchitecteId = existingLivreur.ArchitecteId;



                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            var client = context.Client.Find(id);
            ViewBag.ListArchitecte = context.Architecte.ToList();

            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Client client)
        {
            try
            {
                context.Client.Remove(client);
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
