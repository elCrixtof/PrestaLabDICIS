namespace PrestaLabDICIS.Web.Data
{ 
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Entities;

    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Articulo> Articulo { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        } 
    }

}
