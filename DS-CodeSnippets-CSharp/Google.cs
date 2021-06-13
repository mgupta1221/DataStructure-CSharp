using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_CodeSnippets_CSharp
{
    class Google
    {
        //Interleaved string

        public bool InterleavedString(string A, string B, string C)
        {
            char charA = ' ';
            char charB = ' ';
            char charC = ' ';

            if (A.Length == 0 && B.Length == 0 && C.Length == 0)
            {
                return true;
            }

            if (C.Length == 0)
            {
                return true;
            }
            if (A.Length > 0)
            {
                charA = A.Substring(0, 1)[0];  //taking the first charcter            
            }
            if (B.Length > 0)
            {
                charB = B.Substring(0, 1)[0];
            }
            charC = C.Substring(0, 1)[0];

            //removing the first charcter of the matching chacter from either A or B and passing the rest string recursively
            //Notice the output of 'Remove' is the result which is reassingied to get trimmed string
            return ((charA == charC) && InterleavedString(A.Remove(0, 1), B, C.Remove(0, 1)) ||

            charB == charC && InterleavedString(A, B.Remove(0, 1), C.Remove(0, 1)));


        }

        //Word Break Problem
        public bool HelperTofindIfStringPresentinDict(string str, string[] Dict)
        {
            if (Dict.Contains(str))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool wordBreak(string str, string[] Dict)
        {
            //Base condition
            if (str.Length == 0)
            {
                return true;
            }
            for (var i = 1; i <= str.Length; i++)
            {
                // say Str  is "godrej " than  str.Substring(0, 2) used below is "go" and str.subString(2) is "drej" 
                if ((Dict.Contains(str.Substring(0, i)))
                    && wordBreak(str.Substring(i), Dict))
                {
                    return true;
                }
            }
            return false;
        }


        public bool CheckTreesAreIdentical(Node root1, Node root2)
        {
            var resultLeft = false;
            var resultRight = false;
            if (root1 == null && root2 == null)
            {
                return true;
            }
            if (root1 != null && root2 != null)
            {
                resultLeft = CheckTreesAreIdentical(root1.Left, root2.Left);
                resultRight = CheckTreesAreIdentical(root1.Right, root2.Right);
                return root1.Data == root2.Data && resultLeft && resultRight;
            }
            else
            {
                return false;
            }


        }


        // Q4
        public bool CheckIfTreeIsSubtree(Node root1, Node root2)
        {
            if (root1 == null)
            {
                return false;
            }
            if (root2 == null)
            {
                return true;
            }
            //using previously created funciton to check if trees are identical
            if (CheckTreesAreIdentical(root1, root2)) //Checking if identical
            {
                return true;
            }
            return CheckIfTreeIsSubtree(root1.Left, root2) || CheckIfTreeIsSubtree(root1.Right, root2);

        }


        // Q5  - We will serialize the tree into string to find repeating subtree
        public string CheckIfTreeHas2IdenticalSubtree(Node root1, Dictionary<string, int> hashmap)
        {
            if (root1 == null)
            {
                return "$"; // we are returning dollar becuase node is empty, e.g. node with left and right will be ABC,
                //Similarly, node with 2 consectuive right child will also be ABC, to handle this for empty node we are returinign '$',
                //so  in second case string will be A$B$C, see youtube video for details
            }
            string str = "";
            if (root1.Left == null && root1.Right == null) // this conditon is added to avoid leaf nodes, e.g.  4$$ because leaf does not have children
            {
                return root1.Data.ToString();// notice we do not add to exisitng string we simply return
            }

            str = str + root1.Data;
            str = str + CheckIfTreeHas2IdenticalSubtree(root1.Left, hashmap);
            str = str + CheckIfTreeHas2IdenticalSubtree(root1.Right, hashmap);
            Console.WriteLine(str);
            if (str.Length > 2) // Becuase subtree size should be at least 2
            {
                if (hashmap.ContainsKey(str))
                {
                    hashmap[str]++;   //notice how we increase count in dictionary

                }
                else
                {
                    hashmap.Add(str, 1);
                }
            }

            return str;

        }


        // Q6: Find largest word in dictionary by deleting some characters of given string
        public bool IfWordCanBeFormed(string DictionaryWord, string myWord)
        {
            var DictLength = DictionaryWord.Length;
            var myWordLength = myWord.Length;

            if (DictLength == 0)
            {
                return false;
            }
            if (myWordLength == 0)
            {
                return true;
            }
            var counter = 0;
            var dCounter = 0;
            var wCounter = 0;

            //Console.WriteLine("{0}     {1}", myWord, DictionaryWord);
            while (counter < myWordLength && dCounter < DictLength)
            {
                //Console.WriteLine("{0}     {1}", myWord[wCounter], DictionaryWord[dCounter]);
                //Console.WriteLine();
                //Console.WriteLine();
                if (myWord[wCounter] == DictionaryWord[dCounter])
                {
                    dCounter++;
                    wCounter++;
                }
                else
                {
                    wCounter++;
                }

                counter++;

            }
            if (dCounter == DictLength)
            {
                return true;
            }
            return false;
        }



    }
}

