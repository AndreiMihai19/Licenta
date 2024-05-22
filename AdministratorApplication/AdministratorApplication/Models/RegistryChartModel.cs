using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorApplication.Models
{
    public class RegistryChartModel
    {
        public string? NumePrenume { get; set; }
        public string? Data { get; set; }
        public double? OraProgram1 { get; set; }
        public double? OraPauza { get; set; }
        public double? OraProgram2 { get; set; }
        public double? TotalOre { get; set; }
        public string? LunaCalendaristica { get; set; }
        public int? Anul { get; set; }
    }
}
