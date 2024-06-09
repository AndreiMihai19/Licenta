using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Interfaces
{
    public interface IResetPassword
    {
        Task<SendMailStatus> CheckEmail();

        Task<ResetPasswordStatus> ResetPassword();

        int GenerateResetCode();
    }
}
