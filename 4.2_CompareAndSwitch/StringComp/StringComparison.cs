// See https://aka.ms/new-console-template for more information
namespace StingComp;
public class StringComparison
{
   static void Main()
   {
    const string CODE_WORD = "peanut";
    // Compare constant to variable with the same value
    string myWord = "peanut";
    if(CODE_WORD == myWord)
    {
        Console.WriteLine("Access Granted!");
    }
    else
    {
        Console.WriteLine("Access Denied!");
    }
    // Now use readline to read the same word from the user and compare
    Console.WriteLine("Enter the code word: ");
    string? input = Console.ReadLine();

    if(input == null)
    {
        Console.WriteLine("Access denied!");
    }
    else if (input == CODE_WORD)
    {
        Console.WriteLine("Access granted!");
    }
    else
    {
        Console.WriteLine("Access denied!");
    }
   }
}
