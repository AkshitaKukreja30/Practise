using Practise.Interfaces;


namespace Practise.Services
{
    public class LongestSubstringWithoutRepeatingChars : IProblems
    {
        public void Execute()
        {
            Console.WriteLine(FindLengthOfLongestSubstringWithoutRepeatingChars("abcabcbb"));
            int result = FindLengthOfLongestSubstringWithoutRepeatingChars("pwwkew");
            Console.WriteLine(FindLengthOfLongestSubstringWithoutRepeatingChars("bbbbb"));
            Console.WriteLine(FindLengthOfLongestSubstringWithoutRepeatingChars(""));
            Console.WriteLine(result);

            Console.WriteLine(FindLongestSubstringWithoutRepeatingChars("pwwkewp"));
            Console.WriteLine(FindLongestSubstringWithoutRepeatingChars("abcabcbb"));

        }


        private int FindLengthOfLongestSubstringWithoutRepeatingChars(string inputString)
        {
            string result = string.Empty;
            HashSet<char> distinctChars = new HashSet<char>();

            for (int i = 0; i < inputString.Length - 1; i++)
            {
                distinctChars.Add(inputString[i]);
            }

            return distinctChars.Count;
        }


        private string FindLongestSubstringWithoutRepeatingChars(string inputString)
        {
            //abcabcbb

            //SLIDING WINDOW

            // Take 2 pointers: left and right to iterate over array/ string
            // 2 more variables: startIndexOfSubstring and maxLengthOfString to know where to begin and end the result substring from
            // Take current char/num , keep iterating and incrementing right i.e moving the window right
            // When condition is not met, shorten your window by incrementing left also
            // Desired substring lies in the sliding window: b/w left and right
            // Length of desired substring is index + 1
            // When max substring is found, the substring will start from left
            // Iterate and get the substring starting from startingIndex and having length maxLength
            // End index of max substring = start + maxLength

            int left = 0;
            int startIndexOfSubstring = 0;
            int maxLengthOfString = 0;

            string result = string.Empty;
            HashSet<char> distinctChars = new HashSet<char>();

            for (int right = 0; right < inputString.Length; right++)
            {
                while (distinctChars.Contains(inputString[right]))
                {
                    distinctChars.Remove(inputString[left]);
                    left++;
                }

                distinctChars.Add(inputString[right]);

                int currentLengthOfSubstring = right - left + 1;

                if (currentLengthOfSubstring > maxLengthOfString)
                {
                    maxLengthOfString = currentLengthOfSubstring;
                    startIndexOfSubstring = left;
                }
            }

            for (int i = startIndexOfSubstring; i < maxLengthOfString + startIndexOfSubstring; i++)
            {
                result = result + inputString[i];
            }

            return result;
        }
    }
}
