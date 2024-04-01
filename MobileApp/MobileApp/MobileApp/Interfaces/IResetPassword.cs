using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Interfaces
{
    public interface IResetPassword
    {
        Task<SendEmailStatus> SendPassword();

        Task<ResetPasswordStatus> ResetPassword();

        int GenerateResetCode();
    }
}
