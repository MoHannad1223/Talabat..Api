using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Core.Repositoiries
{
	public interface IGenaricRepository<T> where T : BaseEntity
	{
		#region WithoutSpecification
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		#endregion
		#region WithSpecification
		Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> Spec);
		Task<T> GetByIdWithSpecAsync(ISpecifications<T> Spec); 
		#endregion
	}
}
