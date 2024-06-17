using AdministratorApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTestAdminApp
{
    public class PasswordEncryptorTest
    {

        [Fact]
        public void EncryptPassword_ValidPassword_ReturnsEncryptedPassword()
        {
            // Arrange
            var passwordEncryptor = new PasswordEncryptor();
            var password = "MyStrongPassword";

            // Act
            var encryptedPassword = passwordEncryptor.EncryptPassword(password);

            // Assert
            Assert.NotNull(encryptedPassword);
            Assert.NotEmpty(encryptedPassword);
            Assert.NotEqual(password, encryptedPassword); 
        }

        [Fact]
        public void EncryptPassword_ReturnSamePassword()
        {
            // Arrange
            var passwordEncryptor = new PasswordEncryptor();
            var password = "MyStrongPassword";

            // Act
            var encryptedPassword1 = passwordEncryptor.EncryptPassword(password);
            var encryptedPassword2 = passwordEncryptor.EncryptPassword(password);

            // Assert
            Assert.Equal(encryptedPassword1, encryptedPassword2); 
        }
    }
}
