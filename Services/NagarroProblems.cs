using Practise.Interfaces;
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

        /// <summary>
        /// this_is_a_variable->thisIsAVariable
        /// modify_VariableName->modifyVariableName
        /// thisIsAVariable->this_is_a_variable
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public string ReturnCorrectVariableName(string inputString)
        {
            int indexOfUpperCase = inputString.IndexOf(inputString.FirstOrDefault(x => char.IsUpper(x))) ;
            int indexOfUnderScore = inputString.IndexOf('_');

            string result = string.Empty;

            indexOfUnderScore = indexOfUnderScore >= 0 ? indexOfUnderScore : int.MaxValue;
            indexOfUpperCase = indexOfUpperCase >= 0 ? indexOfUpperCase : int.MaxValue;

            int min = int.Min(indexOfUpperCase, indexOfUnderScore);

            if(min == indexOfUpperCase) // convert to camel case -> thisIsAVariable->this_is_a_variable -> thisIsAN -> this_is_a_n
            {
                for(int i =0; i< inputString.Length; i++)
                {
                    result = char.IsUpper(inputString[i]) ? result + "_" + char.ToLower(inputString[i]) : result + inputString[i];
                }
                return result;
            }

            else     // convert to snake case -> this_is_a_variable->thisIsAVariable
            {
                bool toUpper = false;

                for(int i=0; i< inputString.Length; i++)
                {
                    if (inputString[i] == '_' && i>0)
                    {
                        toUpper = true;
                    }
                    else
                    {
                        result += toUpper ? char.ToUpper(inputString[i]) : inputString[i];
                        toUpper = false;
                    }
                }
                return result;
            }


        }

        // Num of Decoding

        // CAT Pairs: HCF
    }

    }
