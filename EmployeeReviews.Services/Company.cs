using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReviews.Services
{
	class Company
	{
		public string CompanyName;
		public List<Department> Departments { get; set; } = new List<Department>();
	}
}
