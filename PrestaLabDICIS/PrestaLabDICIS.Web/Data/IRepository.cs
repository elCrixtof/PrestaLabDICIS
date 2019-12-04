namespace PrestaLabDICIS.Web.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;

    public interface IRepository
    {
        void AddArticulo(Articulo articulo);

        bool ArticuloExists(int id);

        Articulo GetArticulo(int id);

        IEnumerable<Articulo> GetArticulos();

        void RemoveArticulo(Articulo articulo);

        Task<bool> SaveAllAsync();

        void UpdateArticulo(Articulo articulo);
    }
}