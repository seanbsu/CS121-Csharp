using System;

namespace HighLow
{
    public class HigherLower
    {
        static void Main()
        {
            const int MAX = 10;
            Random random = new Random();
            bool play = true;

            while (play)
            {
                int answer = random.Next(MAX) + 1;
                bool correctGuess = false;

                Console.Write("I'm thinking of a number between 1 and " + MAX + ".");
                Console.Write(" Guess what it is: ");
                while (!correctGuess)
                {
                    string? guessStr = Console.ReadLine();

                    while (string.IsNullOrEmpty(guessStr))
                    {
                        Console.WriteLine("No guess given.");
                        Console.Write("Guess what it is: ");
                        guessStr = Console.ReadLine();
                    }

                    try
                    {
                        int guess = int.Parse(guessStr);

                        if (guess < 1 || guess > MAX)
                        {
                            Console.WriteLine("Your guess is out of range. Guess again.");
                        }
                        else if (guess == answer)
                        {
                            Console.WriteLine("You got it! Good guessing!\n");
                            correctGuess = true;
                        }
                        else
                        {
                            if(guess < answer){
                                Console.Write("Guess higher: ");
                            }else{
                                 Console.Write("Guess lower: ");
                            }
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Guesses must be a whole number. Try again.");
                    }
                }

                Console.Write("Would you like to play again? (y/n): ");
                string? playAgain = Console.ReadLine();

                while (string.IsNullOrEmpty(playAgain) || (playAgain.ToLower() != "y" && playAgain.ToLower() != "n"))
                {
                    Console.Write("Invalid input. Would you like to play again? (y/n): ");
                    playAgain = Console.ReadLine();
                }

                play = playAgain.ToLower() == "y";
                Console.WriteLine("");
            }

            Console.WriteLine("Game over. Goodbye!");
        }
    }
}
