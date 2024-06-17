using MobileApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMobileApp
{
    public class SetOvertimeTest
    {
        [Theory]
        [InlineData("20:00", 8, 20, "00:00")]
        [InlineData("160:00", 8, 20, "00:00")]
        [InlineData("160:01", 8, 20, "0:01")]
        [InlineData("180:00", 8, 20, "20:00")]
        public void SetOvertime_ShouldCalculateCorrectly(string workedHours, int dailyHours, int workingDaysOfMonth, string expectedOvertime)
        {
            // Arrange
            var timeService = new DashboardRepository("email@yahoo.com", 1, 8);

            // Act
            var actualOvertime = timeService.SetOvertime(workedHours, dailyHours, workingDaysOfMonth);

            // Assert
            Assert.Equal(expectedOvertime, actualOvertime);
        }
    }
}
