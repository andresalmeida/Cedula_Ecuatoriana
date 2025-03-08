//using Microsoft.AspNetCore.Mvc;
//using Testing.Models;
//using Testing.Data;
//using System.Collections.Generic;

//namespace Testing.Controllers
//{
//    public class ClientePostgreSQLController : Controller
//    {
//        private readonly ClientePostgreSQLDataAccessLayer _clienteDAL = new ClientePostgreSQLDataAccessLayer();

//        // GET: ClientePostgreSQL
//        public ActionResult Index()
//        {
//            List<ClientePostgreSQL> listCliente = _clienteDAL.GetAllClientes().ToList();
//            return View(listCliente);
//        }

//        // GET: ClientePostgreSQL/Details/5
//        public ActionResult Details(int id)
//        {
//            ClientePostgreSQL cliente = _clienteDAL.GetAllClientes().FirstOrDefault(c => c.Codigo == id);
//            if (cliente == null)
//            {
//                return NotFound();
//            }
//            return View(cliente);
//        }

//        // GET: ClientePostgreSQL/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: ClientePostgreSQL/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind("Cedula,Apellidos,Nombres,FechaNacimiento,Mail,Telefono,Direccion,Estado")] ClientePostgreSQL cliente)
//        {
//            if (ModelState.IsValid)
//            {
//                cliente.FechaNacimiento = cliente.FechaNacimiento.Date;
//                _clienteDAL.AddCliente(cliente);
//                return RedirectToAction(nameof(Index));
//            }
//            return View(cliente);
//        }

//        // GET: ClientePostgreSQL/Edit/5
//        public ActionResult Edit(int id)
//        {
//            ClientePostgreSQL cliente = _clienteDAL.GetAllClientes().FirstOrDefault(c => c.Codigo == id);
//            if (cliente == null)
//            {
//                return NotFound();
//            }
//            return View(cliente);
//        }

//        // POST: ClientePostgreSQL/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, [Bind("Codigo,Cedula,Apellidos,Nombres,FechaNacimiento,Mail,Telefono,Direccion,Estado")] ClientePostgreSQL cliente)
//        {
//            if (id != cliente.Codigo)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                _clienteDAL.UpdateCliente(cliente);
//                return RedirectToAction(nameof(Index));
//            }
//            return View(cliente);
//        }

//        // GET: ClientePostgreSQL/Delete/5
//        public ActionResult Delete(int id)
//        {
//            ClientePostgreSQL cliente = _clienteDAL.GetAllClientes().FirstOrDefault(c => c.Codigo == id);
//            if (cliente == null)
//            {
//                return NotFound();
//            }
//            return View(cliente);
//        }

//        // POST: ClientePostgreSQL/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            _clienteDAL.DeleteCliente(id);
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}

// CÓDIGO QUE SI FUNCIONA EN 4K NO MOVIBLE

//using System;
//using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc;
//using Testing.Models;
//using Testing.Data;

//namespace Testing.Controllers
//{
//    public class ClientePostgreSQLController : Controller
//    {
//        private ClientePostgreSQLDataAccessLayer dal = new ClientePostgreSQLDataAccessLayer();

//        // GET: ClientePostgreSQL
//        public IActionResult Index()
//        {
//            List<ClientePostgreSQL> clientes = dal.GetAllClientes().ToList();
//            return View(clientes);
//        }

//        // GET: ClientePostgreSQL/Details/5
//        public IActionResult Details(int id)
//        {
//            ClientePostgreSQL cliente = dal.GetClienteByCodigo(id);
//            if (cliente == null)
//            {
//                return NotFound();
//            }
//            return View(cliente);
//        }

//        // GET: ClientePostgreSQL/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: ClientePostgreSQL/Create
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Create(ClientePostgreSQL cliente)
//        {
//            if (ModelState.IsValid)
//            {
//                dal.AddCliente(cliente);
//                return RedirectToAction(nameof(Index));
//            }
//            return View(cliente);
//        }

