##Create an application that can take as input any text file and output a histogram of the bigrams in the text.

###Description:

A bigram is any two adjacent words in the text. A histogram is the count of how many times that particular bigram occurred in the text. 

A well formed submission will be runnable from command line and have accompanying unit tests for the bigram parsing and counting code. You may do this in any language you wish and use any framework or data structures you wish to handle reading the files, building up the output, and running the unit tests. However the bigram parsing and counting code must be implemented by yourself.

Example:

Given the text: "The quick brown fox and the quick blue hare." The bigrams with their counts would be.

1. “the quick” 2
2. “quick brown” 1
3. “brown fox” 1
4. “fox and” 1
5. “and the” 1
6. “quick blue” 1
7. “blue hare” 1

####Solution
The solution is written in C# using Dot Net Core v1.1.0, with the "win10-x64" runtime set as default (use "win10-x86" or "win10-arm", and re-build if needed ). It uses xUnit to provide some simple tests. 

It is delivered as a Console Application accepting one parameter of a file path to a text file to extract text from.
If the path has a space in it, surround the entire string with quotes. Under the solution is a folder called "DemoText" that has 3 sample files. 

####Instructions
If running in Visual Studio, change the parameter property in the Debug tab under properties of the Console application to set the correct path to the test file you would like to use. 
If a text file is not provided as a parameter to the console application, it will use default text of "The quick brown fox and the quick blue hare.".

For large file support it reads and processe text one line at a time, parsing the bigrams out and building up a dictionary return object of unique phrases with their Occurence counts.

The unit tests were written in xUnit and pass a path to a file that contains the sample text "The quick brown fox and the quick blue hare." into the service call. One test checks that there were 7 items returned, and the second test that the first item returned had an "Occurence" value of "2"

The tests can be run from within Visual Studio or at the command prompt under the "Console.Tests" directory with the "dotnet test" command

####Note
This is demo code, in a production app I would use dependancy injection, would pull classes and services out into their own files etc. The project structure was generated with the .Net core cli.
