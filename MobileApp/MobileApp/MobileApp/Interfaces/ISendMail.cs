using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Interfaces
{
    public interface ISendMail
    {
        Task SendResetCodeMethod(int resetCode, string toEmail);
    }
}
