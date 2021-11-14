using System;
using Xunit;
using RegExStringLib;

namespace RegExStringLib_Tests
{
    public class RegExString_Options_Unit_Tests
    {
        [Fact]
        public void IgnoreCase_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            RegExString expression = new RegExString();

            //Act
            string result = expression.IgnoreCase().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void IgnoreCase_WithRandomString_ReturnsQMarkiThenStringThenQMarkMinusi()
        {
            //Arrange
            string paramString = Guid.NewGuid().ToString();
            RegExString expression = RegExString.Matching(paramString);
            string expectedString = "(?i)" + paramString + "(?-i)";

            //Act
            string result = expression.IgnoreCase();

            //Assert
            Assert.Equal(expectedString, result);
        }
    }
}