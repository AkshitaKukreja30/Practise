using Practise.Interfaces;


namespace Practise.Services
{
    public class SnakeCaseToPascal : IProblems
    {
        /// <summary>
        /// this_is_an_example -> thisIsAnExample
        /// </summary>
        public void Execute()
        {
            string input1 = "this_is_an_example";

            Console.WriteLine(ConvertSnakeToPascal(input1));

        }

        private string ConvertSnakeToPascal(string input1)
        {
            var t = input1.ToCharArray();

            for (int i = 0; i < t.Length - 1; i++)
            {
                if (t[i] == '_')
                {
                    t[i + 1] = char.ToUpper(t[i + 1]);
                }
            }

            t = t.Where(x => x != '_').ToArray();

            string output = new string(t);

            return output;

        }
 
    }
}
