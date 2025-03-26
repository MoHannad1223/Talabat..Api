using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Repository
{
	public static class SpecificationEvaluator<T> where T : BaseEntity
	{
		//Func to build Query
		public static IQueryable<T> GetQuery(IQueryable<T> inputQuery,ISpecifications<T> Spec)
        {
			var Query = inputQuery;
			if (Spec.Criteria is not null)
			{
				Query = Query.Where(Spec.Criteria);			
			
			}
			Query = Spec.Includes.Aggregate(Query,(CurrentQuery,includeExepression)=>CurrentQuery.Include(includeExepression));
			return Query;
		
		}	
	}
}
