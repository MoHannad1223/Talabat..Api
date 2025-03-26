using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
	public interface ISpecifications<T> where T : BaseEntity
	{
		//sign for property for where condition[where(p=>p.id==Id)]
		public Expression<Func<T, bool>> Criteria { get; set; } 
		//sign for property for  List of includes 
		public List<Expression<Func<T,object>>> Includes { get; set; }
	}
}
