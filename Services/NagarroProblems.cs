﻿using Practise.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Practise.Services
{
    public class NagarroProblems : IProblems
    {
        public void Execute()
        {

            CompressedString("babdc"); // Output: a1b2c1d1
            CompressedString("phqgh");  // Output : g1h2p1q1

            Console.WriteLine(ReturnNumThatOccursMoreThanHalfTimes(4, [1, 2, 1, 2])); // output -1
            Console.WriteLine(ReturnNumThatOccursMoreThanHalfTimes(3, [1, 2, 1]));  //output: 1
            Console.WriteLine(ReturnNumThatOccursMoreThanHalfTimes(3, [-5, 2, -5]));  //output: -5

            Console.WriteLine(ReturnSecondLargestNumOfAnArray(3, [2, 2, 2])); // output -1
            Console.WriteLine(ReturnSecondLargestNumOfAnArray(3, [2, 1, 2])); // output 2

            Console.WriteLine(ReturnCorrectVariableName("this_is_a_variable")); //thisIsAVariable
            Console.WriteLine(ReturnCorrectVariableName("modify_VariableName")); //modifyVariableName
            Console.WriteLine(ReturnCorrectVariableName("thisIsAVariable")); //this_is_a_variable
            Console.WriteLine(ReturnCorrectVariableName("aNA")); //a_n_a
            Console.WriteLine(ReturnCorrectVariableName("this_is_a_variable_v_")); //thisIsAVariableV
            Console.WriteLine(ReturnCorrectVariableName("_randomName")); //randomName
            Console.WriteLine(ReturnCorrectVariableName("Name_Of")); //name_of : NOT WORKING

            Console.WriteLine(NumOfPossibleDecodings("121"));   // Output: 3 POSSIBLE DECODINGS = 'ABA', 'AU' and 'LA'
            Console.WriteLine(NumOfPossibleDecodings("12345")); // Output: 3 POSSIBLE DECODINGS = 'ABCDE', 'LCDE' and 'AWDE'   

            Console.WriteLine(NumOfPossiblePairs(3));   // Output: 5
            Console.WriteLine(NumOfPossiblePairs(4));   // Output: 9


        }


        //  Compression: Implement a method to perform basic string compression using the counts of repeated characters.
        public string CompressedString(string inputString)
        {
            var charArray = inputString.ToCharArray();

            Array.Sort(charArray);
            string compressedString = string.Empty;

            foreach (char ch in charArray)
            {
                if(!compressedString.Contains(ch))
                {
                    compressedString += ch.ToString() + inputString.Count(x => x == ch).ToString();
                }
            }

            return compressedString;
        }

        // Find majority element which occurs more than half times
        // If no such num exists, return -1
        public int ReturnNumThatOccursMoreThanHalfTimes(int numOfElements, int[] arrayOfIntegers)
        {
            int half = numOfElements / 2; 
            foreach (int num in arrayOfIntegers)
            {
                if(arrayOfIntegers.Count(x => x == num) > half) return num;
            }
            return -1;

        }


        // Second Largest Number of Array
        public int ReturnSecondLargestNumOfAnArray(int numOfElements, int [] arrayOfNumbers)
        {
            var distintArray = arrayOfNumbers.Distinct().ToArray();
            
            Array.Sort(distintArray);

            if (distintArray.Count() < 2) return -1;

            return arrayOfNumbers.OrderByDescending(x => x).ToArray()[1];

        }



        public static string ConvertCamelToSnake(string input)
        {
            string result = string.Empty;

            input = input.Replace("_","");

            // Traverse each character
            foreach (char c in input)
            {
                if (char.IsUpper(c))
                {
                    // Insert an underscore before an uppercase letter and convert it to lowercase
                    result += "_" + char.ToLower(c);
                }
                else
                {
                    result += c;
                }
            }

            // Remove the leading underscore if it exists
            if (result.StartsWith("_"))
            {
                result = result.Substring(1);
            }

            return result;
        }



        public static string ConvertSnakeToCamel(string input)
        {
            string result = string.Empty;
            bool isNextUpper = false;

            // Remove leading and trailing underscores
            input = input.Trim('_');

            foreach (char c in input)
            {
                if (c == '_')
                {
                    // The next character should be uppercase
                    isNextUpper = true;
                }
                else
                {
                    // If flag is set, convert the letter to uppercase, else keep it as it is
                    if (isNextUpper)
                    {
                        result += char.ToUpper(c); // Convert next letter to uppercase
                        isNextUpper = false; // Reset flag
                    }
                    else
                    {
                        result += c; // Keep letter as it is
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// this_is_a_variable->thisIsAVariable
        /// modify_VariableName->modifyVariableName
        /// thisIsAVariable->this_is_a_variable
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public string ReturnCorrectVariableName(string input)
        {
            // Trim leading/trailing spaces and underscores
            input = input.Trim();

            int indexOfUpperCase = input.IndexOf(input.FirstOrDefault(x => char.IsUpper(x)));
            int indexOfUnderScore = input.IndexOf('_');

            string result = string.Empty;

            indexOfUnderScore = indexOfUnderScore >= 0 ? indexOfUnderScore : int.MaxValue;
            indexOfUpperCase = indexOfUpperCase >= 0 ? indexOfUpperCase : int.MaxValue;

            int min = int.Min(indexOfUpperCase, indexOfUnderScore);

            if (min == indexOfUpperCase)
            {
                return ConvertCamelToSnake(input);
            }
            else
            {
                return ConvertSnakeToCamel(input);
            }

        }

        // Num of Decoding
        public int NumOfPossibleDecodings(string input)
        {
            if (string.IsNullOrEmpty(input) || input[0] == '0') return 0;

            int n = input.Length;
            int prev1 = 1, prev2 = input[0] != '0' ? 1 : 0;

            for (int i = 2; i <= n; i++)
            {
                int current = 0;
                int oneDigit = int.Parse(input.Substring(i - 1, 1));
                int twoDigits = int.Parse(input.Substring(i - 2, 2));
                if (oneDigit >= 1) current += prev2;
                if (twoDigits >= 10 && twoDigits <= 26) current += prev1;
                prev1 = prev2;
                prev2 = current;
            }

            return prev2;
        }

        // CAT Pairs: HCF

        public int NumOfPossiblePairs(int N)
        {
            int count = 0;

            // Iterate through all possible values of x from 0 to N-1
            for (int x = 0; x < N; x++)
            {
                // Iterate through all possible values of y from 0 to N-1
                for (int y = 0; y < N; y++)
                {
                    // Check if the HCF (Highest Common Factor) of x and y is 1
                    if (GCD(x, y) == 1)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public int GCD(int a, int b)
        {
            // Loop until b becomes 0
            while (b != 0)
            {
                int temp = b;
                b = a % b;  // b is Remainder of a and b
                a = temp;
            }
            // Return the final value of a, which is the GCD
            return a;
        }
    }

    }
