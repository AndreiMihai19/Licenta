using AdministratorApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorApplication.Classes
{
    public class EmployeesListing : IEmployeeslListing
    {
        List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        { 
            employees.Add(employee);
        }

        public Employee? GetEmployee(int id)
        { 
            return employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
