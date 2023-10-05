using Practise.Interfaces;


namespace Practise.Services
{
    /// <summary>
    /// Rotate String: Given a string and an integer, rotate the string to the right by that number of positions.
    /// For example, "abcdefg" rotated by 3 positions becomes "efgabcd."
    /// </summary>
    public class StringRotation : IProblems
    {
        public void Execute()
        {
            string rotatedString = RotateString("abcdefg", 3);
            Console.WriteLine(rotatedString);
        }

        private string RotateString(string str1, int num)
        {
            string firstSubstring = string.Empty;
            string secondSubstring = string.Empty;


            for (int i = 0; i < str1.Length; i++)
            {
                if(i <= num)
                {
                    firstSubstring = firstSubstring + str1[i];
                }
                else
                {
                    secondSubstring = secondSubstring + str1[i];
                }

            }

            string rotatedSubstring = secondSubstring + firstSubstring;

            return rotatedSubstring;

        }
    }
}
