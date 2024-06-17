using AdministratorApplication.Models;
using AdministratorApplication.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTestAdminApp
{
    public class RegistrationTest
    {
        [Fact]
        public void Register_ReturnsSuccess()
        {
            // Arrange
            var employee = new EmployeeModel
            {
                Id = 3,
                Email = "test@yahoo.com",
                Nume = "Angajat",
                Prenume = "Angajat",
                DataNasterii = "2000-04-19", 
                Telefon = "1234567890",
                CNP = "1234567890123",
                Functie = "Functie",
                Ore = 8,
                IsAdmin = 1
            };

            var repository = new RegistrationRepository();

            // Act
            var result = repository.Register(employee, "password");

            // Assert
            Xunit.Assert.Equal(RegistrationStatus.Success, result);
        }

        [Fact]
        public void Register_InvalidCredentials()
        {
            // Arrange
            var employee = new EmployeeModel
            {
                Id = 4
            };

            var repository = new RegistrationRepository();

            // Act
            var result = repository.Register(employee, "password");

            // Assert
            Xunit.Assert.Equal(RegistrationStatus.InvalidCredentials, result);
        }

    }
}
