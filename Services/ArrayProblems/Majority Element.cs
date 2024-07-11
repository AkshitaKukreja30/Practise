using Practise.Interfaces;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Practise.Services.ArrayProblems
{
    /// <summary>
    /// This approach is checking if there is an element in the array that appears more than n / 2 times. The problem is commonly known as the "Majority Element" problem.
    /// </summary>
    public class Majority_Element : IProblems
    {
        public void Execute()
        {
            int input1 = 4;
            int[] input2 = { 1, 2, 3, 4 };
            Console.WriteLine(ComputeIsMajority(input1, input2));

            int[] inpu3 = { 1, 2, 2 };
            Console.WriteLine(SecondLargestNumber(inpu3.Distinct().ToArray()));

            int[] input4 = { 2, 2, 2 };
            Console.WriteLine(SecondLargestNumber(input4.Distinct().ToArray()));
        }

        private int ComputeIsMajority(int input1, int[] input2)
        {
            var half = input1 / 2;
            var isGreater = false;

            foreach (var number in input2)
            {
                var count = input2.Count(x => x == number);
                isGreater = count > half;

                if (isGreater)
                {
                    break;
                }
            }

            int output = isGreater ? 1 : -1;

            return output;
        }



        private int ComputeIsMajorityAK(int input1, int[] input2)
        {
            var half = input2.Length / 2;

            foreach (var item in input2)
            {
                int currentFrequency = input2.Count(x => x == item);
                if (currentFrequency > half)
                {
                    return item;
                }
            }

            return -1;

        }


        private int SecondLargestNumber(int[] inputArray)
        {
            Array.Sort(inputArray);

            return inputArray.Length > 1 ? inputArray[^2] : -1;
        }


        private int SecondLargestNumberV2(int[] inputArray)
        {
            Array.Sort(inputArray);

            Array.Reverse(inputArray);

            return inputArray.Length > 1 ? inputArray[1] : -1;
        }

        private int SecondLargestNumberV3(int[] inputArray)
        {

            // 1 2 7 8 5 6

            int maxNum = int.MinValue;
            int secondLargestNum = int.MinValue;

            for (int i = 0; i < inputArray.Length; i++)
            {
                // If current element is greater than
                // first then update both first and second
                if (inputArray[i] > maxNum)
                {
                    secondLargestNum = maxNum;
                    maxNum = inputArray[i];
                }

                // If arr[i] is in between first
                // and second then update second
                else if (inputArray[i] > secondLargestNum && inputArray[i] != maxNum)
                    secondLargestNum = inputArray[i];
            }

            return secondLargestNum;
        }
    }
}
