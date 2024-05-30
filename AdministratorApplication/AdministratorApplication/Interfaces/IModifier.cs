using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministratorApplication.Services;

namespace AdministratorApplication.Interfaces
{
    interface IModifier
    {
        ModifierStatus ModifyEmployeeInfo(int? id, string currentJobPosition, string email, string password, string phoneNumber, string newJobPosition, int hours);
    }
}
