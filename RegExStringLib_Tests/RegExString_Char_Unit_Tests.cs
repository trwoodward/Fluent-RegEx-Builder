using System;
using Xunit;
using RegExStringLib;

namespace RegExStringLib_Tests
{
    public class RegExString_Char_Unit_Tests
    {
        [Fact]
        public void AnyAlphaNumeric_WithinMatching_ReturnsWordChar()
        {
            //Arrange
            //None

            //Act
            RegExString result = RegExString.Matching(
                                                RegExString.AnyAlphaNumeric()
                                            );

            //Assert
            Assert.Equal(@"\w", result.ToString());
        }

        [Fact]
        public void AnyAlphaNumeric_WithinThen_ReturnsWordChar()
        {
            //Arrange
            string testString = Guid.NewGuid().ToString();
            string expectedString = testString + @"\w";

            //Act
            RegExString result = RegExString.Matching(
                                                testString
                                            ).Then(
                                                RegExString.AnyAlphaNumeric()
                                            );

            //Assert
            Assert.Equal(expectedString, result.ToString());
        }

        [Fact]
        public void AnyNonAlphaNumeric_WithinMatching_ReturnsNonWordChar()
        {
            //Arrange
            //None

            //Act
            RegExString result = RegExString.Matching(
                                                RegExString.AnyNonAlphaNumeric()
                                            );

            //Assert
            Assert.Equal(@"\W", result.ToString());
        }

        [Fact]
        public void AnyNonAlphaNumeric_WithinThen_ReturnsNonWordChar()
        {
            //Arrange
            string testString = Guid.NewGuid().ToString();
            string expectedString = testString + @"\W";

            //Act
            RegExString result = RegExString.Matching(
                                                testString
                                            ).Then(
                                                RegExString.AnyNonAlphaNumeric()
                                            );

            //Assert
            Assert.Equal(expectedString, result.ToString());
        }

        [Fact]
        public void AnyDigit_WithinMatching_ReturnsDigitChar()
        {
            //Arrange
            //None

            //Act
            RegExString result = RegExString.Matching(
                                                RegExString.AnyDigit()
                                            );

            //Assert
            Assert.Equal(@"\d", result.ToString());
        }

        [Fact]
        public void AnyDigit_WithinThen_ReturnsDigitChar()
        {
            //Arrange
            string testString = Guid.NewGuid().ToString();
            string expectedString = testString + @"\d";

            //Act
            RegExString result = RegExString.Matching(
                                                testString
                                            ).Then(
                                                RegExString.AnyDigit()
                                            );

            //Assert
            Assert.Equal(expectedString, result.ToString());
        }

        [Fact]
        public void AnyNonDigit_WithinMatching_ReturnsNonDigitChar()
        {
            //Arrange
            //None

            //Act
            RegExString result = RegExString.Matching(
                                                RegExString.AnyNonDigit()
                                            );

            //Assert
            Assert.Equal(@"\D", result.ToString());
        }

        [Fact]
        public void AnyNonDigit_WithinThen_ReturnsNonDigitChar()
        {
            //Arrange
            string testString = Guid.NewGuid().ToString();
            string expectedString = testString + @"\D";

            //Act
            RegExString result = RegExString.Matching(
                                                testString
                                            ).Then(
                                                RegExString.AnyNonDigit()
                                            );

            //Assert
            Assert.Equal(expectedString, result.ToString());
        }

        [Fact]
        public void AnyWhiteSpace_WithinMatching_ReturnsWhiteSpaceChar()
        {
            //Arrange
            //None

            //Act
            RegExString result = RegExString.Matching(
                                                RegExString.AnyWhiteSpace()
                                            );

            //Assert
            Assert.Equal(@"\s", result.ToString());
        }

        [Fact]
        public void AnyWhiteSpace_WithinThen_ReturnsWhiteSpaceChar()
        {
            //Arrange
            string testString = Guid.NewGuid().ToString();
            string expectedString = testString + @"\s";

            //Act
            RegExString result = RegExString.Matching(
                                                testString
                                            ).Then(
                                                RegExString.AnyWhiteSpace()
                                            );

            //Assert
            Assert.Equal(expectedString, result.ToString());
        }

        [Fact]
        public void AnyNonWhiteSpace_WithinMatching_ReturnsNonWhiteSpaceChar()
        {
            //Arrange
            //None

            //Act
            RegExString result = RegExString.Matching(
                                                RegExString.AnyNonWhiteSpace()
                                            );

            //Assert
            Assert.Equal(@"\S", result.ToString());
        }

        [Fact]
        public void AnyNonWhiteSpace_WithinThen_ReturnsNonWhiteSpaceChar()
        {
            //Arrange
            string testString = Guid.NewGuid().ToString();
            string expectedString = testString + @"\S";

            //Act
            RegExString result = RegExString.Matching(
                                                testString
                                            ).Then(
                                                RegExString.AnyNonWhiteSpace()
                                            );

            //Assert
            Assert.Equal(expectedString, result.ToString());
        }

