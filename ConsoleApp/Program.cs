// See https://aka.ms/new-console-template for more information

using System.Data;

Console.WriteLine("Hello, World!");

var actors = 1;
(int irow, int icol)[] valueTuples = new(int irow, int icol)[actors];
Console.WriteLine(valueTuples[0].irow);
Console.WriteLine(valueTuples[0].icol);

Console.WriteLine("Test String");
