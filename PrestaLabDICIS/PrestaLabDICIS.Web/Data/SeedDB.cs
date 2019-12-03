namespace PrestaLabDICIS.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Articulo.Any())
            {
                this.AddProduct("Cautin");
                this.AddProduct("Multimetro");
                this.AddProduct("Pinzas");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            this.context.Articulo.Add(new Articulo
            {
                Nombre = name,
                Status = true,
                Stock = this.random.Next(100)
            });
        }
    }

}
