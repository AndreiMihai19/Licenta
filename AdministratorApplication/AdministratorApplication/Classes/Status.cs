using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorApplication.Classes
{
    public class Status
    {
        public int? Id { get; set; }
        //  public string? Parola{ get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? OraIn { get; set; }
        public string? OraPauzaIn { get; set; }
        public string? OraPauzaOut { get; set; }
        public string? OraOut { get; set; }
    }
}
