using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Interfaces
{
    public interface IPasswordEncryptor
    {
        string EncryptPassword(string password);
    }
}
