using AdministratorApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorApplication.Interfaces
{
    public interface IEmployeeslListing
    {
        void AddEmployees(List<EmployeeModel> employees);

        void RemoveEmployee(EmployeeModel employee);

       // Employee? GetEmployee(int id);

    }
}
