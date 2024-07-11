using Practise.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise.Services.ArrayProblems
{
    public class LeaderOfAnAray : IProblems
    {
        public void Execute()
        {
            Leaders([1, 0, 5, 4, 3, 2]);
        }


        private void Leaders(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                int j;
                for (j = i + 1; j < inputArray.Length; j++)
                {
                    if (inputArray[i] <= inputArray[j])
                        break;
                }

                // the loop didn't break
                if (j == inputArray.Length)
                    Console.Write(inputArray[i] + " ");

            }
        }


        private void LeadersV2(int[] inputArray)
        {
            //[1, 0, 5, 4, 3, 2];
            int size = inputArray.Length;
            
            int max_from_right = inputArray[size - 1];
            // Rightmost element is always leader
            Console.Write(max_from_right + " ");

            for (int i = size - 2; i >= 0; i--)
            {
                if (max_from_right < inputArray[i])
                {
                    max_from_right = inputArray[i];
                    Console.Write(max_from_right + " ");
                }
            }
        }
    }
}
