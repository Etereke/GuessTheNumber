using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    public class GuessingGame
    {
        private static Random rnd = new Random();
        private const int UPPER_BOUND = 1000000000;
        private int ReadNumber()
        {
            int number;
            string numberString = Console.ReadLine();
            while (!int.TryParse(numberString, out number))
            {
                Console.WriteLine("\"{0}\" is not a valid number!", numberString);
                numberString = Console.ReadLine();
            }
            return number;
        }

        private int SetRange()
        {
            Console.WriteLine("Enter the range (1 to chosen number, minimum 2, maximum 1 billion): ");
            int range = ReadNumber();
            while (range <= 1 || range > UPPER_BOUND)
            {
                Console.WriteLine("Invalid range!");
                range = ReadNumber();
            }
            return range;
        }

        private int CalculateNumberOfGuesses(int range)
        {
            int numberOfGuesses = 0;
            while (range != 0)
            {
                range /= 2;
                numberOfGuesses++;
            }
            return numberOfGuesses;
        }
        private void WriteTip(int guess, int number)
        {
            if (guess > number)
            {
                Console.WriteLine("Try something lower!");
            }
            else
            {
                Console.WriteLine("Try something higher!");
            }
        }
        private bool SingleRound(int range)
        {
            Console.WriteLine("\nNew game started");
            int numberOfGuesses = CalculateNumberOfGuesses(range);
            int number = rnd.Next(1, range);
            do
            {
                Console.WriteLine("\nYou have {0} guesses left!\n" +
                                    "Your guess: ", numberOfGuesses);
                int guess = ReadNumber();
                numberOfGuesses--;
                if (guess == number)
                {
                    Console.WriteLine("Congratulations! You guessed correctly! You win!");
                    return true;
                }
                else if (numberOfGuesses > 0)
                {
                    WriteTip(guess, number);
                }
            } while (numberOfGuesses > 0);
            Console.WriteLine("You are out of guesses! You lose!");
            return false;
        }
        public void PlayGame()
        {
            Console.WriteLine("Guess the number game");
            int command;
            do
            {
                Console.WriteLine("\nType [1] to start a new game or [0] to quit");
                command = ReadNumber();
                switch (command)
                {
                    case 0:
                        break;
                    case 1:
                        SingleRound(SetRange());
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            } while (command != 0);
        }
    }
        
    public class MainClass
    {
        static void Main(string[] args)
        {
            GuessingGame guessingGame = new GuessingGame();
            guessingGame.PlayGame();
        }
    }
}
