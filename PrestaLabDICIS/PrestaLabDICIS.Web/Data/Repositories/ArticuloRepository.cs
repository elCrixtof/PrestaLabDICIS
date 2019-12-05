namespace PrestaLabDICIS.Web.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Entities;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class ArticuloRepository : GenericRepository<Articulo>, IArticuloRepository
    {
        private readonly DataContext context;

        public ArticuloRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return this.context.Articulo.Include(p => p.User).OrderBy(p => p.Nombre);
        }


        public IEnumerable<SelectListItem> GetComboProducts()
        {
            var list = this.context.Articulo.Select(p => new SelectListItem
            {
                Text = p.Nombre,
                Value = p.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a Articulo...)"
                
            });

            return list;
        }

    }

}
