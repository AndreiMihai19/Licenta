using AdministratorApplication.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorApplication.Interfaces
{
    public interface IEmployeeslListing
    {
        void AddEmployee(Employee employee);

        Employee? GetEmployee(int id);

    }
}
