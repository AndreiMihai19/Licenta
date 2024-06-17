
using AdministratorApplication.Interfaces;
using AdministratorApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework.Internal;
using AdministratorApplication.Services;
using MySql.Data.MySqlClient;
using NUnit.Framework;
using System.Data;
using Xunit;

namespace UTestAdminApp
{
    public class AuthenticationTest
    {
        [Fact]
        public void Authenticate_ReturnsSuccess()
        {
            // Arrange
            string validEmail = "andrei.mihai1904@yahoo.com";
            string validPassword = "andrei";

            var repository = new AuthenticationRepository(validEmail, validPassword);

            // Act
            var result = repository.Authenticate();

            // Assert
            Xunit.Assert.Equal(AuthenticationStatus.Success, result);
        }

        [Fact]
        public void Authenticate_ReturnsFailure()
        {
            // Arrange
            string validEmail = "andrei.mihai1904@yahoo.com";
            string invalidPassword = "mihai";

            var repository = new AuthenticationRepository(validEmail, invalidPassword);

            // Act
            var result = repository.Authenticate();

            // Assert
            Xunit.Assert.Equal(AuthenticationStatus.Failure, result);
        }

        [Fact]
        public void Authenticate_ReturnsInvalidCredentials()
        {
            // Arrange
            string validEmail = "andrei.mihai1904@yahoo.com";
            string invalidPassword = "";

            var repository = new AuthenticationRepository(validEmail, invalidPassword);

            // Act
            var result = repository.Authenticate();

            // Assert
            Xunit.Assert.Equal(AuthenticationStatus.InvalidCredentials, result);
        }

    }
}