using Practise.Interfaces;
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
            int[] input2 = {1,2,3,4 };
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



        private int SecondLargestNumber(int[] inputArray)
        {
            Array.Sort(inputArray);

            return inputArray.Length > 1 ?  inputArray[^2] : -1;
        }
    }
}
