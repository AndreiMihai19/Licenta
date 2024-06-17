using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace UTestAdministratorApplication
{
    [TestClass]
    public class AuthenticationTest
    {
        [TestMethod]
        public void Authentication_Success_ShowsMenuWindow()
        {
            // Aranjare
            var mockAuth = new Mock<IAuthentication>();
            mockAuth.Setup(auth => auth.Authenticate()).Returns(AuthenticationStatus.Success);
            var loginWindow = new LoginWindow(mockAuth.Object);

            // Setează valorile textbox-urilor
            loginWindow.txtboxEmail.Text = "test@example.com";
            loginWindow.txtboxPassword.Password = "password";

            // Act
            loginWindow.Authentication();

            // Asserts
            mockAuth.Verify(auth => auth.SetCredentials("test@example.com", "password"), Times.Once);
            // Verifică că fereastra MenuWindow este afișată și fereastra de login este închisă
        }
    }
}
