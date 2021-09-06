using System;

namespace RegExStringLib
{
    public class RegExString
    {
        //Internal variables
        private string currentString;

        //Constructors
        public RegExString(string matchString)
        {
            currentString = matchString;
        }

        public RegExString() : this("") {}

        //Conversion operators
        public override string ToString() => currentString;
        public static implicit operator string(RegExString exString) => exString.currentString;
        public static implicit operator RegExString(string stringExp) => new RegExString(stringExp);

        //Core methods
        public static RegExString Matching(RegExString subexpression) => new RegExString(subexpression);

        public RegExString Then(RegExString subexpression)
        {
            currentString += subexpression;
            return this;
        }

        //Character classes
        public static RegExString AnyAlphaNumeric() => new RegExString(@"\w");
        public static RegExString AnyNonAlphaNumeric() => new RegExString(@"\W");
        public static RegExString AnyDigit() => new RegExString(@"\d");
        public static RegExString AnyNonDigit() => new RegExString(@"\D");
        public static RegExString AnyWhiteSpace() => new RegExString(@"\s");
        public static RegExString AnyNonWhiteSpace() => new RegExString(@"\S");
        public static RegExString AnySingleCharacter() => new RegExString("*");

        
    }
}
