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
            string compressedString = string.Empty;
            int counter = 1;

            for(int i = 0; i <= str.Length-1; i++)
            {
                if (i == str.Length - 1 || str[i] != str[i + 1])
                {
                    compressedString = compressedString + str[i] + counter;
                    counter = 1;
                }
                else
                {
                    counter++;
                }
            }
            
            return compressedString;
        }
    }
}
