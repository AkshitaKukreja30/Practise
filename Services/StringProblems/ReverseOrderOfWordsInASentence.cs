using Practise.Interfaces;


namespace Practise.Services
{
    /// <summary>
    /// Input : I am the original string
    /// Output: string original the am I 
    /// </summary>
    public class ReverseOrderOfWordsInASentence : IProblems
    {
        public void Execute()
        {
            string originalString = "I am the original string";
            string reverstedOrderOfWords = ReverseOrderOfWords(originalString);
            Console.WriteLine(reverstedOrderOfWords);

        }

        private string ReverseOrderOfWords(string originalString)
        {
            string reverseOrderOfWordsString = string.Empty;
            string word= string.Empty;

            for (int i = 0; i < originalString.Length; i++)
            {
                //Pull the words one by one
                if(originalString[i] != ' ')
                {
                    word = word + originalString[i];
                }
                //If this is replaced with else or else if, last condition iteration won't run
                if(originalString[i] == ' ' || i == originalString.Length - 1)
                {
                    //We do not need space after the first word as it is going in the end
                    //We need "I" in the end, not "I "
                    if(reverseOrderOfWordsString == "")
                    {
                        reverseOrderOfWordsString = word;
                        word = string.Empty;
                    }

                    else
                    {
                        reverseOrderOfWordsString = word + ' ' + reverseOrderOfWordsString;
                        word = string.Empty;
                    }

                }
            }
            
            return reverseOrderOfWordsString;
        }
    }
}
