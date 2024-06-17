namespace TestAdministratorApplication
{
    public class Tests
    {
        [TestMethod]
        public void Authentication_Success_ShowsMenuWindow()
        {
            // Arrange
            var mockAuth = new Mock<IAuthentication>();
            mockAuth.Setup(auth => auth.Authenticate()).Returns(AuthenticationStatus.Success);

            var loginWindow = new LoginWindow(mockAuth.Object);

            // Act
            loginWindow.txtboxEmail.Text = "test@example.com";
            loginWindow.txtboxPassword.Password = "password";
            loginWindow.Authentication();

            // Assert
            mockAuth.Verify(auth => auth.SetCredentials("test@example.com", "password"), Times.Once);
            Assert.IsFalse(loginWindow.IsEnabled);
        }
    }
}