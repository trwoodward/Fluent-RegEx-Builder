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
  * 

## Classes/ Types

-

## Properties

- 

## Methods