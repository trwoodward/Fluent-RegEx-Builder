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
        
    }
}
