using Practise.Interfaces;


namespace Practise.Services
{
    public class Anagrams : IProblems
    {
        public void Execute()
        {
            string input1 = "listen";
            string input2 = "silent";


            Console.WriteLine(OptimalApproach(input1, input2));

        }


        private void Approach1(string input1, string input2)
        {
            string s1 = SortString(input1);
            string s2 = SortString(input2);

            bool isAnagram = IsAnagram(input1, input2);

            Console.WriteLine(isAnagram);
        }


        private bool OptimalApproach(string input1, string input2)
        {
            var dictionary1 = GetCharacterFrequency(input1);
            var dictionary2 = GetCharacterFrequency(input2);

            if(CompareDictionaries(dictionary1, dictionary2))
            {
                return true;
            }

            return false;
        }

        private string SortString(string myString)
        {
            string sortedString = string.Empty;
            
            if (!string.IsNullOrEmpty(myString))
            {
                char[] charArray = myString.ToCharArray();
                string s2 = string.Empty;


                // c,b
                // temp = c
                // c = b
                // b = temp

                for (int i = 0; i < charArray.Length; i++)
                {
                    for (int j = i + 1; j < charArray.Length - 1; j++)
                    {
                        if (charArray[i] > charArray[j])
                        {
                            char temp = charArray[i];
                            charArray[i] = charArray[j];
                            charArray[j] = temp;
                        }
                    }
                }

                sortedString = string.Join("", charArray);
            }
            return sortedString;
        }

        private bool IsAnagram(string string1, string string2)
        {
            if(string1 == string2)
            {
                return true;
            }
            return false;
        }



        private Dictionary<char, int> GetCharacterFrequency(string str)
        {
            Dictionary<char, int> frequency = new Dictionary<char, int>();

            foreach (char ch in str)
            {
                if (!frequency.ContainsKey(ch))
                {
                    frequency.Add(ch, 1);
                }
                else
                {
                    frequency[ch]++;
                }
            }

            return frequency;
        }


        private bool CompareDictionaries(Dictionary<char,int>dict1, Dictionary<char, int> dict2)
        {
            if(dict1.Count != dict2.Count)
            {
                return false;
            }
            foreach (var kvp in dict1)
            {
                if(!dict2.ContainsKey(kvp.Key) || ( dict2.ContainsKey(kvp.Key) && dict2[kvp.Key] != kvp.Value))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
