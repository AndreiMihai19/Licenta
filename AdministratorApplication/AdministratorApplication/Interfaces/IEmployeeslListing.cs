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
        void AddEmployees(List<Employee> employees);

        void RemoveEmployee(Employee employee);

       // Employee? GetEmployee(int id);

    }
}
