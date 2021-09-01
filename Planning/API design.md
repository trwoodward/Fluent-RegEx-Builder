# API design document

## Research into similar APIs (links and comments)

- regex-builder (https://github.com/sgreben/regex-builder) - a Java regex builder with both normal and fluent APIs
  * Both versions of the API rely on the 'capture' method to identify sub-expressions. I'd like to try and avoid this if possible, as it is a term and concept familiar to those who already know regular expressions, wheras I'd like to target this project at those who know nothing about regular expressions, but who want to make use of the power and flexiblity they provide.
- fluent-regex (https://github.com/gillyb/fluent-regex) - a typescript library
  * Partially implemented, but makes interesting use of variable length parameters, which is worth considering.

## Initial thoughts and ideas

-

## Classes/ Types

-

## Properties

- 

## Methods