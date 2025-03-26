using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
	public static class StoreContextSeed
	{
		//seeding 
		public static async Task SeedAsync(StoreContext dbContext)
		{
			if (!dbContext.ProductBrands.Any())
			{
				//seeding brands
				var BrandsData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/brands.json");
				var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);
				if (Brands?.Count > 0)
				{
					foreach (var Brand in Brands)
					{
						await dbContext.Set<ProductBrand>().AddAsync(Brand);
					}
					await dbContext.SaveChangesAsync();
				}
			}
			if (!dbContext.ProductTypes.Any())
			{
				//seeding types
				var TypesData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/types.json");
				var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
				if (Types?.Count > 0)
				{
					foreach (var Type in Types)
					{
						await dbContext.Set<ProductType>().AddAsync(Type);
					}
					await dbContext.SaveChangesAsync();


				}
			}
			if (!dbContext.Products.Any())
			{
				//seeding Product
				var ProductsData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/products.json");
				var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
				if (Products?.Count > 0)
				{
					foreach (var product in Products)
					{
						await dbContext.Set<Product>().AddAsync(product);
					}
					await dbContext.SaveChangesAsync();

				}
			}
		}

	}

}
