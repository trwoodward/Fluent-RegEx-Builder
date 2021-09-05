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
        public static RegExString Matching(RegExString subexpression)
        {
            //ToDo - correct implementation
            RegExString expression = new RegExString();
            expression.currentString += subexpression;
            return expression;
        }

        public RegExString Then(RegExString subexpression)
        {
            //ToDo - correct implementation
            currentString += subexpression;
            return this;
        }
        
    }
}
