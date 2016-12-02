using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReviews.Services
{
	class Employee
	{
		public Guid EmpId { get; set; } = Guid.NewGuid();
		public string EmpName { get; set; }
		public string EmpEmail { get; set; }
		public double EmpSalary { get; set; }

		public Reviews EmpReview { get; set; } = new Reviews();
	}
}
