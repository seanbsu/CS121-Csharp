// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

namespace CharComp;

public class CharacterComparison
{
    static void Main()
    {
        string word = "purple";
        char firstLetter = word[0];
        int asciiValue =(int) firstLetter;
        Console.WriteLine("The ascii value of " + firstLetter + " is " + asciiValue);

        if(firstLetter >= 'a' && firstLetter <= 'z')
        {
            Console.WriteLine("It is a lower case letter");
        }
        else if (firstLetter >= 'A' && firstLetter <= 'Z')
        {
            Console.WriteLine("It is an upper case letter");
        }
        else
        {
            Console.WriteLine("It is a number");

        }

    }
}
