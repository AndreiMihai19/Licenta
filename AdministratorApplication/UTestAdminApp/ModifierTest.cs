using AdministratorApplication.Repositories;
using AdministratorApplication.Services;
using Moq;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTestAdminApp
{
    public class ModifierTest
    {
        [Fact]
        public void ModifyEmployeeInfo_ReturnsSuccess()
        {
            // Arrange
            int id = 1;
            string currentJobPosition = "CurrentJob";
            string email = "newemail@example.com";
            string password = null;
            string phoneNumber = null;
            string newJobPosition = null;
            int hours = 0; 

            var repository = new ModifierRepository();

            // Act
            var result = repository.ModifyEmployeeInfo(id, currentJobPosition, email, password, phoneNumber, newJobPosition, hours);

            // Assert
            Xunit.Assert.Equal(ModifierStatus.Success, result);
        }

        [Fact]
        public void ModifyEmployeeInfo_NoChanges_ReturnsFailure()
        {
            // Arrange
            int id = 1;
            string currentJobPosition = "CurrentJob";
            string email = null;
            string password = null;
            string phoneNumber = null;
            string newJobPosition = null;
            int hours = 0; // O valoare diferită de 4, 6 sau 8

            var repository = new ModifierRepository();

            // Act
            var result = repository.ModifyEmployeeInfo(id, currentJobPosition, email, password, phoneNumber, newJobPosition, hours);

            // Assert
            Xunit.Assert.Equal(ModifierStatus.Failure, result);
        }

       
    }
}
