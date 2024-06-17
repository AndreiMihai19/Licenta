using MobileApp.Repositories;
using MobileApp.Views;

namespace TestMobileApp
{
    public class GetTotalHoursTest
    {
        [Theory]
        [InlineData("1:30", "2:45", "4:15")]  
        [InlineData("0:45", "0:20", "1:05")]  
        [InlineData("10:30", "2:15", "12:45")]  
        [InlineData("0:00", "1:15", "1:15")] 
        [InlineData("2:00", "1:30", "3:30")]  
        [InlineData("0:30", "0:45", "1:15")]  
        [InlineData("1:59", "0:01", "2:00")]  
        [InlineData("23:45", "1:30", "25:15")]  
        [InlineData("10", "1:30", "11:30")]  
        [InlineData("0:5", "0:5", "1:40")]  
        [InlineData("0:05", "0:05", "0:10")]  
        public void GetTotalHours_ValidInput_ReturnsCorrectTotalHours(string time1, string time2, string expected)
        {
            // Arrange
            var timeCalculator = new DashboardRepository("email@yahoo.com",1,8);

            // Act
            var result = timeCalculator.GetTotalHours(time1, time2);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}