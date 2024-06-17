using MobileApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMobileApp
{
    public class GetTimeTest
    {
        [Theory]
        [InlineData("10:30", "12:45", "2:15")]   // Normal case
        [InlineData("14:50", "16:20", "1:30")]   // Normal case with minutes less than 10
        [InlineData("18:30", "19:15", "0:45")]   // Same hour difference
        [InlineData("1:30", "3:45", "2:15")]     // AM times
        [InlineData("12:30", "12:45", "0:15")]   // Same hour, different minutes
        [InlineData("5:45", "8:15", "2:30")]     // Different hour, different minutes
        public void GetTime_ShouldReturnCorrectDifference(string time1, string time2, string expected)
        {
            // Arrange
            var timeCalculator = new DashboardRepository("email@yahoo.com", 1, 8);

            // Act
            var result = timeCalculator.GetTime(time1, time2);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
