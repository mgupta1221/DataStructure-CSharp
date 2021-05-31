using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_CodeSnippets_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var google = new Google();


            // Interleaved String
            //var result = google.InterleavedString("aab", "axy", "aaxaby");
            //Console.WriteLine(result);

            //Word Break Problem
            //Solution: https://www.techiedelight.com/word-break-problem/
            // https://www.geeksforgeeks.org/word-break-problem-dp-32/
            ///https://www.youtube.com/watch?v=XtIGGdrF67E

            string[] Dict = { "mobile","samsung","sam","sung",
                            "man","mango","icecream","and",
                            "go","i","like","ice","cream" };
            Console.WriteLine(google.wordBreak("ilikesamsung", Dict));
            Console.WriteLine(google.wordBreak("iiiiiiii", Dict));
            Console.WriteLine(google.wordBreak("ilikelikeimangoiii", Dict));
            Console.WriteLine(google.wordBreak("samsungandmango", Dict));
            Console.WriteLine(google.wordBreak("samsungandmangok", Dict));
          




            Console.ReadKey();
            //Console.WriteLine(result);
        }
    }
}
