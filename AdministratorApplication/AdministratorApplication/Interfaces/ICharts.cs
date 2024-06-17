using AdministratorApplication.Models;
using AdministratorApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorApplication.Interfaces
{
    public interface ICharts
    {
       string[] GetNamesOfEmployees();
       void AddRegistryValues(List<RegistryChartModel> chart);
       double GetTime(string time1, string time2);
       string GetTotalHours(string time1, string time2);
    }
}
