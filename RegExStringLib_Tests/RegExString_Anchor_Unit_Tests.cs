using System;
using Xunit;
using RegExStringLib;

namespace RegExStringLib_Tests
{
    public class RegExString_Anchor_Unit_Tests
    {
        [Fact]
        public void AtTheStart_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            RegExString expression = new RegExString();

            //Act
            string result = expression.AtTheStart().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void AtTheStart_WithRandomSingleChar_ReturnsHatThenChar()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            RegExString expression = RegExString.Matching(singleChar);
            string testString = "^" + singleChar;

            //Act
            string result = expression.AtTheStart().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void AtTheStart_WithRandomString_ReturnsHatThenStringInParens()
        {
            //Arrange
            string randString = Guid.NewGuid().ToString();
            string testString = "^(" + randString + ")";
            RegExString expression = RegExString.Matching(randString);

            //Act 
            string result = expression.AtTheStart().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void AtTheEnd_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            RegExString expression = new RegExString();

            //Act
            string result = expression.AtTheEnd().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void AtTheEnd_WithRandomSingleChar_ReturnsCharThenDollar()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            RegExString expression = RegExString.Matching(singleChar);
            string testString = singleChar + "$";

            //Act
            string result = expression.AtTheEnd().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void AtTheEnd_WithRandomString_ReturnsStringInParensThenDollar()
        {
            //Arrange
            string randString = Guid.NewGuid().ToString();
            string testString = "(" + randString + ")$";
            RegExString expression = RegExString.Matching(randString);

            //Act 
            string result = expression.AtTheEnd().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void AfterPreviousMatch_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            RegExString expression = new RegExString();

            //Act
            string result = expression.AfterPreviousMatch().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void AfterPreviousMatch_WithRandomSingleChar_ReturnsSlashGThenChar()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            RegExString expression = RegExString.Matching(singleChar);
            string testString = @"\G" + singleChar;

            //Act
            string result = expression.AfterPreviousMatch().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void AfterPreviousMatch_WithRandomString_ReturnsSlashGThenStringInParens()
        {
            //Arrange
            string randString = Guid.NewGuid().ToString();
            string testString = @"\G(" + randString + ")";
            RegExString expression = RegExString.Matching(randString);

            //Act 
            string result = expression.AfterPreviousMatch().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

                [Fact]
        public void AtStartOfWord_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            RegExString expression = new RegExString();

            //Act
            string result = expression.AtStartOfWord().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void AtStartOfWord_WithRandomSingleChar_ReturnsSlashbThenChar()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            RegExString expression = RegExString.Matching(singleChar);
            string testString = @"\b" + singleChar;

            //Act
            string result = expression.AtStartOfWord().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void AtStartOfWord_WithRandomString_ReturnsSlashbThenStringInParens()
        {
            //Arrange
            string randString = Guid.NewGuid().ToString();
            string testString = @"\b(" + randString + ")";
            RegExString expression = RegExString.Matching(randString);

            //Act 
            string result = expression.AtStartOfWord().ToString();

            //Assert
            Assert.Equal(testString, result);
        }
    

        [Fact]
        public void AtEndOfWord_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            RegExString expression = new RegExString();

            //Act
            string result = expression.AtEndOfWord().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void AtEndOfWord_WithRandomSingleChar_ReturnsCharThenSlashb()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            RegExString expression = RegExString.Matching(singleChar);
            string testString = singleChar + @"\b";

            //Act
            string result = expression.AtEndOfWord().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void AtTheEndOfWord_WithRandomString_ReturnsStringInParensThenSlashb()
        {
            //Arrange
            string randString = Guid.NewGuid().ToString();
            string testString = "(" + randString + @")\b";
            RegExString expression = RegExString.Matching(randString);

            //Act 
            string result = expression.AtEndOfWord().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void AsWholeWord_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            RegExString expression = new RegExString();

            //Act
            string result = expression.AsWholeWord().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void AsWholeWord_WithRandomSingleChar_ReturnsCharBetweenSlashbs()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            RegExString expression = RegExString.Matching(singleChar);
            string testString = @"\b" + singleChar + @"\b";

            //Act
            string result = expression.AsWholeWord().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void AsWholeWord_WithRandomString_ReturnsStringInParensBetweenSlashbs()
        {
            //Arrange
            string randString = Guid.NewGuid().ToString();
            string testString = @"\b(" + randString + @")\b";
            RegExString expression = RegExString.Matching(randString);

            //Act 
            string result = expression.AsWholeWord().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void NotAtStartofWord_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            RegExString expression = new RegExString();

            //Act
            string result = expression.NotAtStartOfWord().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void NotAtStartOfWord_WithRandomSingleChar_ReturnsSlashBThenChar()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            RegExString expression = RegExString.Matching(singleChar);
            string testString = @"\B" + singleChar;

            //Act
            string result = expression.NotAtStartOfWord().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void NotAtStartofWord_WithRandomString_ReturnsSlashBThenStringInParens()
        {
            //Arrange
            string randString = Guid.NewGuid().ToString();
            string testString = @"\B(" + randString + ")";
            RegExString expression = RegExString.Matching(randString);

            //Act 
            string result = expression.NotAtStartOfWord().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void NotAtEndofWord_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            RegExString expression = new RegExString();

            //Act
            string result = expression.NotAtEndOfWord().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void NotEndOfWord_WithRandomSingleChar_ReturnsCharThenSlashB()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            RegExString expression = RegExString.Matching(singleChar);
            string testString = singleChar + @"\B";

            //Act
            string result = expression.NotAtEndOfWord().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void NotAtEndofWord_WithRandomString_ReturnsStringInParensThenSlashB()
        {
            //Arrange
            string randString = Guid.NewGuid().ToString();
            string testString = "(" + randString + @")\B";
            RegExString expression = RegExString.Matching(randString);

            //Act 
            string result = expression.NotAtEndOfWord().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void InMiddleOfWord_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            RegExString expression = new RegExString();

            //Act
            string result = expression.InMiddleOfWord().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void InMiddleOfWord_WithRandomSingleChar_ReturnsCharBetweenSlashBs()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
            RegExString expression = RegExString.Matching(singleChar);
            string testString = @"\B" + singleChar + @"\B";

            //Act
            string result = expression.InMiddleOfWord().ToString();

            //Assert
            Assert.Equal(testString, result);
        }

        [Fact]
        public void InMiddleofWord_WithRandomString_ReturnsStringInParensBetweenSlashBs()
        {
            //Arrange
            string randString = Guid.NewGuid().ToString();
            string testString = @"\B(" + randString + @")\B";
            RegExString expression = RegExString.Matching(randString);

            //Act 
            string result = expression.InMiddleOfWord().ToString();

            //Assert
            Assert.Equal(testString, result);
        }
    }
}