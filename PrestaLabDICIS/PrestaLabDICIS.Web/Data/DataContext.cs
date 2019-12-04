namespace PrestaLabDICIS.Web.Data
{ 
    using Microsoft.EntityFrameworkCore;
    using PrestaLabDICIS.Web.Data.Entities;

    public class DataContext : DbContext
    {
        public DbSet<Articulo> Articulo { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        } 
    }

}
