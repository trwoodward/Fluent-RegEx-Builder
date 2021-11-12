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

        [Fact]
        public void IgnoreCase_WithEmptyString_ReturnsEmptyString()
        {
            //Arrange
            RegExString expression = new RegExString();

            //Act
            string result = expression.IgnoreCase().ToString();

            //Assert
            Assert.Equal("", result);
        }

        [Fact]
        public void IgnoreCase_WithRandomString_ReturnsQMarkiThenStringThenQMarkMinusi()
        {
            //Arrange
            string paramString = Guid.NewGuid().ToString();
            RegExString expression = RegExString.Matching(paramString);
            string expectedString = "(?i)" + paramString + "(?-i)";

            //Act
            string result = expression.IgnoreCase();

            //Assert
            Assert.Equal(expectedString, result);
        }

        // Princeton tests - based on exercises from here: https://www.cs.princeton.edu/courses/archive/fall15/cos226/flipped/quizzes/regexQuiz.html
        [Fact]
        public void PrincetonTest1()
        {
            //Arrange
            string expectedString = "(B(AB|A)*D)*";

            //Act
            string result = RegExString.Matching("B")
                            .Then(
                                RegExString.OneOf("AB", "A")
                                .ZeroOrMoreTimes()
                            )
                            .Then("D")
                            .ZeroOrMoreTimes()
                            .ToString();
            
            //Assert
            Assert.Equal(expectedString, result);
        }

        [Fact]
        public void PrincetonTest2()
        {
            //Arrange
            string expectedString = "A(B*|C)*";

            //Act
            string result = RegExString.Matching("A")
                            .Then(
                                RegExString.OneOf(
                                    RegExString.Matching("B").ZeroOrMoreTimes(), 
                                    "C"
                                ).ZeroOrMoreTimes()
                            );
            
            //Assert
            Assert.Equal(expectedString, result);
        }
    }
}
