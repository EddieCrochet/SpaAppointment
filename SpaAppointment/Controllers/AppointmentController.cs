using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaAppointment.Data;
using SpaAppointment.Models;
using SpaAppointment.Services;

namespace SpaAppointment.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository _repo;
        private readonly ICustomerRepository _custRepo;
        private readonly IServiceProviderRepository _servRepo;
        
        public AppointmentController(IAppointmentRepository repo,
            ICustomerRepository custRepo, IServiceProviderRepository servRepo)
        {
            _repo = repo;
            _custRepo = custRepo;
            _servRepo = servRepo;
        }

        // GET: Appointment
        public ActionResult Index()
        {
            return View(_repo.Appointments);
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int id)
        {
            return View(_repo.GetAppointment(id));
        }

        // GET: Appointment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment appointment)
        {
            if (_repo.isAppointmentAvailable(appointment))
            {
                if (_custRepo.ThisCustomerExists(appointment.CustomerId))
                {
                    if (_servRepo.ThisProviderExists(appointment.ProviderId))
                    {
                        _repo.Add(appointment);
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("",
                            "There is no Service ProProviderIdvider that exists with the selected ID..."+
                            "I'm begging you, think very carefully and give this just one more shot, Big Guy");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("CustomerId",
                        "There is no customer that exists with that ID... Please try.. maybe... one more time?");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("AppTime",
                    "The selected Service Provider is not available for an appointment at this time. Please try again.");
                return View();
            }
        }
        
        // GET: Appointment/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repo.GetAppointment(id));
        }

        // POST: Appointment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Appointment appointment)
        {
            try
            {
                // TODO: Add update logic here
                _repo.Update(id, appointment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repo.GetAppointment(id));
        }

        // POST: Appointment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _repo.DeleteAppointment(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}