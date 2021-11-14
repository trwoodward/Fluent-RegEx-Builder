using System;

namespace RegExStringLib
{
    public static class RegExStringExtensions
    {
         //Extension methods for System.String to allow string literals to be used as a starting point method chain
        
        //Core methods
        public static RegExString Then(this string str, RegExString subexpression) 
        {
            return (new RegExString(str)).Then(subexpression);
        }

        //Anchors
        public static RegExString AtTheStart(this string str) => (new RegExString(str)).AtTheStart();
        public static RegExString AtTheEnd(this string str) => (new RegExString(str)).AtTheEnd();
        public static RegExString AfterPreviousMatch(this string str) => (new RegExString(str)).AfterPreviousMatch();
        public static RegExString AtStartOfWord(this string str) => (new RegExString(str)).AtStartOfWord();
        public static RegExString AtEndOfWord(this string str) => (new RegExString(str)).AtEndOfWord();
        public static RegExString AsWholeWord(this string str) => (new RegExString(str)).AsWholeWord();
        public static RegExString NotAtStartOfWord(this string str) => (new RegExString(str)).NotAtStartOfWord();
        public static RegExString NotAtEndOfWord(this string str) => (new RegExString(str)).NotAtEndOfWord();
        public static RegExString InMiddleOfWord(this string str) => (new RegExString(str)).InMiddleOfWord();

        //Quantifiers
        public static RegExString ZeroOrMoreTimes(this string str) => (new RegExString(str)).ZeroOrMoreTimes();
        public static RegExString AtLeastOnce(this string str) => (new RegExString(str)).AtLeastOnce();
        public static RegExString AtMostOnce(this string str) => (new RegExString(str)).AtMostOnce();
        public static RegExString NTimes(this string str, int n) => (new RegExString(str)).NTimes(n);
        public static RegExString AtLeastNTimes(this string str, int n) => (new RegExString(str)).AtLeastNTimes(n);
        public static RegExString BetweenNandMTimes(this string str, int n, int m) => (new RegExString(str)).BetweenNandMTimes(n, m);

        //Options
        public static RegExString IgnoreCase(this string str) => (new RegExString(str)).IgnoreCase();
        public static RegExString ForceCaseSensitive(this string str) => (new RegExString(str)).ForceCaseSensitive();
    }

}