        [Fact]
        public void AnySingleCharacter_WithinMatching_ReturnsWildcardChar()
        {
            //Arrange
            //None

            //Act
            RegExString result = RegExString.Matching(
                                                RegExString.AnySingleCharacter()
                                             );
            
            //Assert
            Assert.Equal(".", result.ToString());
        }

        [Fact]
        public void AnyCharInString_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            string testString = "";

            //Act
            RegExString result = RegExString.AnyCharIn(testString);

            //Assert
            Assert.Equal(testString, result.ToString());
        }

        [Fact]
        public void AnyCharInString_WithRandomSingleChar_ReturnsChar()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string testString = alphabet[random.Next(alphabet.Length)].ToString();

            //Act
            RegExString result = RegExString.AnyCharIn(testString);

            //Assert
            Assert.Equal(testString, result.ToString());
        }

        [Fact]
        public void AnyCharInString_WithRandomString_ReturnsStringInParens()
        {
            //Arrange
            string charGroup = Guid.NewGuid().ToString();
            string testString = "[" + charGroup + "]";

            //Act
            RegExString result = RegExString.AnyCharIn(charGroup);

            //Assert
            Assert.Equal(testString, result.ToString());
        }

        [Fact]
        public void AnyCharInCharArray_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            string testString = "";
            char[] testArray = testString.ToCharArray();

            //Act
            RegExString result = RegExString.AnyCharIn(testArray);

            //Assert
            Assert.Equal(testString, result.ToString());
        }

        [Fact]
        public void AnyCharInCharArray_WithRandomSingleChar_ReturnsChar()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string testString = alphabet[random.Next(alphabet.Length)].ToString();
            char[] testArray = testString.ToCharArray();

            //Act
            RegExString result = RegExString.AnyCharIn(testArray);

            //Assert
            Assert.Equal(testString, result.ToString());
        }

        [Fact]
        public void AnyCharInCharArray_WithRandomString_ReturnsStringInParens()
        {
            //Arrange
            string charGroup = Guid.NewGuid().ToString();
            char[] testArray = charGroup.ToCharArray();
            string testString = "[" + charGroup + "]";

            //Act
            RegExString result = RegExString.AnyCharIn(testArray);

            //Assert
            Assert.Equal(testString, result.ToString());
        }

                [Fact]
        public void AnyCharNotInString_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            string testString = "";

            //Act
            RegExString result = RegExString.AnyCharNotIn(testString);

            //Assert
            Assert.Equal(testString, result.ToString());
        }

        [Fact]
        public void AnyCharNotInString_WithRandomSingleChar_ReturnsCharInParens()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string testString = alphabet[random.Next(alphabet.Length)].ToString();
            string resultString = "[^" + testString + "]";

            //Act
            RegExString result = RegExString.AnyCharNotIn(testString);

            //Assert
            Assert.Equal(resultString, result.ToString());
        }

        [Fact]
        public void AnyCharNotInString_WithRandomString_ReturnsStringInParens()
        {
            //Arrange
            string charGroup = Guid.NewGuid().ToString();
            string testString = "[^" + charGroup + "]";

            //Act
            RegExString result = RegExString.AnyCharNotIn(charGroup);

            //Assert
            Assert.Equal(testString, result.ToString());
        }

        [Fact]
        public void AnyCharNotInCharArray_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            string testString = "";
            char[] testArray = testString.ToCharArray();

            //Act
            RegExString result = RegExString.AnyCharNotIn(testArray);

            //Assert
            Assert.Equal(testString, result.ToString());
        }

        [Fact]
        public void AnyCharNotInCharArray_WithRandomSingleChar_ReturnsCharInParens()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            string testString = alphabet[random.Next(alphabet.Length)].ToString();
            char[] testArray = testString.ToCharArray();
            testString = "[^" + testString + "]";

            //Act
            RegExString result = RegExString.AnyCharNotIn(testArray);

            //Assert
            Assert.Equal(testString, result.ToString());
        }

        [Fact]
        public void AnyCharNotInCharArray_WithRandomString_ReturnsStringInParens()
        {
            //Arrange
            string charGroup = Guid.NewGuid().ToString();
            char[] testArray = charGroup.ToCharArray();
            string testString = "[^" + charGroup + "]";

            //Act
            RegExString result = RegExString.AnyCharNotIn(testArray);

            //Assert
            Assert.Equal(testString, result.ToString());
        }

        [Fact]
        public void AnyCharInRange_WithRandomParams_ReturnsParamsInParensWithHypen()
        {
            //Arrange
            Random random = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            alphabet += alphabet.ToLower();
            char first = alphabet[random.Next(alphabet.Length)];
            char last = alphabet[random.Next(alphabet.Length)];
            string testString = "[" + first.ToString() + "-" + last.ToString() + "]";

            //Act
            RegExString result = RegExString.AnyCharInRange(first, last);

            //Assert
            Assert.Equal(testString, result.ToString());
        }

    }
}