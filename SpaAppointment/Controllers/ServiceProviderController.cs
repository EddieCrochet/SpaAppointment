using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaAppointment.Models;
using SpaAppointment.Services;

namespace SpaAppointment.Controllers
{
    public class ServiceProviderController : Controller
    {
        private readonly IServiceProviderRepository repo;

        public ServiceProviderController(IServiceProviderRepository _repo)
        {
            repo = _repo;
        }

        // GET: ServiceProvider
        public ActionResult Index()
        {
            return View(repo.ServiceProviders);
        }

        // GET: ServiceProvider/Details/5
        public ActionResult Details(int id)
        {
            repo.GetAppointmentsForProviderByDay(id);
            return View(repo.GetProvider(id));
        }

        // GET: ServiceProvider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceProvider/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name")]ServiceProvider provider)
        {
            try
            {
                // TODO: Add insert logic here
                repo.Add(provider);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        // GET: ServiceProvider/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repo.GetProvider(id) );
        }

        // POST: ServiceProvider/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ServiceProvider provider)
        {
            try
            {
                // TODO: Add update logic here
                repo.Update(id, provider);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceProvider/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repo.GetProvider(id));
        }

        // POST: ServiceProvider/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                repo.DeleteProvider(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private ActionResult ErrorView(Exception ex)
        {
            ModelState.AddModelError(string.Empty, "To be honest... we're not sure what happened here..." +
                "just like... try again or something? Idk. Press back? Google it?");
            return View();
        }
    }
}