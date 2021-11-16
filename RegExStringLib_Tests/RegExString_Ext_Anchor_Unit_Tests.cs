using System;
using Xunit;
using RegExStringLib;
using RegExStringLib.Extensions;

namespace RegExStringLib_Tests
{
    public class RegExString_Ext_Anchor_Unit_Tests
    {
        //ToDo - Add tests for anchor extension methods
         public class RegExString_Anchor_Unit_Tests
        {
            [Fact]
            public void Ext_AtTheStart_WithEmptyString_ReturnsEmptyString()
            {
                //Arrange
                //None

                //Act
                string result = "".AtTheStart().ToString();

                //Assert
                Assert.Equal("", result);
            }

            [Fact]
            public void Ext_AtTheStart_WithRandomSingleChar_ReturnsHatThenChar()
            {
                //Arrange
                Random random = new Random();
                string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                alphabet += alphabet.ToLower();
                string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
                string testString = "^" + singleChar;

                //Act
                string result = singleChar.AtTheStart().ToString();

                //Assert
                Assert.Equal(testString, result);
            }

            [Fact]
            public void Ext_AtTheStart_WithRandomString_ReturnsHatThenStringInParens()
            {
                //Arrange
                string randString = Guid.NewGuid().ToString();
                string testString = "^(" + randString + ")";

                //Act 
                string result = randString.AtTheStart().ToString();

                //Assert
                Assert.Equal(testString, result);
            }

            [Fact]
            public void Ext_AtTheEnd_WithEmptyString_ReturnsEmptyString()
            {
                //Arrange
                //None

                //Act
                string result = "".AtTheEnd().ToString();

                //Assert
                Assert.Equal("", result);
            }

            [Fact]
            public void Ext_AtTheEnd_WithRandomSingleChar_ReturnsCharThenDollar()
            {
                //Arrange
                Random random = new Random();
                string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                alphabet += alphabet.ToLower();
                string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
                string testString = singleChar + "$";

                //Act
                string result = singleChar.AtTheEnd().ToString();

                //Assert
                Assert.Equal(testString, result);
            }

            [Fact]
            public void Ext_AtTheEnd_WithRandomString_ReturnsStringInParensThenDollar()
            {
                //Arrange
                string randString = Guid.NewGuid().ToString();
                string testString = "(" + randString + ")$";

                //Act 
                string result = randString.AtTheEnd().ToString();

                //Assert
                Assert.Equal(testString, result);
            }

            [Fact]
            public void Ext_AfterPreviousMatch_WithEmptyString_ReturnsEmptyString()
            {
                //Arrange
                //None

                //Act
                string result = "".AfterPreviousMatch().ToString();

                //Assert
                Assert.Equal("", result);
            }

            [Fact]
            public void Ext_AfterPreviousMatch_WithRandomSingleChar_ReturnsSlashGThenChar()
            {
                //Arrange
                Random random = new Random();
                string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                alphabet += alphabet.ToLower();
                string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
                string testString = @"\G" + singleChar;

                //Act
                string result = singleChar.AfterPreviousMatch().ToString();

                //Assert
                Assert.Equal(testString, result);
            }

            [Fact]
            public void Ext_AfterPreviousMatch_WithRandomString_ReturnsSlashGThenStringInParens()
            {
                //Arrange
                string randString = Guid.NewGuid().ToString();
                string testString = @"\G(" + randString + ")";

                //Act 
                string result = randString.AfterPreviousMatch().ToString();

                //Assert
                Assert.Equal(testString, result);
            }

            [Fact]
            public void Ext_AtStartOfWord_WithEmptyString_ReturnsEmptyString()
            {
                //Arrange
                //None

                //Act
                string result = "".AtStartOfWord().ToString();

                //Assert
                Assert.Equal("", result);
            }

            [Fact]
            public void Ext_AtStartOfWord_WithRandomSingleChar_ReturnsSlashbThenChar()
            {
                //Arrange
                Random random = new Random();
                string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                alphabet += alphabet.ToLower();
                string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
                string testString = @"\b" + singleChar;

                //Act
                string result = singleChar.AtStartOfWord().ToString();

                //Assert
                Assert.Equal(testString, result);
            }

            [Fact]
            public void Ext_AtStartOfWord_WithRandomString_ReturnsSlashbThenStringInParens()
            {
                //Arrange
                string randString = Guid.NewGuid().ToString();
                string testString = @"\b(" + randString + ")";

                //Act 
                string result = randString.AtStartOfWord().ToString();

                //Assert
                Assert.Equal(testString, result);
            }
        

            [Fact]
            public void Ext_AtEndOfWord_WithEmptyString_ReturnsEmptyString()
            {
                //Arrange
                //None

                //Act
                string result = "".AtEndOfWord().ToString();

                //Assert
                Assert.Equal("", result);
            }

