using System;
using System.Text;

namespace HangmanApp
{
    class Program
    {
        static void Main()
        {
            //int minChar = 64;
            //int maxChar = 90;

            // Another comment
            // Welcome!
            //Console.WriteLine("**********************\n" +
            //    "*                    *\n" +
            //    "* Welcome to Hangman *\n" +
            //    "*                    *\n" +
            //    "**********************\n");

            // Prompt and store word to be guessed.
            {
                word = string.Empty;
                Console.WriteLine("Please enter your word to be guessed: ");
                cursorRow = Console.CursorTop;
                Console.SetCursorPosition(39, cursorRow - 1);
                word = Console.ReadLine();
                word = word.ToUpper();
                if (!allLetters(word))
                {
                    Console.WriteLine("\nYou entered {0}, which is not a valid word.\n", word);
                    Console.WriteLine("Press any key to try another entry.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            wordArr = word.ToCharArray(0, word.Length);
            sequel = sequel.PadRight(word.Length, '_');
            sequelArr = sequel.ToCharArray(0, sequel.Length);

            Console.Clear();
            Console.WriteLine("Your secret word is: " + word);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();

            // While more guesses remain & word is not solved
            while ((guessCtr < 11) && (sequel != word))
            {
                // Display sequel progress.
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Progress: ");

                for (int i = 0; i < sequelArr.Length; i++)
                {
                    Console.SetCursorPosition(10 + i * 2, 2);
                    Console.WriteLine(sequelArr[i]);
                }

                // Display guesses remaining.
                Console.WriteLine("\nYou have {0} guesses remaining.", Convert.ToString(11 - guessCtr));

                // Prompt for guess.
                while ((strGuess.Length != 1) || !allLetters(strGuess))
                {
                    Console.WriteLine("\nGuess #{0}:  Enter your single-letter guess?", guessCtr);
                    cursorRow = Console.CursorTop;
                    Console.SetCursorPosition(45, cursorRow - 1);
                    strGuess = Console.ReadLine();
                    if ((strGuess.Length != 1) || !allLetters(strGuess))
                    {
                        Console.WriteLine("\nYour entry was invalid.  Please try again.\n");
                    }
                }
                strGuess = strGuess.ToUpper();
                guessCtr++;
                Console.Clear();
                resultStr = "That guess was incorrect!\n";

                for (int i = 0; i < wordArr.Length; i++)
                {
                    if (wordArr[i].ToString() == strGuess)
                    {
                        sequelArr[i] = wordArr[i];
                        resultStr = "That guess was correct!\n";
                    }
                }
                strGuess = string.Empty;
                Console.WriteLine(resultStr);
                sequel = new string(sequelArr);
            }

            Console.Clear();
            if (sequel == word)
            {
                Console.WriteLine("Congratulations!  You have guessed the entire word correctly!\n");
                Console.WriteLine(sequel);
            }
            else
            {
                Console.WriteLine("That's too bad.\n\nYou have exhausted the number of available guesses.\n");
            }
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
        public static bool allLetters(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
    }
}
