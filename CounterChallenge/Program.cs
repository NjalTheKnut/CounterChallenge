using System;
using System.Linq;
using System.Collections.Generic;
namespace CounterChallenge
{
    public class Program
    {
        private string result;
        static void Main(string[] args)
        {
            Program instance = new Program();
            instance.menu();
        }

        public string getResult()
        {
            return this.result;
        }

        public void menu()
        {
            bool quit = false;
            Console.WriteLine("Welcome to Neal's Counter Challenge Solution!");
            Console.WriteLine("---------------------------------------------\n");
            while (!quit)
            {
                Console.WriteLine("Please type a test string to count, or 'q' to quit, then press Enter:");
                Console.WriteLine("\n");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "q")
                {
                    quit = true;
                }
                else
                {
                    if (userInput != "")
                    {
                        Console.WriteLine("\n");
                        ParseInput(userInput);
                        Console.WriteLine(result);  // output our result variable to the console.
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        Console.WriteLine("\n");
                        Console.WriteLine("The sentence entered cannot be null!  Please enter at least one word.");
                        Console.WriteLine("\n");
                    }
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine("Thank you, and have a great day!");
            Console.WriteLine("---------------------------------------------\n");
            return;
        }

        /* core program logic */
        /*
         Parses the input string and outputs each word in the following format:
                <First> + <Count> + <Last>
            Where:
                <First> is the initial letter of the word
                <Count> is the number of distinct letters found excluding <First> and <Last>
                <Last> is the final letter in the word
            The output is then returned by the function, and stored in a class variable.
         */
        public string ParseInput(string strInput)
        {
            string strOutput = "";  // return variable to send output to the user
            string tmpStr;  //  temporary string variable
            int iter = 0; // Counter variable to track whether we have reached the end of the array.
            char[] inputChars = strInput.ToCharArray();  // collection of the individual characters from user input
            var nonLetters = new List<char>();  // stores all non-alphabetic characters from the input string
            string splitChars = "";  // used to store the non-letter characters so the input can be split into words.
            string[] words; // stores the alphabetic strings between non-aplhabetic characters.
            char[] tmpChars;  //  used as a container to process and add each counted word to the output string.
            /* store all non-Letter characters into an array */
            foreach (char c in inputChars)
            {
                if (!Char.IsLetter(c))
                {
                    nonLetters.Add(c);
                }
            }

            /* segment the input on the nonLetter symbols and store as an array */
            foreach (char c in nonLetters)
            {
                splitChars += c;
            }
            words = strInput.Split(splitChars.ToCharArray());

            /* iterate over each word */
            foreach (string w in words)
            {
                
                if (!Char.IsLetter(strInput[0]) && iter == 0)  // if the first character from input is non-aplhabetic,
                {
                    strOutput += splitChars[iter].ToString();  // then we want to add this directly to output,
                    iter++;  // and increment our iterator to move ahead in the list of non-letter input characters.
                }
                if (w.Length == 1)  // if we encounter a word with only one letter,
                {
                    tmpStr = w;  // then no counting is required, so output as-is.
                } else // otherwise, we have encountered a 2+ letter word that can be counted.
                {
                    if (w.Length == 2)  // if this is a two letter word,
                    {
                        tmpStr = w[0] + "0" + w[1];  // output a zero between them to provide an accurate, consistent count.
                    }
                    else  // otherwise, we have a 3+ letter word to count.
                    {
                        tmpChars = w.ToCharArray(1, w.Length - 2);  // store the letters in this word, excluding the first and last.
                        tmpStr = w[0] + tmpChars.Distinct().ToArray().Length.ToString() + w[w.Length - 1];  // concatenate the first letter, count of distinct letters, and last letter.
                    }
                }
                
                strOutput += tmpStr;  // add the counted word to output.
                if (iter < splitChars.Length)  // if we have not used all of the non-aplhabetic characters yet,
                {
                    strOutput += splitChars[iter].ToString();  // add them after each word until we reach the end.
                    iter++;  // increment our iterator after adding each non-letter character.
                }
            }
            result = strOutput;
            return strOutput;
        }

    }
}
