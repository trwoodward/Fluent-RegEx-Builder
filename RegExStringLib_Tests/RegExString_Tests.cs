using System;
using Xunit;
using RegExStringLib;

namespace RegExStringLib_Tests
{
    public class RegExString_Tests
    {
        [Fact]
        public void ToString_WithNoContent_ReturnsEmptyString()
        {
            //Arrange
            RegExString expression = new RegExString();

            //Act
            string result = expression.ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void ToString_WithRandomContent_ReturnsMatchingContent()
        {
            //Arrange
            string testString = Guid.NewGuid().ToString();
            RegExString expression = new RegExString(testString);

            //Act
            string result = expression.ToString();

            //Assert
            Assert.Equal(testString, result);
        }
    }
}
