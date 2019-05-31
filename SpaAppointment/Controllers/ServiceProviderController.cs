using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaAppointment.Models;
using SpaAppointment.Services;
using SpaAppointment.ViewModels;

namespace SpaAppointment.Controllers
{
    public class ServiceProviderController : Controller
    {
        private readonly IServiceProviderRepository repo;
        private readonly ICustomerRepository custRepo;
        private readonly IAppointmentRepository appRepo;

        public ServiceProviderController(IServiceProviderRepository _repo, 
            ICustomerRepository _custRepo, IAppointmentRepository _appRepo)
        {
            repo = _repo;
            custRepo = _custRepo;
            appRepo = _appRepo;
        }

        // GET: ServiceProvider
        public ActionResult Index()
        {
            return View(repo.ServiceProviders);
        }

        // GET: ServiceProvider/Details/5
        public ActionResult Details(int id)
        {
            //Trying to be able to list appointments for one provider for one day
            ServProAppVM servProAppVM = new ServProAppVM();
            servProAppVM.appointments = repo.GetAppointmentsByProvider(id);
            //call method to get appointments for this service provider

            servProAppVM.appointment = new Appointment();
            //allows us to egt property names of class

            servProAppVM.serviceProvider = repo.GetProvider(id);
            //brings in current provider...

            servProAppVM.customer = custRepo.GetCustomer(id);
            //trying to bring in customer as well but...

            return View(servProAppVM);
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