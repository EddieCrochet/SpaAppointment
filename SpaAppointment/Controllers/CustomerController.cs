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
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repo;
        public CustomerController(ICustomerRepository repo)
        {
            _repo = repo;
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View(_repo.Customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View(_repo.GetCustomer(id));
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name")]Customer customer)
        {
            try
            {
                _repo.Add(customer);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return ErrorView(ex);
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repo.GetCustomer(id) );
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customers)
        {
            try
            {
                // TODO: Add update logic here
                _repo.Update(id, customers);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repo.GetCustomer(id));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer collection)
        {
            try
            {
                // TODO: Add delete logic here
                _repo.DeleteCustomer(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private ActionResult ErrorView(Exception ex)
        {
            ModelState.AddModelError(string.Empty, "Unknown Error");
            return View();
        }
    }
}