using Practise.Interfaces;

namespace Practise.Services
{
    public class PascalToSbakeCase : IProblems
    {
        /// <summary>
        /// thisIsAnExample -> this_is_an_example
        /// </summary>
        public void Execute()
        {
            string input1 = "thisIsAnExample";

            Console.WriteLine(ConvertPascalToSnake(input1));

        }

        private string ConvertPascalToSnake(string input1)
        {
            string output = string.Empty;
            foreach (char ch in input1)
            {
                if (char.IsUpper(ch))
                {
                    output = output + '_' + char.ToLower(ch);
                }
                else
                {
                    output = output + ch;
                }
            }

            return output;

        }
    }
}
