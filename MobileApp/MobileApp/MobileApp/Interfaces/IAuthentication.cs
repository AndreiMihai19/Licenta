using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Interfaces
{
    public interface IAuthentication
    {
        Task<AuthenticationStatus> Authenticate();
    }
}
