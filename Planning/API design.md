# API design document

## Research into similar APIs (links and comments)

- regex-builder (https://github.com/sgreben/regex-builder) - a Java regex builder with both normal and fluent APIs
  * Passing elements of the regex as parameters to match/ then is a potentially more natural way to signify sub-expressions, as it automatically conveys the nested nature of subexpressions (even if that is not strictly part of the fluent builder pattern).
  * Both versions of the API rely on the 'capture' method to identify sub-expressions. I'd like to try and avoid this if possible, as it is a term and concept familiar to those who already know regular expressions, wheras I'd like to target this project at those who know nothing about regular expressions, but who want to make use of the power and flexiblity they provide.
- fluent-regex (https://github.com/gillyb/fluent-regex) - a typescript library
  * Partially implemented, but makes interesting use of variable length parameters, which is worth considering.
- Super expressive (https://github.com/francisrstokes/super-expressive) - a javascript API
  * Appears comprehensive, although again the use of 'capture' and other terms that will only be familiar to those who already know something about regular expressions is not desireable for this project, and requiring them to use 'end()' to enclose subexpressions that certain operations are applied to feels potentially error prone. In addition, ending with "toRegex()" feels unnecessary - enabling an implicit cast to a string might be more helpful.

## Initial thoughts and ideas

- Based on consideration of the similar libraries and APIs above, I've taken a number of preliminary design decisions:
  * The primary methods for creating a regex sub-expression will be "matching(...)" and "then(...)", taking a sub-expression as a parameter
  * Although the challenge with this is how to neatly start the method chain in the sub-expression
  * The obvious answer would be another call to matching() but that makes the start of the expression matching(matching(...)...) which isn't very neat (although, with the use of identation, it could make the code easy to read).
  * Extension methods for the string class could allow the strings to be used in the match to be extended directly, which might be neater, especially in simpler sub-expressions.
  * The question of how to deal with invalid RegEx's is interesting. An easy solution would be to use an existing validation tool and either throw an exception or return null when the regEx is converted into a string if it's invalid.
  * A basic but naive implementation involving each method modifying an internal regEx string is probably the best place to start, but for more complex elements I might need to replace that with a logical representation of the regEx using internal classes. This is particularly the case if I decide to implement features that attempt to optimise the regEx created in any way.
  * Another example is if a sub-expression is assigned to a variable and then included in the chain multiple times, then ideally I'd capture it rather than re-including the full sub-expression - but that could prove challenging to implement (note to self: would overloading the assignment operator to set an internal flag work?)
  * Some methods may have to be accessible both statically and via instances to facilitate the fluency of the API

## Features

- Essential:
  * Character classes (e.g. user defined character groups, 'words', whitespace characters, digits etc.)
  * Anchors (e.g. the match must occur at the start, end, or at a boundary)
  * Quantifiers (e.g. how many times an element must occur in the match)
  * Alternation (e.g. 'either' and 'or')
- Desireable:
  * More complex versions of the groups above - e.g. conditional matching in the alternation group, quantifiers that match elements as few times as possible
  * Substitutions
  * Some optional parameters (e.g. case insensitivity)
- Optional:
  * Named and numbered captures
  * Lookarounds

## Classes/ Types

- RegExString
  * Representing both the a regular expression string, and being the builder class for that string

## Methods

### Core methods
- string RegExString.ToString()
  * Returns the string representation of the completed regular expression
- static RegExString RegExString.Matching(RegExString subexpression), static RegExString RegExString.Matching(string matchString)
  * Creates a new expression/ sub-expression
- RegExString Then(RegExString subexpression), RegExString Then(string matchString) //instance method - not static
  * Appends a new sub-expression

### Character classes
- static RegExString RegExString.AnyAlphaNumeric()
  * Represents an expression matching any word character (i.e. alphanumeric characters)
- static RegExString RegExString.AnyNonAlphaNumeric()
  * Represents an expression matching any non-word character
- static RegExString RegExString.AnyDigit()
  * Represents an expression matching any base 10 digit (i.e. 0-9)
- static RegExString RegExString.AnyNonDigit()
  * Represents an expression matching any character other than a base 10 digit
- static RegExString RegExString.AnySingleCharacter()
  * A wildcard representing any single character 
- static RegExString RegExString.AnyCharIn(params char[] charGroup)
- static RegExString RegExString.AnyCharIn(string charGroup)
  * Represents an expression matching any character in a specified set of characters
- static RegExString RegExString.AnyCharNotIn(params char[] charGroup)
- static RegExString RegExString.AnyCharNotIn(string charGroup)
  * Represents an expression matching any character not in a specified set of characters
- static RegExString RegExString.AnyCharInRange(char first, char last)
  * Represents an expression matching any character between 'first' and 'last' in the alphabet
- static RegExString RegExString.AnyWhiteSpace()
  * Represents an expression matching any white-space character or characters
- static RegExString RegExString.AnyNonWhiteSpace()
  * Represents an expression matching any non-white-space character

### Anchors
- RegExString RegExString.AtTheStart()
  * Modifies the current sub-expression so that the match must be at the beginning of the string
- RegExString RegExString.AtTheEnd()
  * Modifies the current sub-expression so that the match must be at the end of the string (or before a newline at the end of the string)
- RegExString RegExString.AfterPreviousMatch()
  * Modifies the current sub-expression so that the match must be after the last match
- RegExString RegExString.AtStartOfWord()
  * Modifies the current sub-expression so that the match must be immediatly after a boundary between an alphanumeric character and a non-alphanumeric character, e.g. a whitespace
- RegExString RegExString.AtEndOfWord()
  * Modifies the current sub-expression so that the match must be immediatly before a boundary between an alphanumeric character and a non-alphanumeric character, e.g. a whitespace
- RegExString RegExString.AsAWholeWord()
  * Modifies the current sub-expression so that the match must be both immediatly before and immediately after a boundary between an alphanumeric character and a non-alphanumeric character, e.g. a whitespace
- RegExString RegExString.NotAtStartOfWord()
  * Modifies the current sub-expression so that the match must NOT be immediately after the boundary between an alphanumeric character and a non-alphanumeric character, e.g. a whitespace
- RegExString RegExString.NotAtEndOfWord()
  * Modifies the current sub-expression so that the match must NOT be immediately before the boundary between an alphanumeric character and a non-alphanumeric character, e.g. a whitespace
- RegExString RegExString.InMiddleOfWord()
  * Modifies the current sub-expression so that the match must NOT be immediately before or after the boundary between an alphanumeric character and a non-alphanumeric character, e.g. a whitespace

### Quantifiers
- RegExString RegExString.ZeroOrMoreTimes()
  * Modifies the current sub-expression so it will be matched zero or more times
- RegExString RegExString.AtLeastOnce()
  * Modifies the current sub-expression so it will be matched one or more times
- RegEXString RegExString.AtMostOnce()
  * Modifies the current sub-expression so it will be matched zero or one time
- RegExString RegExString.NTimes(int n)
  * Modifies the current sub-expression so it will be matched exactly n times
- RegExString RegExString.AtLeastNTimes(int n)
  * Modifies the current sub-expression so it will be matched at least n times
- RegExString RegExString.BetweenNAndMTimes(int n, int m)
  * Modifies the current sub-expression so it will be matched at least n times, but no more than m times

### Alternation
- RegExString RegExString.Or()
  * Modifies the current expression so that it matches provided the sub-expression to the left of the 'Or()' call or the sub-expression to the right of it matches

### Options
- RegExString RegExString.CaseInsensitive()
  * Modifies all subsequent parts of the current expression to make matches case insensitive (Implementation note: If used in a sub-expression it should automatically be reversed at the end of that sub-expression)
- RegExString RegExString.CaseSensitive()
  * Modifies all subsequent parts of the current expression ot make matches case senstive (Implementation note: As this is the default, it should only make a change if the current expression is currently case insenstive, including where this has been inherited from the parent expression)