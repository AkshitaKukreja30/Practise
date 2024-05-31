using Practise.Interfaces;


namespace Practise.Services
{
    /// <summary>
    /// String Compression: Implement a method to perform basic string compression using the counts of repeated characters.
    //  For example, "aabcccccaaa" would become "a2b1c5a3"
    /// </summary>

    public class StringCompression : IProblems
    {
        public void Execute()
        {
            string compressedString = FindCompressedString("aabcccccaaa");
            Console.WriteLine(compressedString);
        }

        private string FindCompressedString(string str)
        {
            var charArray = str.ToCharArray();

            Array.Sort(charArray);
            string alphabeticalOrderedString = new string(charArray);

            string compressedString = string.Empty;

            foreach (char ch in alphabeticalOrderedString)
            {
                if (compressedString.Contains(ch))
                {
                    continue;
                }

                var count = alphabeticalOrderedString.Where(x => x == ch).Count();
                compressedString += $"{ch}{count}";
            }

            return compressedString;
        }


        private string FindCompressedStringV2(string str) 
        {
            var charArray = str.ToCharArray();

            Array.Sort(charArray);

            string alphabeticalOrderedString = new string(charArray);

            Dictionary<char, int> myDictonary = new Dictionary<char, int>();

            foreach (char ch in alphabeticalOrderedString)
            {
                if (!myDictonary.ContainsKey(ch))
                {
                    myDictonary.Add(ch, str.Where(x => x == ch).Count());
                }
            }

            string finalOutput = string.Empty;
            foreach (var kvp in myDictonary)
            {
                finalOutput = finalOutput + kvp.Key.ToString() + kvp.Value.ToString();
            }

            return finalOutput;
        }
    }
}
