using System;
using System.Collections.Generic;

namespace WordLadder
{
    class Program
    {
        static void Main(string[] args)
        {
            string beginWord = "hot";
            string endWord = "dog";
            IList<string> wordList = new List<string>(){ "hot", "dog"};
            Console.WriteLine(LadderLength(beginWord,endWord,wordList));
        }

        public static int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
         
            Queue<string> queue = new Queue<string>();
            IDictionary<string,int> set = new Dictionary<string,int>();
            int changes = 1;

            queue.Enqueue(beginWord);
            set.Add(beginWord,1);

            if (!wordList.Contains(endWord))
                return 0;

            while (queue.Count != 0)
            {
                int size = queue.Count;
                for (int k = 0; k < size; k++)
                {
                    string currWord = queue.Dequeue();
                    if (currWord.Equals(endWord))
                        return changes;

                    for (int i = 0; i < currWord.Length; i++)
                    {
                        char[] words = currWord.ToCharArray();

                        for (int j = 'a'; j <= 'z'; j++)
                        {
                            words[i] = (char)j;
                            string transformString = new String(words);
                           
                            if (!set.ContainsKey(transformString) && wordList.Contains(transformString))
                            {                            
                                queue.Enqueue(transformString);
                                set.Add(transformString,1);
                            }
                        }
                      
                    }
                }
                ++changes;
            }

            
            return 0;
        }
    }
}
