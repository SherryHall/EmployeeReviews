using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EmployeeReviews.Services;

namespace EmployeeReviews
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public Guid SelectedDept { get; set; } = Guid.Empty;
		public Guid SelectedEmployee { get; set; } = Guid.Empty;
		public Company myCompany { get; set; } = new Company();

		public MainWindow()
		{
			InitializeComponent();
			this.DepartmentList.ItemsSource = myCompany.Departments;
			//this.EmployeeList.ItemsSource = myCompany.Departments[0].DeptEmployees;
		}

		private void AddDept_Click (object sender, RoutedEventArgs e)
		{
			if (!string.IsNullOrEmpty (this.DeptNameBox.Text))
			{
				// Add a Department
				var name = this.DeptNameBox.Text;

				// Do the logic in our service
				var newDept = myCompany.AddDept(name);

				// IF NEEDED: update the UI
				//SelectedDept = newDept.DeptId;
				this.DeptNameBox.Text = "";
				this.DepartmentList.Items.Refresh();
			}

		}
		private void DeptSelected(object sender, RoutedEventArgs e)
		{
			var btn = sender as Button;
			if (btn != null)
			{
				var department = btn.DataContext as Department;
				this.currDept.Content = ($"Employees in {department.DeptName}");
				SelectedDept = department.DeptId;
				// Set the source of the Employee Listview to the Employee list of this department
				var currIndex = myCompany.Departments.FindIndex(f => f.DeptId == SelectedDept);
				this.EmployeeList.ItemsSource = myCompany.Departments[currIndex].DeptEmployees;
				this.EmployeeList.Items.Refresh();

			}
		}

		private void EmpSelected(object sender, RoutedEventArgs e)
		{
			var btn = sender as Button;
			if (btn != null)
			{
				var employee = btn.DataContext as Employee;
				this.EmpName.Text = employee.EmpName;
				this.EmpEmail.Text = employee.EmpEmail;
				this.EmpSalary.Text = employee.EmpSalary.ToString();
				this.ReviewNotes.Text = employee.EmpReview.ReviewNotes;
				//this.SatisfacoryAnswer.Text = employee.EmpReview.Satisfactory;
				SelectedEmployee = employee.EmpId;
			}
		}

		private void AddEmp_Click(object sender, RoutedEventArgs e)
		{
			if (SelectedEmployee == Guid.Empty)
			{
				// Add an employee to the department
				var name = this.EmpName.Text;
				var email = this.EmpEmail.Text;
				var phone = this.EmpPhone.Text;
				var salary = double.Parse(this.EmpSalary.Text);

				var newEmployee = myCompany.AddEmployee(SelectedDept, name, email, phone, salary);

				SelectedEmployee = newEmployee.EmpId;
				this.EmployeeList.Items.Refresh();
			}

		}

	}
}