//        // GET: ClientePostgreSQL/Edit/5
//        public IActionResult Edit(int id)
//        {
//            ClientePostgreSQL cliente = dal.GetClienteByCodigo(id);
//            if (cliente == null)
//            {
//                return NotFound();
//            }
//            return View(cliente);
//        }

//        // POST: ClientePostgreSQL/Edit/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Edit(int id, ClientePostgreSQL cliente)
//        {
//            if (id != cliente.Codigo)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                dal.UpdateCliente(cliente);
//                return RedirectToAction(nameof(Index));
//            }
//            return View(cliente);
//        }

//        // GET: ClientePostgreSQL/Delete/5
//        public IActionResult Delete(int id)
//        {
//            ClientePostgreSQL cliente = dal.GetClienteByCodigo(id);
//            if (cliente == null)
//            {
//                return NotFound();
//            }
//            return View(cliente);
//        }

//        // POST: ClientePostgreSQL/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public IActionResult DeleteConfirmed(int id)
//        {
//            dal.DeleteCliente(id);
//            return RedirectToAction(nameof(Index));
//        }
//    }
//}

// CODIGO QUE CREAMOS PARA LA CLASE DIO MIO POR FAVOR QUE FUNCIONE

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Testing.Models;
using Testing.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Testing.Validations;
using Microsoft.EntityFrameworkCore;

namespace Testing.Controllers
{
    public class ClientePostgreSQLController : Controller
    {
        private ClientePostgreSQLDataAccessLayer dal = new ClientePostgreSQLDataAccessLayer();


        // GET: ClientePostgreSQL
        public IActionResult Index()
        {
            List<ClientePostgreSQL> clientes = dal.GetAllClientes().ToList();
            return View(clientes);
        }

        // GET: ClientePostgreSQL/Details/5
        public IActionResult Details(int id)
        {
            ClientePostgreSQL cliente = dal.GetClienteByCodigo(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // GET: ClientePostgreSQL/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: ClientePostgreSQL/Create (Generar Cedula)
        [HttpGet]
        public string GenerarCedula(int codigoProvincia)
        {
            return Testing.Validations.CedulaGenerator.GenerarCedulaValida(codigoProvincia);
        }


        // POST: ClientePostgreSQL/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClientePostgreSQL cliente)
        {
            if (ModelState.IsValid)
            {
                dal.AddCliente(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }


        // GET: ClientePostgreSQL/Edit/5
        public IActionResult Edit(int id)
        {
            ClientePostgreSQL cliente = dal.GetClienteByCodigo(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: ClientePostgreSQL/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ClientePostgreSQL cliente)
        {
            if (id != cliente.Codigo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                dal.UpdateCliente(cliente);
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: ClientePostgreSQL/Delete/5
        public IActionResult Delete(int id)
        {
            ClientePostgreSQL cliente = dal.GetClienteByCodigo(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: ClientePostgreSQL/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            dal.DeleteCliente(id);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult Depositar(int id, decimal monto)
        {
            try
            {
                dal.UpdateSaldo(id, monto, true);
                return RedirectToAction(nameof(Details), new { id = id });
            }
            catch (Exception ex)
            {
                // Manejar el error apropiadamente
                return View("Error", ex.Message);
            }
        }

        // Método para mostrar la vista de agregar/quitar saldo
        public IActionResult ModificarSaldo(int id)
        {
            var cliente = dal.GetClienteByCodigo(id); // Método que obtendría al cliente por su ID
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // Método para procesar la modificación del saldo
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModificarSaldo(int id, decimal monto, bool esDeposito)
        {
            var cliente = dal.GetClienteByCodigo(id);
            if (cliente == null)
            {
                return NotFound();
            }

            try
            {
                dal.UpdateSaldo(id, monto, esDeposito); // Llamada a la capa de datos para actualizar el saldo
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(cliente);
            }

            return RedirectToAction("Index", new { id = cliente.Codigo });
        }
    }

}






