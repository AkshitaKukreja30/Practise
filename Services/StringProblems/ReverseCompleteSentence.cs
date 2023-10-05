using Practise.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise.Services
{
    /// <summary>
    /// Input: This is my sentence
    /// Output: ecnetnes ym si sihT
    /// </summary>
    public class ReverseCompleteSentence : IProblems
    {
        public void Execute()
        {
            string originalString = "This is my sentence";
            string reversedString = ReverseASentence(originalString);
            Console.WriteLine(reversedString);

            bool isPalindrome = CheckForPalindrome(originalString, reversedString);
            Console.WriteLine(isPalindrome);
        }



        private string ReverseASentence(string originalString)
        {
            string reversedSentence = string.Empty;

            for (int i = originalString.Length - 1; i >= 0; i--)
            {
                reversedSentence = reversedSentence + originalString[i];
            }

            return reversedSentence;
        }


        private bool CheckForPalindrome(string s1, string s2)
        {
            if(s1 == s2)
            {
                return true;
            }
            return false;
        }
    }
}
