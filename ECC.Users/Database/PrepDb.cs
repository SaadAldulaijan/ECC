using ECC.Models;
using Microsoft.EntityFrameworkCore;

namespace ECC.Users.Database
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<DataContext>(), isProd);
            }
        }

        private static void SeedData(DataContext context, bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            }

            if (!context.Groups.Any())
            {
                Console.WriteLine("--> Seeding Groups ...");
                context.Groups.AddRange(
                    new Group { Name = "admin", Deleted = false },
                    new Group { Name = "user", Deleted = false }
                    );

                context.SaveChanges();

            }
            else
            {
                Console.WriteLine("--> We already have data");
            }

            if (!context.Users.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Users.AddRange(
                    new User { Name = "Saad", Email = "saad@test.com", GroupId = 1, Position = "Developer"},
                    new User { Name = "Ahmed", Email = "ahmed@test.com", GroupId = 2, Position = "Software Engineer"}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}
