using Practise.Interfaces;


namespace Practise.Services
{
    /// <summary>
    /// Input : I am the original string
    /// Output: Num of vowels, consonants
    /// Output: 8.12
    /// </summary>
    public class CountVowelsAndConsonants : IProblems
    {
        public void Execute()
        {
            string originalString = "I am the original string";
            var counter = Counter(originalString.ToLower());
            int vowelsCounter = counter.Item1;
            int consonantsCounter = counter.Item2;

        }


        private (int,int) Counter(string s1)
        {
            int vowelsCount = 0;
            int consonantsCount = 0;

            for(int i = 0; i < s1.Length; i++)
            {
                if (char.IsLetter(s1[i]))
                {
                    if (isVowel(s1[i]))
                    {
                        vowelsCount++;
                    }
                    else
                    {
                        consonantsCount++;
                    }
                }
               
            }

            return (vowelsCount,consonantsCount);

        }


        private bool isVowel(char ch)
        {
            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch== 'u')
            {
                return true;
            }
            return false;
        }


        private bool isVowelViaLinq(char ch)
        {
            return "aeiouAEIOU".Contains(ch);
        }


    }
}
