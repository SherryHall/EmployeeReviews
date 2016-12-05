using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReviews.Services
{
	public class Department
	{
		public Guid DeptId { get; set; } = Guid.NewGuid();
		public string DeptName;
		public List<Employee> DeptEmployees { get; set; } = new List<Employee>();


	}


}
