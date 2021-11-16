using System;
using Xunit;
using RegExStringLib;

namespace RegExStringLib_Tests
{
    public class RegExString_Core_Unit_Tests
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

        [Fact]
        public void Matching_WithRandomContentAsRegExString_ReturnsMatchingContent()
        {
            //Arrange
            string testString = Guid.NewGuid().ToString();
            RegExString testRegExString = new RegExString(testString);

            //Act
            RegExString expression = RegExString.Matching(testRegExString);

            //Assert
            Assert.Equal(testString, expression.ToString());
        }

        [Fact]
        public void Matching_WithRandomContentAsString_ReturnsMatchingContent()
        {
            //Arrange
            string testString = Guid.NewGuid().ToString();

            //Act
            RegExString expression = RegExString.Matching(testString);

            //Assert
            Assert.Equal(testString, expression.ToString());
        }

        [Fact]
        public void Then_WithRandomContentAsString_ReturnsMatchingContent()
        {
            //Arrange
            string testString1 = Guid.NewGuid().ToString();
            string testString2 = Guid.NewGuid().ToString();
            string expectedString = testString1 + testString2;
            RegExString testExpression = RegExString.Matching(testString1);

            //Act
            RegExString result = testExpression.Then(testString2);

            //Assert
            Assert.Equal(expectedString, result.ToString());
        }

        [Fact]
        public void Then_WithRandomContentAsRegExString_ReturnsMatchingContent()
        {
            //Arrange
            string testString1 = Guid.NewGuid().ToString();
            string testString2 = Guid.NewGuid().ToString();
            string expectedString = testString1 + testString2;
            RegExString testExpression1 = RegExString.Matching(testString1);
            RegExString testExpression2 = new RegExString(testString2);

            //Act
            RegExString result = testExpression1.Then(testExpression2);

            //Assert
            Assert.Equal(expectedString, result.ToString());
        }

        [Fact]
        public void Then_WithRandomContentAsStringWithChaining_ReturnsMatchingContent()
        {
            //Arrange
            string testString1 = Guid.NewGuid().ToString();
            string testString2 = Guid.NewGuid().ToString();
            string expectedString = testString1 + testString2;

            //Act
            RegExString result = RegExString.Matching(testString1).Then(testString2);

            //Assert
            Assert.Equal(expectedString, result.ToString());
        }

        [Fact]
        public void Then_WithRandomContentAsRegExStringWithChaining_ReturnsMatchingContent()
        {
            //Arrange
            string testString1 = Guid.NewGuid().ToString();
            string testString2 = Guid.NewGuid().ToString();
            string expectedString = testString1 + testString2;
            RegExString testExpression1 = new RegExString(testString1);
            RegExString testExpression2 = new RegExString(testString2);

            //Act
            RegExString result = RegExString.Matching(testExpression1).Then(testExpression2);

            //Assert
            Assert.Equal(expectedString, result.ToString());
        }
    }
}
