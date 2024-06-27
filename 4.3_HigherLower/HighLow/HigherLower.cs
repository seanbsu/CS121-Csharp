namespace HighLow;
public class HigherLower
{
    static void Main()
    {
        const int MAX =10;
        int answer;
        int guess;
        Random random = new Random();
        answer = random.Next(MAX)+1;
        Console.Write("I'm thinking of a number between 1 and " + MAX + ". ");
        Console.Write("Guess what it is: ");

        guess = int.Parse(Console.ReadLine());

        if(guess == answer)
        {
            Console.WriteLine("You got it! Good guessing!");
        }
        else
        {		
		    Console.WriteLine("That is not correct, sorry.");
			Console.WriteLine("The number was " + answer + ".");
        }
        
        Console.WriteLine("Game over. Goodbye!");
    }
}
