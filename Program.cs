using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CSharp.LabExercise6
{
    class Scrabble
    {
        private static Dictionary<char, int> scoreMap = new Dictionary<char, int>()
        {
            { 'A', 1 }, { 'E', 1 }, { 'I', 1 }, { 'O', 1 }, { 'U', 1 }, { 'L', 1 }, { 'N', 1 }, { 'R', 1 }, {'S', 1}, { 'T', 1 },
            { 'D', 2 }, { 'G', 2 },
            { 'B', 3 }, { 'C', 3 }, { 'M', 3 }, { 'P', 3 },
            { 'F', 4 }, { 'H', 4 }, { 'V', 4 }, { 'W', 4 }, { 'Y', 4 },
            { 'K', 5 },
            { 'J', 8 }, { 'X', 8 },
            { 'Q', 10 }, { 'Z', 10 }
        };
        public int totalScore { get; set; }
        private int letterScore;
        public int ScrabbleScoreCalculator(string InputWord)
        {
            totalScore = 0;
            foreach (char word in InputWord)
            {
                scoreMap.TryGetValue(word, out letterScore);
                totalScore += letterScore;
            }
            return totalScore;
        }
    }

    class ScrabbleDisplay
    {
        public void ScrabbleScoreDisplayer()
        {
            Regex rgx = new Regex("[^A-Za-z]");
            var scrabble = new Scrabble();          
            var answer = "y";
            while (answer.Trim().ToLower().Equals("y"))
            {              
                Console.Write("Enter word: ");
                string inputWord = Console.ReadLine().ToUpper();
                bool invalidInput = rgx.IsMatch(inputWord);

                if (inputWord == null)
                {
                    Console.WriteLine("Please enter a valid input!");
                }
                if (invalidInput)
                {
                    Console.WriteLine("Please enter a valid input!");
                }
                else
                {
                    Console.WriteLine($"Word's total score is: {scrabble.ScrabbleScoreCalculator(inputWord)}");
                }
            }

        }
    }
        internal class Program
        {
            static void Main(string[] args)
            {
                var scrabbleDisplayer = new ScrabbleDisplay();
                scrabbleDisplayer.ScrabbleScoreDisplayer();            
            }
        }
    }

