using System;
using Xunit;
using RegExStringLib;

namespace RegExStringLib_Tests
{
    public class RegExString_Integration_Tests
    {
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