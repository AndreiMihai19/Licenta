using AdministratorApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorApplication.Interfaces
{
    public interface IRegistration
    {
        RegistrationStatus Register(EmployeeModel employee, string password);
    }
}
