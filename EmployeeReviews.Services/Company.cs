using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeReviews.Services
{
	public class Company
	{
		public string CompanyName;
		public List<Department> Departments { get; set; } = new List<Department>();


		public Department AddDept(string name)
		{
			var department = new Department
			{
				DeptName = name,
			};
			this.Departments.Add (department);
			return department;
		}

		public Employee AddEmployee(Guid SelectedDept, string name, string email, string phone, double salary)
		{
			var employee = new Employee
			{
				EmpName = name,
				EmpEmail = email,
				EmpPhone = phone,
				EmpSalary = salary
			};
			var currIndex = this.Departments.FindIndex(f => f.DeptId == SelectedDept);
			this.Departments[currIndex].DeptEmployees.Add(employee);
			return employee;
		}
	}

}
