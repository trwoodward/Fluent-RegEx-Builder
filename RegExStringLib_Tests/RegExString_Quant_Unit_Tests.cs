using System;
using Xunit;
using RegExStringLib;

namespace RegExStringLib_Tests
{
    public class RegExString_Quant_Unit_Tests
    {
        [Fact]
        public void ZeroOrMoreTimes_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            RegExString expression = new RegExString();

            //Act
            string result = expression.ZeroOrMoreTimes().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void ZeroOrMoreTimes_WithRandomSingleChar_ReturnsCharThenStar()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            RegExString expression = RegExString.Matching(singleChar);
            string testString = singleChar + "*";

            //Act
            string result = expression.ZeroOrMoreTimes().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void ZeroOrMOreTimes_WithRandomString_ReturnsStringInParensThenStar()
        {
            //Arrange
            string randString = Guid.NewGuid().ToString();
            string testString = "(" + randString + ")*";
            RegExString expression = RegExString.Matching(randString);

            //Act 
            string result = expression.ZeroOrMoreTimes().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void AtLeastOnce_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            RegExString expression = new RegExString();

            //Act
            string result = expression.AtLeastOnce().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void AtLeastOnce_WithRandomSingleChar_ReturnsCharThenPlus()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            RegExString expression = RegExString.Matching(singleChar);
            string testString = singleChar + "+";

            //Act
            string result = expression.AtLeastOnce().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void AtLeastOnce_WithRandomString_ReturnsStringInParensThenPlus()
        {
            //Arrange
            string randString = Guid.NewGuid().ToString();
            string testString = "(" + randString + ")+";
            RegExString expression = RegExString.Matching(randString);

            //Act 
            string result = expression.AtLeastOnce().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void AtMostOnce_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            RegExString expression = new RegExString();

            //Act
            string result = expression.AtMostOnce().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void AtMostOnce_WithRandomSingleChar_ReturnsCharThenQMark()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            RegExString expression = RegExString.Matching(singleChar);
            string testString = singleChar + "?";

            //Act
            string result = expression.AtMostOnce().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void AtMostOnce_WithRandomString_ReturnsStringInParensThenQMark()
        {
            //Arrange
            string randString = Guid.NewGuid().ToString();
            string testString = "(" + randString + ")?";
            RegExString expression = RegExString.Matching(randString);

            //Act 
            string result = expression.AtMostOnce().ToString();

            //Assert
            Assert.Equal(testString, result);
        }
        
        [Fact]
        public void NTimes_WithEmptyStringAndRandomInt_ReturnsEmptyString()
        {
            //Arrange
            Random random = new Random();
            int n = random.Next();
            RegExString expression = new RegExString();

            //Act
            string result = expression.NTimes(n).ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void NTimes_WithRandomSingleCharAndRandomInt_ReturnsCharThenNInBraces()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            RegExString expression = RegExString.Matching(singleChar);
            int n = random.Next();
            string testString = singleChar + "{" + n + "}";

            //Act
            string result = expression.NTimes(n).ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void NTimes_WithRandomStringAndRandomInt_ReturnsStringInParensThenNInBraces()
        {
            //Arrange
            Random random = new Random();
            string randString = Guid.NewGuid().ToString();
            int n = random.Next();
            string testString = "(" + randString + "){" + n + "}";
            RegExString expression = RegExString.Matching(randString);

            //Act 
            string result = expression.NTimes(n).ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void AtLeastNTimes_WithEmptyStringAndRandomInt_ReturnsEmptyString()
        {
            //Arrange
            Random random = new Random();
            int n = random.Next();
            RegExString expression = new RegExString();

            //Act
            string result = expression.AtLeastNTimes(n).ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void AtLeastNTimes_WithRandomSingleCharAndRandomInt_ReturnsCharThenNCommaInBraces()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            RegExString expression = RegExString.Matching(singleChar);
            int n = random.Next();
            string testString = singleChar + "{" + n + ",}";

            //Act
            string result = expression.AtLeastNTimes(n).ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void AtLeastNTimes_WithRandomStringAndRandomInt_ReturnsStringInParensThenNCommaInBraces()
        {
            //Arrange
            Random random = new Random();
            string randString = Guid.NewGuid().ToString();
            int n = random.Next();
            string testString = "(" + randString + "){" + n + ",}";
            RegExString expression = RegExString.Matching(randString);

            //Act 
            string result = expression.AtLeastNTimes(n).ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void BetweenNandMTimes_WithEmptyStringAndRandomInts_ReturnsEmptyString()
        {
            //Arrange
            Random random = new Random();
            int n = random.Next();
            int m = random.Next();
            RegExString expression = new RegExString();

            //Act
            string result = expression.BetweenNandMTimes(n, m).ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void BetweenNandMTimes_WithRandomSingleCharAndRandomInts_ReturnsCharThenNCommaMInBraces()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            RegExString expression = RegExString.Matching(singleChar);
            int n = random.Next();
            int m = random.Next();
            string testString = singleChar + "{" + n + "," + m + "}";

            //Act
            string result = expression.BetweenNandMTimes(n, m).ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void BetweenNandMTimes_WithRandomStringAndRandomInts_ReturnsStringInParensThenNCommaMInBraces()
        {
            //Arrange
            Random random = new Random();
            string randString = Guid.NewGuid().ToString();
            int n = random.Next();
            int m = random.Next();
            string testString = "(" + randString + "){" + n + "," + m + "}";
            RegExString expression = RegExString.Matching(randString);

            //Act 
            string result = expression.BetweenNandMTimes(n, m).ToString();

            //Assert
            Assert.Equal(testString, result);
        }
    }
}