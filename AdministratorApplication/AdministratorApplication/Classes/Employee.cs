using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministratorApplication.Classes
{
    public class Employee
    {
        private int id;
        private string email;
        private string password;
        private string firstName;
        private string lastName;
        private string dateOfBirth;
        private string phoneNumber;
        private string jobPosition;
        private int hours;

        public Employee(int id, string email, string password, string firstName, string lastName, string dateOfBirth, string phoneNumber, string jobPosition, int hours)
        {
            this.id = id;
            this.email = email;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.phoneNumber = phoneNumber;
            this.jobPosition = jobPosition;
            this.hours = hours;
        }

        public int? Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DateOfBirth { get ; set; }
        public string? PhoneNumber { get; set; }
        public string? JobPosition { get; set; }
        public int? Hours { get; set; }

    }
}
