
using Microsoft.EntityFrameworkCore;
using Talabat.Core.Entities;
using Talabat.Core.Repositoiries;
using Talabat.Helpers;
using Talabat.Repository;
using Talabat.Repository.Data;

namespace Talabat
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			#region Configure Services
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<StoreContext>(options => 
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			
			});
			//builder.Services.AddScoped<IGenaricRepository<Product>, GenaricRepository<Product>>();
			builder.Services.AddScoped(typeof(IGenaricRepository<>), typeof(GenaricRepository<>));
			//builder.Services.AddAutoMapper(M=>M.AddProfile(new MappingProfiles()));
			builder.Services.AddAutoMapper(typeof(MappingProfiles));
			#endregion
			var app = builder.Build();

			#region Update-Database
			//StoreContext DbContext = new StoreContext();//invalid
			//await DbContext.Database.MigrateAsync();
			using var scope=app.Services.CreateScope();//Group of sevices lifeTime Scooped (Like dbcontext)
			var Services=scope.ServiceProvider;//services itself
			var LoogrFactory = Services.GetRequiredService<ILoggerFactory>();
			try
			{
                var dbContext = Services.GetRequiredService<StoreContext>();//Ask CLR to create obj from DbContex Explicitly
				await dbContext.Database.MigrateAsync();
				await StoreContextSeed.SeedAsync(dbContext);
			}
			catch (Exception ex) 
			{
				var Logger = LoogrFactory.CreateLogger<Program>();
				Logger.LogError(ex, " an error occured while applying migration");
			
			}

			#endregion

			

			#region MyRegionConfigure the HTTP request pipeline.

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseStaticFiles();

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			#endregion
			app.Run();
		}
	}
}
