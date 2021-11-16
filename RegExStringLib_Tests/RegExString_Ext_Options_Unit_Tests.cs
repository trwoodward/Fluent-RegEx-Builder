using System;
using Xunit;
using RegExStringLib;
using RegExStringLib.Extensions;

namespace RegExStringLib_Tests
{
    public class RegExString_Ext_Options_Unit_Tests
    {
        [Fact]
        public void Ext_IgnoreCase_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            //None

            //Act
            string result = "".IgnoreCase().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void Ext_IgnoreCase_WithRandomString_ReturnsQMarkiThenStringThenQMarkMinusi()
        {
            //Arrange
            string paramString = Guid.NewGuid().ToString();
            string expectedString = "(?i)" + paramString + "(?-i)";

            //Act
            string result = paramString.IgnoreCase();

            //Assert
            Assert.Equal(expectedString, result);
        }
    }
}