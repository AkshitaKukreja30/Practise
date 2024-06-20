using Practise.Interfaces;

namespace Practise.Services.ArrayProblems
{
    /// <summary>
    /// Given a sequence arr[] of size n, Write a function int equilibrium(int[] arr, int n) that returns an equilibrium index (if any) or -1 if no equilibrium index exists. 
    /// The equilibrium index of an array is an index such that the sum of elements at lower indexes is equal to the sum of elements at higher indexes.
   /// </summary>
    
    public class EquiliritumIndex : IProblems
    {
        public void Execute()
        {
            int[] inputArr = { -7, 1, 5, 2, -4, 3, 0  };
            Console.WriteLine(ComputeEquilibriumIndexV2(inputArr));
        }

        private int ComputeEquilibriumIndex(int[] inputArr)
        {
            int leftSum = 0;
            int rightSum = 0;
            
            for(int i = 0; i< inputArr.Length; i++)
            {
                
                for(int j = 0; j< i; j++)
                {
                    leftSum += inputArr[j];
                }

                for(int k = i + 1; k< inputArr.Length; k++)
                {
                    rightSum += inputArr[k];
                }

                if(leftSum == rightSum)
                {
                    return i;
                }

            }

            return -1;
        }

        private int ComputeEquilibriumIndexV2(int[] inputArray)
        {
            int totalSum = 0;
            int rightSum = 0;
            int leftSum = 0;
            
            for(int i = 0; i< inputArray.Length; i++)
            {
                totalSum += inputArray[i];
            }

            for (int j = 0; j < inputArray.Length; j++)
            {
                rightSum = totalSum - leftSum - inputArray[j];

                if(leftSum == rightSum)
                {
                    return j;
                }

                else
                {
                    leftSum = leftSum + inputArray[j];
                }
            }

            return -1;
        }
    }
}
