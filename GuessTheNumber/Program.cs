using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    public class GuessingGame
    {
        private static int readNumber()
        {
            bool isNumber = false;
            int number = 0;
            do
            {
                string numberString = Console.ReadLine();
                try
                {
                    number = int.Parse(numberString);
                    isNumber = true;
                }
                catch
                {
                    Console.WriteLine("\"{0}\" is not a valid number!", numberString);
                }
            } while (!isNumber);

            return number;
        }

        private static int setRange()
        {
            Console.WriteLine("Enter the range (1 to chosen number, maximum 1 billion): ");
            int range = readNumber();

            bool correctRange = false;
            do
            {
                if (range > 1 && range <= 1000000000)
                {
                    correctRange = true;
                }
                else
                {
                    Console.WriteLine("Invalid range!");
                    range = readNumber();
                }
            } while (!correctRange);

            return range;
        }

        private static int calculateNumberOfGuesses(int range)
        {
            int numberOfGuesses = 0;
            while (range != 0)
            {
                range /= 2;
                numberOfGuesses++;
            }
            return numberOfGuesses;
        }

        private static int thinkOfANumber(int range)
        {
            Random rnd = new Random();
            return rnd.Next(1, range);
        }

        
        private static bool game(int range)
        {
            int numberOfGuesses = calculateNumberOfGuesses(range);
            int number = thinkOfANumber(range);

            bool isWon = false;
            do
            {
                Console.WriteLine("You have {0} guesses left!\n" +
                                    "Your guess: ", numberOfGuesses);
                int guess = readNumber();

                if (guess == number) isWon = true;
                else
                {
                    if (guess > number)
                    {
                        Console.WriteLine("Try something lower!");
                    }
                    else
                    {
                        Console.WriteLine("Try something higher!");
                    }
                    numberOfGuesses--;
                }
            } while (numberOfGuesses != 0 && isWon != true);
            return isWon;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Guess the number game");
            int range = setRange();

            bool isWon = game(range);
            if (isWon)
            {
                Console.WriteLine("Congratulations! You guessed correctly! You win!");
            }
            else
            {
                Console.WriteLine("You are out of guesses! You lose!");
            }

            Console.ReadLine();
        }
    }
}
