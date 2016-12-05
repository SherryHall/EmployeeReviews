using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReviews.Services
{
	public class Employee
	{
		public Guid EmpId { get; set; } = Guid.NewGuid();
		public string EmpName { get; set; }
		public string EmpEmail { get; set; }
		public string EmpPhone { get; set; }
		public double EmpSalary { get; set; }

		public Review EmpReview { get; set; } = new Review();
	}
}
