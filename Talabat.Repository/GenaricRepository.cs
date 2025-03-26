using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Repositoiries;
using Talabat.Core.Specifications;
using Talabat.Repository.Data;

namespace Talabat.Repository
{
	public class GenaricRepository<T> : IGenaricRepository<T> where T : BaseEntity
	{
		private readonly StoreContext _dbcontext;

		public GenaricRepository(StoreContext dbcontext)
        {
			_dbcontext = dbcontext;
		}


		#region WithoutSpec
		public async Task<IEnumerable<T>> GetAllAsync()
		{
			if (typeof(T) == typeof(Product))
				return (IEnumerable<T>)await _dbcontext.Products.Include(P => P.ProductBrand).Include(P => P.ProductType).ToListAsync();
			else
				return await _dbcontext.Set<T>().ToListAsync();


		}


		public async Task<T> GetByIdAsync(int id)
		{
			return await _dbcontext.Set<T>().FindAsync(id);
		} 
		#endregion

		public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> Spec)
		{
			return await ApllySpecification(Spec).ToListAsync();
		}
		public async Task<T> GetByIdWithSpecAsync(ISpecifications<T> Spec)
		{
			return await ApllySpecification(Spec).FirstOrDefaultAsync();
		}

		private IQueryable<T> ApllySpecification(ISpecifications<T> Spec)
		{
			return SpecificationEvaluator<T>.GetQuery(_dbcontext.Set<T>(), Spec);

     }
	}
}
