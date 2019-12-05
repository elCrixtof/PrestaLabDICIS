namespace PrestaLabDICIS.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using PrestaLabDICIS.Web.Helpers;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();
            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Encargado");
            await this.userHelper.CheckRoleAsync("Estudiante");


            var user = await this.userHelper.GetUserByEmailAsync("luis@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Luis",
                    LastName = "Soriano",
                    Email = "luis@gmail.com",
                    UserName = "luis@gmail.com",
                    PhoneNumber = "4641702754"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }

            var isInRole = await this.userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isInRole)
            {
                await this.userHelper.AddUserToRoleAsync(user, "Admin");
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
