using Practise.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practise.Services
{
    /// <summary>
    /// Write a function that finds the index of the first occurrence of one string within another string 
    /// </summary>
    public class FirstIndexOfStringWithinAnother : IProblems
    {
        public void Execute()
        {
            Console.WriteLine(IndexFinder("Hello World again", "World"));
        }

        private int IndexFinder(string str1, string str2)
        {
            string word = string.Empty;
            string matchingWord = string.Empty;

            for (int i = 0; i < str1.Length; i++)
            {
                if(str1[i] != ' ')
                {
                    word = word + str1[i];
                }

                if(str1[i] == ' ')
                {
                    for (int j = 0; j < str2.Length; j++)
                    {
                        if (word[j] != str2[j])
                        {
                            break;
                        }
                        else
                        {
                            matchingWord = matchingWord + str2[j];
                            if(matchingWord == str2)
                            {
                                return i-matchingWord.Length;
                            }
                        }
                    }
                    word = string.Empty;
                }               
                
            }
            
            return -1;
        }
    }
}
