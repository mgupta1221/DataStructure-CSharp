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
        public int HelperTofindIfStringPresentinDict(string str, string[] Dict)
        {
            if (Dict.Contains(str))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public bool wordBreak(string str, string[] Dict)
        {
            //Base condition
            if (str.Length == 1)
            {
                return true;
            }
            for (var i = 1; i < str.Length; i++)
            {
                var subStr = str.Substring(0, i); //Taking prefix everytime like for "godrej"  =>  "g"  -> "go" -> "god"

                if ((HelperTofindIfStringPresentinDict(subStr, Dict) == 1)
                    && wordBreak(str.Substring(i, str.Length - i), Dict))
                {
                    return true;
                };
            }
            return false;
        }
    }
}

