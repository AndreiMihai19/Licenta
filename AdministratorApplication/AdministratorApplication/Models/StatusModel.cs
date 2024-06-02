using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorApplication.Models
{
    public class StatusModel
    {
        public int? Id { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? ClockIn { get; set; }
        public string? StartBreak { get; set; }
        public string? EndBreak { get; set; }
        public string? ClockOut { get; set; }
    }
}
