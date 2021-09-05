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

        [Fact]
        public void ImplcitStringCastUsingAssignment_WithNoContent_ReturnsEmptyString()
        {
            //Arrange
            RegExString expression = new RegExString();

            //Act
            string result = expression;

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void ImplcitStringCastUsingAssignment_WithRandomContent_ReturnsMatchingContent()
        {
            //Arrange
            string testString = Guid.NewGuid().ToString();
            RegExString expression = new RegExString(testString);

            //Act
            string result = expression;

            //Assert
            Assert.Equal(testString, result);
        }

        public string Helper_TakesStringParam_ReturnsString(string param) => param;

        [Fact]
        public void ImplcitStringCastUsingParams_WithNoContent_ReturnsEmptyString()
        {
            //Arrange
            RegExString expression = new RegExString();

            //Act
            string result = Helper_TakesStringParam_ReturnsString(expression);

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void ImplcitStringCastUsingParams_WithRandomContent_ReturnsMatchingContent()
        {
            //Arrange
            string testString = Guid.NewGuid().ToString();
            RegExString expression = new RegExString(testString);

            //Act
            string result = Helper_TakesStringParam_ReturnsString(expression);

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void ImplcitRegExStringCastUsingAssignment_WithRandomContent_ReturnsMatchingContent()
        {
            //Arrange
            string testString = Guid.NewGuid().ToString();

            //Act
            RegExString expression = testString;
            string result = expression.ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        public RegExString Helper_TakesRegExStringParam_ReturnsRegExString(RegExString exString) => exString;

        [Fact]
        public void ImplcitRegExStringCastUsingParams_WithRandomContent_ReturnsMatchingContent()
        {
            //Arrange
            string testString = Guid.NewGuid().ToString();
            
            //Act
            RegExString expression = Helper_TakesRegExStringParam_ReturnsRegExString(testString);
            string result = Helper_TakesStringParam_ReturnsString(expression);

            //Assert
            Assert.Equal(testString, result);
        }

    }
}
