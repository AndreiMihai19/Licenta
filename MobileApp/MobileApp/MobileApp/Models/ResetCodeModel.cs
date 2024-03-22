using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class ResetCodeModel
    {
        public static int ResetCode { get; set; }
        public static DateTime ExpirationTime { get; set; }
    }
}
