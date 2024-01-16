using AdministratorApplication.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorApplication.Interfaces
{
    interface IStatus
    {
        void AddEmployees(List<Employee> employees);

        int GetNumberOfEmployees(List<Employee> employees);
    }
}
