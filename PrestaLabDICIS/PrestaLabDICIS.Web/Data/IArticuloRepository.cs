namespace PrestaLabDICIS.Web.Data
{
    using Entities;
    using System.Linq;

    public interface IArticuloRepository : IGenericRepository<Articulo>
    {
        IQueryable GetAllWithUsers();
    }
}
