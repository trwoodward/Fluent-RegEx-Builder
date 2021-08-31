# Fluent-RegEx-Builder
A C# tool for generating regular expressions in a more intuitive way using a fluent builder pattern

This is a personal project which I am using as a more interesting way of learning regular expressions in .Net. There are many existing regular expression builders for dotnet, and I will reference any that I draw inspiration from. 

I intend to document the progress of this project in this ReadMe. My initial outline of the development plan is below.

## Development plan (outline)

Step 1:
* Design the builder API:
  - List the elements of a RegEx the API needs to mirror
  - Design a fluent builder pattern API that allows these to be used intuitively, considering how other libraries have approached the problem

Step 2:
* Design the internal structure of the builder, taking account of:
  - the different types of character elements
  - the different short-hands for groups of character elements
  - the fact that each of those elements can be used on their own or grouped into sub-expressions
  - the fact that some types of elements modify sub-expressions in specific ways (anchors, negation, qualifiers etc)

Step 3:
* Develop the API using TDD:
  - Create a method stub
  - Create a test for that method
  - Implement the method
  - Repeat for each element of the API

