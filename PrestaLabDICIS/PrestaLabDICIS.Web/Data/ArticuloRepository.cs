namespace PrestaLabDICIS.Web.Data
{
    using Entities;

    public class ArticuloRepository : GenericRepository<Articulo>, IArticuloRepository
    {
        public ArticuloRepository(DataContext context) : base(context)
        {
        }
    }

}
