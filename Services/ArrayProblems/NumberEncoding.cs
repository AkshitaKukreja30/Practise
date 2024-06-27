using Practise.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Practise.Services.ArrayProblems
{
    public class NumberEncoding : IProblems
    {
        public void Execute()
        {
            Console.WriteLine(NumOfPossibleDecodings("121"));   // Output: 3 POSSIBLE DECODINGS = 'ABA', 'AU' and 'LA'
            Console.WriteLine(NumOfPossibleDecodings("12345")); // Output: 3 POSSIBLE DECODINGS = 'ABCDE', 'LCDE' and 'AWDE'   

            // FindSubstrings("121");
        }

        private int NumOfPossibleDecodings(string input)
        {
            if (string.IsNullOrEmpty(input) || input[0] == '0') return 0;

            int n = input.Length;
            
            // prev1 is initialized to 1 because an empty string has one way to be decoded(doing nothing).
            // prev2 is initialized to 1 if the first character is not '0', because a single non-zero digit can be decoded as a letter.

            int prev1 = 1, prev2 = input[0] != '0' ? 1 : 0;

            //This is because we are checking substrings of lengths 1 and 2 starting from the second character onward.
            for (int i = 2; i <= n; i++)
            {
                // Initialization: current is initialized to 0 for each position i.
                int current = 0;

                // Extract the 1-digit substring ending at position i
                //oneDigit is the value of the single digit ending at position i(input[i - 1]).
                int oneDigit = int.Parse(input.Substring(i - 1, 1));

                // Extract the 2-digit substring ending at position i
                // twoDigits is the value of the two-digit number ending at position i (input[i-2] and input[i-1]).
                int twoDigits = int.Parse(input.Substring(i - 2, 2));
                
                //If oneDigit is between 1 and 9(inclusive), it is a valid decoding, so we add prev2(the number of decodings up to the previous position) to current.
                if (oneDigit >= 1) current += prev2;

                //If twoDigits is between 10 and 26(inclusive), it is a valid decoding, so we add prev1(the number of decodings up to two positions before) to current
                if (twoDigits >= 10 && twoDigits <= 26) current += prev1;

                prev1 = prev2;
                prev2 = current;
            }

            return prev2;
        }


        private int FindSubstrings(string input)
        {
            List<int> substrings = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                int oneDigitSubstrings = int.Parse(input.Substring(i, 1));
                substrings.Add(oneDigitSubstrings);

                if(i+1  < input.Length)
                {
                    int twodigitSubstrings = int.Parse(input.Substring(i, 2));
                    substrings.Add(twodigitSubstrings);
                }
            }
            return 1;
        }
    }
}
