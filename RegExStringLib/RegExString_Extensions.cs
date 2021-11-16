using System;

namespace RegExStringLib.Extensions
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
        public static RegExString AtTheStart(this string str) => RegExString.Matching(str).AtTheStart();
        public static RegExString AtTheEnd(this string str) => RegExString.Matching(str).AtTheEnd();
        public static RegExString AfterPreviousMatch(this string str) => RegExString.Matching(str).AfterPreviousMatch();
        public static RegExString AtStartOfWord(this string str) => RegExString.Matching(str).AtStartOfWord();
        public static RegExString AtEndOfWord(this string str) => RegExString.Matching(str).AtEndOfWord();
        public static RegExString AsWholeWord(this string str) => RegExString.Matching(str).AsWholeWord();
        public static RegExString NotAtStartOfWord(this string str) => RegExString.Matching(str).NotAtStartOfWord();
        public static RegExString NotAtEndOfWord(this string str) => RegExString.Matching(str).NotAtEndOfWord();
        public static RegExString InMiddleOfWord(this string str) => RegExString.Matching(str).InMiddleOfWord();

        //Quantifiers
        public static RegExString ZeroOrMoreTimes(this string str) => RegExString.Matching(str).ZeroOrMoreTimes();
        public static RegExString AtLeastOnce(this string str) => RegExString.Matching(str).AtLeastOnce();
        public static RegExString AtMostOnce(this string str) => RegExString.Matching(str).AtMostOnce();
        public static RegExString NTimes(this string str, int n) => RegExString.Matching(str).NTimes(n);
        public static RegExString AtLeastNTimes(this string str, int n) => RegExString.Matching(str).AtLeastNTimes(n);
        public static RegExString BetweenNandMTimes(this string str, int n, int m) => RegExString.Matching(str).BetweenNandMTimes(n, m);

        //Options
        public static RegExString IgnoreCase(this string str) => RegExString.Matching(str).IgnoreCase();
        public static RegExString ForceCaseSensitive(this string str) => RegExString.Matching(str).ForceCaseSensitive();
    }
}
