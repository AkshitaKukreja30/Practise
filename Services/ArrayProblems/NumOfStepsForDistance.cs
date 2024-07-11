using Practise.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Practise.Services.ArrayProblems
{
    public class NumOfStepsForDistance : IProblems
    {
        public void Execute()
        {
            //  Given a distance N. The task is to count the total number of ways to cover the distance with 1, 2 and 3 steps.
            //Examples: 
            //Input: N = 3
            //Output: 4
            //All the required ways are(1 + 1 + 1), (1 + 2), (2 + 1) and(3 + 0).
            //Input: N = 4
            //Output: 7

           Console.WriteLine(countWays(3));

        }

        int countWays(int n)
        {
            // Base conditions
            if (n == 0)
                return 1;
            if (n <= 2)
                return n;

            // To store the last three stages
            int f0 = 1, f1 = 1, f2 = 2;
            int ans = 0;

            // Find the numbers of steps required
            // to reach the distance i
            for (int i = 3; i <= n; i++)
            {
                ans = f0 + f1 + f2;
                f0 = f1;
                f1 = f2;
                f2 = ans;
            }

            // Return the required answer
            return ans;
        }

    }
}
