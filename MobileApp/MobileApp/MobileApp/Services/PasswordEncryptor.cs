using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using MobileApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MobileApp.Services
{
    public class PasswordEncryptor : IPasswordEncryptor
    {
        public HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
        public int keySize = 25;
        public int iterations = 350000;
        public static string _salt = "4A-2B-97-08-4C-85-D5-69-71-19-58-59-71-CF-0A-D1-4F-C7-CA-69-A2-75-D8-9D-CD-73-53-57-C8-25";
        public byte[] salt = _salt.Split('-')
                   .Select(t => byte.Parse(t, NumberStyles.AllowHexSpecifier))
                   .ToArray();

        public string EncryptPassword(string password)
        {
            string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                                                password: password,
                                                salt: salt,
                                                prf: KeyDerivationPrf.HMACSHA512,
                                                iterationCount: 5000,
                                                numBytesRequested: 10));

            return hash;
        }
    }
}
