using AdministratorApplication.Repositories;
using Moq;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTestAdminApp
{
    public class StatusTest
    {
        [Fact]
        public void GetNumberOfEmployees_ReturnsCorrectNumbers()
        {
            var repository = new StatusRepository();
          //  SetPrivateProperty(repository, "connection", mockConnection.Object);

            // Act
            var result = repository.GetNumberOfEmployees();

            // Assert
            Xunit.Assert.Equal(4, result[0]); // Verifică numărul total de angajați
            Xunit.Assert.Equal(3, result[1]); // Verifică numărul angajaților activi
            Xunit.Assert.Equal(0, result[2]); // Verifică numărul angajaților inactivi
        }

        [Fact]
        public void GetNumberOfEmployees_ReturnsIncorrectNumbers()
        {
            var repository = new StatusRepository();
            //  SetPrivateProperty(repository, "connection", mockConnection.Object);

            // Act
            var result = repository.GetNumberOfEmployees();

            // Assert
            Xunit.Assert.Equal(4, result[0]); // Verifică numărul total de angajați
            Xunit.Assert.Equal(3, result[1]); // Verifică numărul angajaților activi
            Xunit.Assert.Equal(0, result[2]); // Verifică numărul angajaților inactivi
        }
    }
}
