﻿namespace PrestaLabDICIS.Web.Controllers
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Data;
    using Data.Entities;
    using Helpers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using PrestaLabDICIS.Web.Models;


    
    public class ArticulosController : Controller
    {
        private readonly IArticuloRepository productRepository;

        private readonly IUserHelper userHelper;

        public ArticulosController(IArticuloRepository productRepository, IUserHelper userHelper)
        {
            this.productRepository = productRepository;
            this.userHelper = userHelper;
        }

        // GET: Products
        [Authorize]
        public IActionResult Index()
        {
            return View(this.productRepository.GetAllWithUsers());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            var product = await this.productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            return View(product);
        }


        [Authorize(Roles = "Admin")]
        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticuloViewModel view)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (view.ImageFile != null && view.ImageFile.Length > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var file = $"{guid}.jpg";

                    path = Path.Combine(
                        Directory.GetCurrentDirectory(), 
                        "wwwroot\\images\\Articulos", 
                        file);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await view.ImageFile.CopyToAsync(stream);
                    }

                    path = $"~/images/Articulos/{file}";
                }

                var product = this.ToProduct(view, path);
                // TODO: Pending to change to: this.User.Identity.Name
                product.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                await this.productRepository.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }

            return View(view);
        }

        private Articulo ToProduct(ArticuloViewModel view, string path)
        {
            return new Articulo
            {
                Id = view.Id,
                ImageUrl = path,
                Nombre = view.Nombre,
                TipoArticulo = view.TipoArticulo,
                InfoArticulo = view.InfoArticulo,
                Status = view.Status,
                Stock = view.Stock,
                User = view.User
            };

        }

        [Authorize(Roles = "Admin")]
        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await this.productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            var view = this.ToProductViewModel(product);
            return View(view);
        }

        private object ToProductViewModel(Articulo product)
        {
            return new ArticuloViewModel
            {
                Id = product.Id,
                ImageUrl = product.ImageUrl,
                Nombre = product.Nombre,
                TipoArticulo = product.TipoArticulo,
                InfoArticulo = product.InfoArticulo,
                Status = product.Status,
                Stock = product.Stock,
                User = product.User
            };
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ArticuloViewModel view)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = view.ImageUrl;

                    if (view.ImageFile != null && view.ImageFile.Length > 0)
                    {
                        var guid = Guid.NewGuid().ToString();
                        var file = $"{guid}.jpg";

                        path = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot\\images\\Articulos",
                            file);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await view.ImageFile.CopyToAsync(stream);
                        }

                        path = $"~/images/Articulos/{file}";
                    }

                    var product = this.ToProduct(view, path);
                    // TODO: Pending to change to: this.User.Identity.Name
                    product.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                    await this.productRepository.UpdateAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.productRepository.ExistAsync(view.Id))
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

            return View(view);
        }

        [Authorize(Roles = "Admin")]
        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            var product = await this.productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return new NotFoundViewResult("ProductNotFound");
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await this.productRepository.GetByIdAsync(id);
            await this.productRepository.DeleteAsync(product);
            return RedirectToAction(nameof(Index));
        }



        public IActionResult ProductNotFound()
        {
            return this.View();
        }

    }

}
