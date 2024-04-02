using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Models
{
    public class EmployeeModel
    {
        public DateTime DateTime { get; set; }

        public string Nume { get; set; }    

        public string Prenume { get; set; } 

        public string Email { get; set; }

        public string Functie { get; set; } 

        public int OreZi { get; set; }  

        public string OraIn {  get; set; }  

        public string PauzaIn { get; set; } 

        public string PauzaOut { get; set; }    

        public string OraOut { get; set; }

        public double TotalOreLucrate {  get; set; }    

    }
}
