using System;
using Xunit;
using RegExStringLib;

namespace RegExStringLib_Tests
{
    public class RegExString_Alter_Unit_Tests
    {
        [Fact]
        public void OneOf_WithNoParams_ReturnsEmptyString()
        {
            //Arrange
            //None 

            //Act
            string result = RegExString.OneOf().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void OneOf_WithEmptyParams_ReturnsEmptyString()
        {
            //Arrange
            RegExString exp1 = new RegExString();
            RegExString exp2 = new RegExString();

            //Act
            string result = RegExString.OneOf(exp1, exp2);

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void OneOf_WithOneParam_ReturnsParamString()
        {
            //Arrange
            string paramString = Guid.NewGuid().ToString();
            RegExString param = new RegExString(paramString);

            //Act
            string result = RegExString.OneOf(param).ToString();

            //Assert
            Assert.Equal(result, param);
        }

        [Fact]
        public void OneOf_WithOneEmptyAndOneNonEmptyParam_ReturnsNonEmptyParamString()
        {
            //Arrange
            string paramString = Guid.NewGuid().ToString();
            RegExString param1 = new RegExString();
            RegExString param2 = new RegExString(paramString);

            //Act
            string result1 = RegExString.OneOf(param1, param2).ToString();
            //Test opposite order
            string result2 = RegExString.OneOf(param2, param1).ToString();

            //Assert
            Assert.Equal(result1, paramString);
            Assert.Equal(result2, paramString);
        }

        [Fact]
        public void OneOf_WithMultipleNonEmptyParams_ReturnsParamStringsSeperatedByOrSymbol()
        {
            //Arrange
            Random random = new Random();
            int numParams = random.Next(10);
            RegExString[] exps = new RegExString[numParams];
            string expectedString = "";
            for (int i = 0; i < numParams; i++)
            {
                string tempString = Guid.NewGuid().ToString();
                exps[i] = new RegExString(tempString);
                expectedString += "|" + tempString;
            }
            if (!string.IsNullOrEmpty(expectedString))
            {
                expectedString = expectedString.Remove(0, 1);
                expectedString = "(" + expectedString + ")";
            }

            //Act
            string result = RegExString.OneOf(exps).ToString();

            //Assert
            Assert.Equal(expectedString, result);
        }

        [Fact]
        public void OneOf_WithMultipleEmptyAndNonEmptyParams_ReturnsParamStringsSeperatedByOrSymbol()
        {
            //Arrange
            Random random = new Random();
            int numParams = random.Next(10);
            RegExString[] exps = new RegExString[numParams];
            string expectedString = "";
            for (int i = 0; i < numParams; i++)
            {
                if (random.Next(2) == 0)
                {
                    string tempString = Guid.NewGuid().ToString();
                    exps[i] = new RegExString(tempString);
                    expectedString += "|" + tempString;
                }
                else
                {
                    exps[i] = new RegExString();
                }
            }
            if (!string.IsNullOrEmpty(expectedString))
            {
                expectedString = expectedString.Remove(0, 1);
                expectedString = "(" + expectedString + ")";
            }

            //Act
            string result = RegExString.OneOf(exps).ToString();

            //Assert
            Assert.Equal(expectedString, result);
        }
    }
}