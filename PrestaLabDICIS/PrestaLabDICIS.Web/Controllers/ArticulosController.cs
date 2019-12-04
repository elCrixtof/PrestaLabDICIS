using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrestaLabDICIS.Web.Data;
using PrestaLabDICIS.Web.Data.Entities;

namespace PrestaLabDICIS.Web.Controllers
{
    public class ArticulosController : Controller
    {
        private readonly IRepository repository;

        public ArticulosController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: Articulos
        public IActionResult Index()
        {
            return View(this.repository.GetArticulos());
        }

        // GET: Articulos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = this.repository.GetArticulo(id.Value);

            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // GET: Articulos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Articulos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                this.repository.AddArticulo(articulo);
                await this.repository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(articulo);
        }

        // GET: Articulos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = this.repository.GetArticulo(id.Value);            
            if (articulo == null)
            {
                return NotFound();
            }
            return View(articulo);
        }

        // POST: Articulos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Articulo articulo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    this.repository.UpdateArticulo(articulo);
                    await this.repository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.repository.ArticuloExists(articulo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(articulo);
        }

        // GET: Articulos/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articulo = this.repository.GetArticulo(id.Value);
            if (articulo == null)
            {
                return NotFound();
            }

            return View(articulo);
        }

        // POST: Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var articulo = this.repository.GetArticulo(id);
            this.repository.RemoveArticulo(articulo);
            this.repository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
