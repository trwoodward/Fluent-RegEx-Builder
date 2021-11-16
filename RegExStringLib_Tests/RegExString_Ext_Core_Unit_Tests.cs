using System;
using Xunit;
using RegExStringLib;
using RegExStringLib.Extensions;

namespace RegExStringLib_Tests
{
    public class RegExString_Ext_Core_Unit_Tests
    {
        [Fact]
        public void Ext_Then_WithRandomContentAsString_ReturnsMatchingContent()
        {
            //Arrange
            string testString1 = Guid.NewGuid().ToString();
            string testString2 = Guid.NewGuid().ToString();
            string expectedString = testString1 + testString2;

            //Act
            RegExString result = testString1.Then(testString2);

            //Assert
            Assert.Equal(expectedString, result.ToString());
        }
    }
}