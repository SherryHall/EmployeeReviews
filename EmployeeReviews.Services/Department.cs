using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReviews.Services
{
    public class Department
    {
		public string DeptName;
		public List<Employee> DeptEmployees { get; set; } = new List<Employee>();
	}


}
