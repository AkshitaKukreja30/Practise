using Practise.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
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
            foreach(int num in arrayOfIntegers)
            {
                if(arrayOfIntegers.Count(x => x == num) > numOfElements / 2) return num;
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


        // Num of Decoding


        // CAT Pairs: HCF

        // Snake to Pascal

        // Pascal to Snake



    }

    }
