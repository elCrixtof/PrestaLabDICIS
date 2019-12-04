namespace PrestaLabDICIS.Web.Data
{
    using System.Linq;
    using Entities;
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
    }

}
