namespace PrestaLabDICIS.Web.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Articulo> GetArticulos()
        {
            return this.context.Articulo.OrderBy(a => a.Nombre);
        }

        public Articulo GetArticulo(int id)
        {
            return this.context.Articulo.Find(id);
        }

        public void AddArticulo(Articulo articulo)
        {
            this.context.Articulo.Add(articulo);
        }

        public void UpdateArticulo(Articulo articulo)
        {
            this.context.Update(articulo);
        }

        public void RemoveArticulo(Articulo articulo)
        {
            this.context.Articulo.Remove(articulo);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public bool ArticuloExists(int id)
        {
            return this.context.Articulo.Any(a => a.Id == id);
        }


    }
}
