using Garage.Data;

namespace Garage_2_Group_1.Extensions
{
    public static class AppBuilderExtensions
    {
        public static async Task<IApplicationBuilder> SeedDataAsync(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var db = serviceProvider.GetRequiredService<GarageContext2>();
                var config = serviceProvider.GetRequiredService<IConfiguration>();
                //Comment these unless you want to reseed and delete your database every run.

                db.Database.EnsureDeleted(); 
                db.Database.Migrate();

                try
                {
                    await SeedData.InitAsync(db, config);
                }
                catch (Exception e)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(string.Join(" ", e.Message));
                }
            }

            return app;
        }
    }
}
