using System;
using Xunit;
using RegExStringLib;
using RegExStringLib.Extensions;

namespace RegExStringLib_Tests
{
    public class RegExString_Ext_Quant_Unit_Tests
    {
        [Fact]
        public void Ext_ZeroOrMoreTimes_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            //None

            //Act
            string result = "".ZeroOrMoreTimes().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void Ext_ZeroOrMoreTimes_WithRandomSingleChar_ReturnsCharThenStar()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            string testString = singleChar + "*";

            //Act
            string result = singleChar.ZeroOrMoreTimes().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void Ext_ZeroOrMOreTimes_WithRandomString_ReturnsStringInParensThenStar()
        {
            //Arrange
            string randString = Guid.NewGuid().ToString();
            string testString = "(" + randString + ")*";

            //Act 
            string result = randString.ZeroOrMoreTimes().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void Ext_AtLeastOnce_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            //None

            //Act
            string result = "".AtLeastOnce().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void Ext_AtLeastOnce_WithRandomSingleChar_ReturnsCharThenPlus()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            string testString = singleChar + "+";

            //Act
            string result = singleChar.AtLeastOnce().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void Ext_AtLeastOnce_WithRandomString_ReturnsStringInParensThenPlus()
        {
            //Arrange
            string randString = Guid.NewGuid().ToString();
            string testString = "(" + randString + ")+";

            //Act 
            string result = randString.AtLeastOnce().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void Ext_AtMostOnce_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            //None

            //Act
            string result = "".AtMostOnce().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void Ext_AtMostOnce_WithRandomSingleChar_ReturnsCharThenQMark()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            string testString = singleChar + "?";

            //Act
            string result = singleChar.AtMostOnce().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void Ext_AtMostOnce_WithRandomString_ReturnsStringInParensThenQMark()
        {
            //Arrange
            string randString = Guid.NewGuid().ToString();
            string testString = "(" + randString + ")?";

            //Act 
            string result = randString.AtMostOnce().ToString();

            //Assert
            Assert.Equal(testString, result);
        }
        
        [Fact]
        public void Ext_NTimes_WithEmptyStringAndRandomInt_ReturnsEmptyString()
        {
            //Arrange
            Random random = new Random();
            int n = random.Next();

            //Act
            string result = "".NTimes(n).ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void Ext_NTimes_WithRandomSingleCharAndRandomInt_ReturnsCharThenNInBraces()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            int n = random.Next();
            string testString = singleChar + "{" + n + "}";

            //Act
            string result = singleChar.NTimes(n).ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void Ext_NTimes_WithRandomStringAndRandomInt_ReturnsStringInParensThenNInBraces()
        {
            //Arrange
            Random random = new Random();
            string randString = Guid.NewGuid().ToString();
            int n = random.Next();
            string testString = "(" + randString + "){" + n + "}";

            //Act 
            string result = randString.NTimes(n).ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void Ext_AtLeastNTimes_WithEmptyStringAndRandomInt_ReturnsEmptyString()
        {
            //Arrange
            Random random = new Random();
            int n = random.Next();

            //Act
            string result = "".AtLeastNTimes(n).ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void Ext_AtLeastNTimes_WithRandomSingleCharAndRandomInt_ReturnsCharThenNCommaInBraces()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            int n = random.Next();
            string testString = singleChar + "{" + n + ",}";

            //Act
            string result = singleChar.AtLeastNTimes(n).ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void Ext_AtLeastNTimes_WithRandomStringAndRandomInt_ReturnsStringInParensThenNCommaInBraces()
        {
            //Arrange
            Random random = new Random();
            string randString = Guid.NewGuid().ToString();
            int n = random.Next();
            string testString = "(" + randString + "){" + n + ",}";

            //Act 
            string result = randString.AtLeastNTimes(n).ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void Ext_BetweenNandMTimes_WithEmptyStringAndRandomInts_ReturnsEmptyString()
        {
            //Arrange
            Random random = new Random();
            int n = random.Next();
            int m = random.Next();

            //Act
            string result = "".BetweenNandMTimes(n, m).ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void Ext_BetweenNandMTimes_WithRandomSingleCharAndRandomInts_ReturnsCharThenNCommaMInBraces()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            int n = random.Next();
            int m = random.Next();
            string testString = singleChar + "{" + n + "," + m + "}";

            //Act
            string result = singleChar.BetweenNandMTimes(n, m).ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void Ext_BetweenNandMTimes_WithRandomStringAndRandomInts_ReturnsStringInParensThenNCommaMInBraces()
        {
            //Arrange
            Random random = new Random();
            string randString = Guid.NewGuid().ToString();
            int n = random.Next();
            int m = random.Next();
            string testString = "(" + randString + "){" + n + "," + m + "}";

            //Act 
            string result = randString.BetweenNandMTimes(n, m).ToString();

            //Assert
            Assert.Equal(testString, result);
        }
    }
}