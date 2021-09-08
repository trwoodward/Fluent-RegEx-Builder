using System;

namespace RegExStringLib
{
    public class RegExString
    {
        //Internal variables
        private string currentString;
        private int numOfElements;

        //Constructors        
        public RegExString(string matchString, int subElements = 1)
        {
            currentString = matchString;
            numOfElements = string.IsNullOrEmpty(currentString) ? 0 : subElements;
        }

        public RegExString() : this("") {}

        //Conversion operators
        public override string ToString() => currentString;
        public static implicit operator string(RegExString exString) => exString.currentString;
        public static implicit operator RegExString(string stringExp)
        {
            return new RegExString(stringExp, CalculateNumElements(stringExp));
        }

        //Core methods
        public static RegExString Matching(RegExString subexpression) => new RegExString(subexpression, subexpression.numOfElements); //ToDo - deal with characters that need to be escaped to match correctly

        public RegExString Then(RegExString subexpression)
        {
            currentString += subexpression;
            numOfElements += subexpression.numOfElements;
            return this;
        }

        //Helper methods
        private static int CalculateNumElements(string expressionString)
        {
            if (expressionString.Length == 1)
            {
                return 1;
            }
            else if (expressionString.Length > 1)
            {
                // ToDo - replace with logic that parses the string and determines the actual number of elements
                // For now, assume that 'Matching' only accepts strings of literals
                return 2; 
            }
            return 0;
        }
        private void WrapElement()
        {
            currentString = "(" + currentString + ")";
        }

        //Character classes
        public static RegExString AnyAlphaNumeric() => new RegExString(@"\w");
        public static RegExString AnyNonAlphaNumeric() => new RegExString(@"\W");
        public static RegExString AnyDigit() => new RegExString(@"\d");
        public static RegExString AnyNonDigit() => new RegExString(@"\D");
        public static RegExString AnyWhiteSpace() => new RegExString(@"\s");
        public static RegExString AnyNonWhiteSpace() => new RegExString(@"\S");
        public static RegExString AnySingleCharacter() => new RegExString(".");
        public static RegExString AnyCharIn(params char[] charGroup) => AnyCharIn(new string(charGroup));
        public static RegExString AnyCharIn(string charGroup)
        {
            if (charGroup?.Length > 1)
            {
                //ToDo - deal with any characters that need to be escaped to match correctly
                return new RegExString("[" + charGroup + "]");
            }
            return new RegExString(charGroup);
        }
        public static RegExString AnyCharNotIn(char[] charGroup) => AnyCharNotIn(new string(charGroup));
        public static RegExString AnyCharNotIn(string charGroup)
        {
            if (!string.IsNullOrEmpty(charGroup))
            {
                return new RegExString("[^" + charGroup + "]");
            }
            return new RegExString(charGroup);
        }
        public static RegExString AnyCharInRange(char first, char last) => new RegExString("[" + first.ToString() + "-" + last.ToString() + "]"); //ToDo - deal with any characters that need to be escaped to match correctly

        //Anchors
        public RegExString AtTheStart()
        {
            if (numOfElements > 1)
                WrapElement();
            currentString = string.IsNullOrEmpty(currentString) ? currentString : "^" + currentString;
            return this;
        }


    }
}
