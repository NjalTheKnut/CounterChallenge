using System;
using System.Linq;
using System.Collections.Generic;

namespace Counter
{
    public class Program
    {
        // Class Constructor
        public Program()
        {
            Result = "";
        }

        // Accessible Class Variable
        public string Result { get; set; }

        // Class Main Function
        private static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Program instance = new Program();  //  Instantiate the class into a variable.
            instance.Menu();  //  Call the UI function to engage the user for interaction.
        }
        
        // Console User Interface
        public void Menu()
        {
            bool quit = false;
            Console.WriteLine("Welcome to Neal's Counter Challenge Solution!");
            Console.WriteLine("This program counts distinct letters in words.");
            Console.WriteLine("It skips first, last, and non-letter characters.");
            Console.WriteLine("\tEnjoy!");
            Console.WriteLine("------------------------------------------------\n");
            while (!quit)
            {
                Console.WriteLine("Please type a test string to count, or 'q' to quit, then press Enter:");
                Console.Write("-----------------------------------------------------------------------\n");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "q")
                {
                    quit = true;
                }
                else
                {
                    if (userInput != "")  // if the user has entered a valid input,
                    {
                        Console.Write("\n");
                        ParseInput(userInput);  // pass it to our core logic for counting,
                        Console.WriteLine("\t"+Result);  // and output our class level result variable to the console.
                        Console.WriteLine("\n");
                    }
                    else  //  if an empty input is given,
                    {
                        Console.Write("---------------------------------------------------------------------\n");
                        Console.WriteLine("The sentence entered cannot be null!  Please enter at least one word.");
                        Console.WriteLine("---------------------------------------------------------------------\n");
                    }
                }
            }
            Console.WriteLine("\n");
            Console.WriteLine("Thank you, and have a great day!");
            Console.WriteLine("---------------------------------------------\n");
            return;
        }

        /* core program logic */
        /* ------------------------------------------
         * [ParseInput(string)>>>string]
         * [<name>(args)>>>return]
         * ------------------------------------------
         * Parses the input string and outputs each word in the following format:
         *       <First> + <Count> + <Last>
         *   Where:
         *       <First> is the initial letter of the word
         *       <Count> is the number of distinct letters found excluding <First> and <Last>
         *       <Last> is the final letter in the word
         *   The output is then returned by the function, and stored in a class variable.
         */
        public string ParseInput(string strInput)
        {
            // Define local variables (explanatory comments at right)
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
                if (!Char.IsLetter(c))  //  <<< Edit this condition to reuse or repurpose this function  <<<
                {
                    nonLetters.Add(c);
                }
            }

            /* segment our input on its non-letter symbols and store them as an array of words */
            foreach (char c in nonLetters)
            {
                splitChars += c;
            }
            words = strInput.Split(splitChars.ToCharArray());

            /* iterate over each word and execute custom logic as appropriate */
            foreach (string w in words)
            {
                if (w.Length == 1)  // if we encounter a word with only one letter,
                {
                    tmpStr = w;  // then no counting is required, so output as-is.
                } 
                else // otherwise, we have encountered either a 2+ letter word that can be counted, or an "isolated" non-letter character with no adjacent word
                {
                    if (w.Length == 0) // if we have a length of zero, we have encountered a non-letter symbol by itself,
                    {
                        tmpStr = "";  // so set our temporary variable to an empty string to continue, (the symbol is added later).
                    }
                    else  // otherwise, we have a 2+ letter word to count.
                    {
                        tmpChars = w.ToCharArray(1, w.Length - 2);  // store the letters in this word, excluding the first and last.
                        tmpStr = w[0]
                                 + tmpChars.Distinct().ToArray().Length.ToString()
                                 + w[^1];  // concatenate the first letter, count of distinct letters, and last letter.
                    }
                }
                
                strOutput += tmpStr;  // add the counted word to output.
                if (iter < splitChars.Length)  // if we have not used all of the non-aplhabetic characters yet,
                {
                    strOutput += splitChars[iter].ToString();  // add them after each word until we reach the end.
                    iter++;  // increment our iterator after adding each non-letter character.
                }
            }
            Result = strOutput;  //  Assign the output we produced to our class level variable.
            return strOutput;  //  Return our result to the caller also, because options are nice!
        }

    }
}
