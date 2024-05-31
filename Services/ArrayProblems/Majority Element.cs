using Practise.Interfaces;

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
    }
}
