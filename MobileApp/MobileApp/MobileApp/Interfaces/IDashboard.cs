using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.Interfaces
{
    public interface IDashboard
    {
        Task<EmployeeModel> GetEmployeeInfo();

        string GetTime(string time1, string time2);

        string GetTotalHours(string time1, string time2);

        Task<string> GetHoursByMonth(int id, int month, int year);
        
        Task<string> GetHoursByWeek(int id, int month, int year, string week);

        Task<string> GetHoursByYear(int id, int year);
    }
}
