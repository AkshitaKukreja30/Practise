using Practise.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise.Services.ArrayProblems
{
    public class HCF : IProblems
    {
        public void Execute()
        {
            int input1 = 4;
            Console.WriteLine(NumOfPossiblePairs(input1));   // Output: 9

            input1 = 3;
            Console.WriteLine(NumOfPossiblePairs(input1));   // Output: 5
        }

    
        // Method to calculate the number of valid pairs (x, y)
        static int NumOfPossiblePairs(int N)
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

        // Helper method to calculate the Greatest Common Divisor (GCD) using an iterative approach
        static int GCD(int a, int b)
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