            [Fact]
            public void Ext_AtEndOfWord_WithRandomSingleChar_ReturnsCharThenSlashb()
            {
                //Arrange
                Random random = new Random();
                string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                alphabet += alphabet.ToLower();
                string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
                string testString = singleChar + @"\b";

                //Act
                string result = singleChar.AtEndOfWord().ToString();

                //Assert
                Assert.Equal(testString, result);
            }

            [Fact]
            public void Ext_AtTheEndOfWord_WithRandomString_ReturnsStringInParensThenSlashb()
            {
                //Arrange
                string randString = Guid.NewGuid().ToString();
                string testString = "(" + randString + @")\b";

                //Act 
                string result = randString.AtEndOfWord().ToString();

                //Assert
                Assert.Equal(testString, result);
            }

            [Fact]
            public void Ext_AsWholeWord_WithEmptyString_ReturnsEmptyString()
            {
                //Arrange
                //None

                //Act
                string result = "".AsWholeWord().ToString();

                //Assert
                Assert.Equal("", result);
            }

            [Fact]
            public void Ext_AsWholeWord_WithRandomSingleChar_ReturnsCharBetweenSlashbs()
            {
                //Arrange
                Random random = new Random();
                string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                alphabet += alphabet.ToLower();
                string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
                string testString = @"\b" + singleChar + @"\b";

                //Act
                string result = singleChar.AsWholeWord().ToString();

                //Assert
                Assert.Equal(testString, result);
            }

            [Fact]
            public void Ext_AsWholeWord_WithRandomString_ReturnsStringInParensBetweenSlashbs()
            {
                //Arrange
                string randString = Guid.NewGuid().ToString();
                string testString = @"\b(" + randString + @")\b";

                //Act 
                string result = randString.AsWholeWord().ToString();

                //Assert
                Assert.Equal(testString, result);
            }

            [Fact]
            public void Ext_NotAtStartofWord_WithEmptyString_ReturnsEmptyString()
            {
                //Arrange
                //None

                //Act
                string result = "".NotAtStartOfWord().ToString();

                //Assert
                Assert.Equal("", result);
            }

            [Fact]
            public void Ext_NotAtStartOfWord_WithRandomSingleChar_ReturnsSlashBThenChar()
            {
                //Arrange
                Random random = new Random();
                string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                alphabet += alphabet.ToLower();
                string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
                string testString = @"\B" + singleChar;

                //Act
                string result = singleChar.NotAtStartOfWord().ToString();

                //Assert
                Assert.Equal(testString, result);
            }

            [Fact]
            public void Ext_NotAtStartofWord_WithRandomString_ReturnsSlashBThenStringInParens()
            {
                //Arrange
                string randString = Guid.NewGuid().ToString();
                string testString = @"\B(" + randString + ")";

                //Act 
                string result = randString.NotAtStartOfWord().ToString();

                //Assert
                Assert.Equal(testString, result);
            }

            [Fact]
            public void Ext_NotAtEndofWord_WithEmptyString_ReturnsEmptyString()
            {
                //Arrange
                //None

                //Act
                string result = "".NotAtEndOfWord().ToString();

                //Assert
                Assert.Equal("", result);
            }

            [Fact]
            public void Ext_NotEndOfWord_WithRandomSingleChar_ReturnsCharThenSlashB()
            {
                //Arrange
                Random random = new Random();
                string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                alphabet += alphabet.ToLower();
                string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
                string testString = singleChar + @"\B";

                //Act
                string result = singleChar.NotAtEndOfWord().ToString();

                //Assert
                Assert.Equal(testString, result);
            }

            [Fact]
            public void Ext_NotAtEndofWord_WithRandomString_ReturnsStringInParensThenSlashB()
            {
                //Arrange
                string randString = Guid.NewGuid().ToString();
                string testString = "(" + randString + @")\B";

                //Act 
                string result = randString.NotAtEndOfWord().ToString();

                //Assert
                Assert.Equal(testString, result);
            }

            [Fact]
            public void Ext_InMiddleOfWord_WithEmptyString_ReturnsEmptyString()
            {
                //Arrange
                //None

                //Act
                string result = "".InMiddleOfWord().ToString();

                //Assert
                Assert.Equal("", result);
            }

            [Fact]
            public void Ext_InMiddleOfWord_WithRandomSingleChar_ReturnsCharBetweenSlashBs()
            {
                //Arrange
                Random random = new Random();
                string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                alphabet += alphabet.ToLower();
                string singleChar = alphabet[random.Next(alphabet.Length)].ToString();
                string testString = @"\B" + singleChar + @"\B";

                //Act
                string result = singleChar.InMiddleOfWord().ToString();

                //Assert
                Assert.Equal(testString, result);
            }

            [Fact]
            public void Ext_InMiddleofWord_WithRandomString_ReturnsStringInParensBetweenSlashBs()
            {
                //Arrange
                string randString = Guid.NewGuid().ToString();
                string testString = @"\B(" + randString + @")\B";

                //Act 
                string result = randString.InMiddleOfWord().ToString();

                //Assert
                Assert.Equal(testString, result);
            }
        }
    }
}