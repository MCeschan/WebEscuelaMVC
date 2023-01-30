using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebEscuelaMVC.Data;
using WebEscuelaMVC.Models;

namespace WebEscuelaMVC.Controllers
{
    public class AulaController : Controller
    {
        private readonly EscuelaDBContext context;

        public AulaController(EscuelaDBContext context)
        {
            this.context = context;
        }

        //GET /aula
        //GET /aula/index
        [HttpGet]
        public IActionResult Index()
        {
            //lista de aulas
            var aulas = context.Aulas.ToList();

            //enviar las aulas a la vista
            return View(aulas);
        }

        //GET: Aula/Create
        [HttpGet]
        public ActionResult Create()
        {
            Aula aula = new Aula();

            return View("Create", aula);//devolver al cliente html(vista)
        }

        //POST: Aula/Create
        [HttpPost]
        public ActionResult Create(Aula aula)
        {
            if (ModelState.IsValid)
            {
                context.Aulas.Add(aula);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aula);
        }

        // Aula/delete/1
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var aula = TraerUna(id);
            if (aula == null)
            {
                return NotFound();
            }
            else
            {
                return View("Delete", aula);
            }
        }

        //metodo privado
        private Aula TraerUna(int id)
        {
            return context.Aulas.Find(id);
        }

        // Aula/delete/1
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var aula = TraerUna(id);
            if (aula == null)
            {
                return NotFound();
            }
            else
            {
                context.Aulas.Remove(aula);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        //GET: Aula/Details/4
        [HttpGet]
        public ActionResult Details(int id)
        {
            var aula = TraerUna(id);
            if (aula == null)
            {
                return NotFound();
            }
            else
            {
                return View("Details", aula);
            }
        }



        //GET: aula/Edit/2
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var aula = TraerUna(id);
            if (aula == null)
            {
                return NotFound();
            }
            else
            {
                return View("Edit", aula);
            }
        }

        //POST: aula/Edit/2
        [ActionName("Edit")]
        [HttpPost]
        public ActionResult EditConfirmacion(int id, Aula aula)
        {
            if (id != aula.Id)
            {
                return NotFound();
            }
            context.Entry(aula).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

