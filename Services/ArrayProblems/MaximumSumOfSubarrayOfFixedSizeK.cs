using Practise.Interfaces;

namespace Practise.Services.ArrayProblems
{
    /// <summary>
    /// Array of integers: [2, 1, 5, 1, 3, 2]
    /// Fixed window size K: 3
    /// Max sum of subarray = [5,1,3] => 9
    /// </summary>
    public class MaximumSumOfSubarrayOfFixedSizeK : IProblems
    {
        public void Execute()
        {
            int[] myArray = new int[] { 2, 1, 5, 1, 3, 2 };
            Console.WriteLine(CalculateMaxSumOfFixedLenSubArrayV2(myArray, 3));
        }

        //private int CalculateMaxSumOfFixedLenSubArray(int [] myArray, int fixedSubArraySize)
        //{
        //    int maxSumOfFixedLen = 0;
        //    int startingIndexOfSubArray = 0;
        //    int currentSum = 0;

        //    for(int right = 0; right <= myArray.Length - 3; right++)
        //    {
        //        currentSum = myArray[right] + myArray[right + 1] + myArray[right + 2];

        //        if(currentSum > maxSumOfFixedLen)
        //        {
        //            maxSumOfFixedLen = currentSum;
        //            startingIndexOfSubArray = right;
        //        }
        //    }

        //    return maxSumOfFixedLen;
        //}


        private int CalculateMaxSumOfFixedLenSubArray(int[] myArray, int k)
        {
            int maxSumOfFixedLen = 0;
            int startingIndexOfSubArray = 0;
            int currentSum = 0;


            for (int right = 0; right < myArray.Length; right++)
            {
                for(int i= right; i < right + k; i++)
                {
                    currentSum = currentSum + myArray[i];
                }

                if (currentSum > maxSumOfFixedLen)
                {
                    maxSumOfFixedLen = currentSum;
                    startingIndexOfSubArray = right;
                }

                currentSum = 0;

            }

            return maxSumOfFixedLen;
        }


        /// <summary>
        /// Approach via example :
        /// [2, 1, 5, 1, 3, 2] with k = 3
        /// sum of first k elements by moving window from left to right , 2+1+5 = 8
        /// keep moving the right pointer of the window further to calculate sum of next substring of k elements i.2. 1+ 5+ 1
        /// for 2+1+5, sum is already calculated. so, do 8 + 1 (next right element) - 2 (first left element)
        /// Keep iterating both pointers
        /// </summary>
        /// <param name="myArray"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        private int CalculateMaxSumOfFixedLenSubArrayV2(int[] myArray, int k)
        {
            int maxSumOfFixedLen = 0;
            int currentSum = 0;
            int left = 0;

            for (int right = 0; right < myArray.Length; right++)
            {
                if(right >= k) // once sum of first k elements is calcuated, keep subtracting the left elements to get the next k elements
                {
                    currentSum = currentSum + myArray[right] - myArray[left];
                    left++; 
                }

                else // to calculate sum of first k elements
                {
                    currentSum = currentSum + myArray[right];
                }

                if (currentSum > maxSumOfFixedLen)
                {
                    maxSumOfFixedLen = currentSum;
                }

            }

            return maxSumOfFixedLen;
        }
    }
}
