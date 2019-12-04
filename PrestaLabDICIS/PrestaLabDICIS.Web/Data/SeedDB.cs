namespace PrestaLabDICIS.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.AspNetCore.Identity;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly UserManager<User> userManager;
        private Random random;

        public SeedDb(DataContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userManager.FindByEmailAsync("cristian@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Christian",
                    LastName = "Acosta",
                    Email = "cristian@gmail.com",
                    UserName = "Pepa117",
                    PhoneNumber = "4641702754"
                };

                var result = await this.userManager.CreateAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!this.context.Articulo.Any())
            {
                this.AddProduct("Cautin", user);
                this.AddProduct("Multimetro", user);
                this.AddProduct("Pinzas", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Articulo.Add(new Articulo
            {
                Nombre = name,
                Status = true,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }
}
