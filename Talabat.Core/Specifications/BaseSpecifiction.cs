using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
	public class BaseSpecifiction<T> : ISpecifications<T> where T : BaseEntity
	{
		public Expression<Func<T, bool>> Criteria { get ; set ; }
		public List<Expression<Func<T, object>>> Includes { get; set; }  = new List<Expression<Func<T, object>>>();

		//Get All
		public BaseSpecifiction()
        {
           // Includes = new List<Expression<Func<T, object>>>();
        }
        //Get By Id
        public BaseSpecifiction(Expression<Func<T, bool>> criteriaExpression)
        {
            Criteria = criteriaExpression;
          //  Includes=new List<Expression<Func<T, object>>>();
        }
    }
}
