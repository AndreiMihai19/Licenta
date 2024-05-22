using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }

        public string LastName { get; set; }    

        public string FirstName { get; set; } 

        public string Email { get; set; }

        public string Job { get; set; } 

        public int DailyHours { get; set; }  

        public string ClockIn {  get; set; }  

        public string StartBreakHour { get; set; } 

        public string EndBreakHour { get; set; }    

        public string ClockOut { get; set; }

        public string TotalWorkedHours {  get; set; }    

    }
}
