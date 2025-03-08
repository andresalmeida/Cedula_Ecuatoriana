using Testing.Models;
using Testing.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Testing.Controllers
{
    public class ClienteSqlController : Controller
    {

        ClienteSQLDataAccessLayer objClienteDAL = new ClienteSQLDataAccessLayer();

        // GET: ClienteSqlController
        public ActionResult Index()
        {
            List<ClienteSQL> listCliente = new List<ClienteSQL>();
            listCliente = objClienteDAL.GetAllClientes().ToList();
            return View(listCliente);
        }

        // GET: ClienteSqlController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteSqlController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteSqlController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] ClienteSQL cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objClienteDAL.AddCliente(cliente);
                    return RedirectToAction(nameof(Index));
                }
                return View(cliente);
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteSqlController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClienteSqlController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteSqlController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteSqlController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //PUT: ClienteSqlController/Update
        [HttpPut]
        public IActionResult Update([Bind] ClienteSQL cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objClienteDAL.UpdateCliente(cliente);
                    return RedirectToAction(nameof(Index));
                }
                return View(cliente);
            }
            catch
            {
                return View();
            }
        }
    }
}
