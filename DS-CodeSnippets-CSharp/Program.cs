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
            var facebook = new Facebook();


            //Q1 Interleaved String
            //var result = google.InterleavedString("aab", "axy", "aaxaby");
            //Console.WriteLine(result);

            //Q2Word Break Problem
            //Solution: https://www.techiedelight.com/word-break-problem/
            // https://www.geeksforgeeks.org/word-break-problem-dp-32/
            ///https://www.youtube.com/watch?v=XtIGGdrF67E

            //string[] Dict = { "mobile","samsung","sam","sung",
            //                "man","mango","icecream","and",
            //                "go","i","like","ice","cream" };
            //Console.WriteLine(google.wordBreak("ilikesamsung", Dict));
            //Console.WriteLine(google.wordBreak("iiiiiiii", Dict));
            //Console.WriteLine(google.wordBreak("ilikelikeimangoiii", Dict));
            //Console.WriteLine(google.wordBreak("samsungandmango", Dict));
            //Console.WriteLine(google.wordBreak("samsungandmangok", Dict));


            //Q3:  Check if 2 trees are identical
            //https://www.youtube.com/watch?v=kL5Gs1YTwMM

            //Creating tree first
            BinaryTree tree = new BinaryTree();
            //Creating root node
            Node root1 = new Node(7);
            //Creating Binary tree, function will return root node always
            root1 = tree.BinaryTreeInsert(root1, 3);
            root1 = tree.BinaryTreeInsert(root1, 18);
            root1 = tree.BinaryTreeInsert(root1, 1);
            root1 = tree.BinaryTreeInsert(root1, 9);

            //   Console.WriteLine("Root data: {0}, Left data {1} {2} {3} {4}", root1.Data, root1.Left.Data, root1.Right.Data,
            //root1.Left.Left.Data, root1.Left.Right.Data);

            //Creating second tree
            Node root2 = new Node(7);
            root2 = tree.BinaryTreeInsert(root2, 3);
            root2 = tree.BinaryTreeInsert(root2, 18);
            root2 = tree.BinaryTreeInsert(root2, 1);
            root2 = tree.BinaryTreeInsert(root2, 9); // Creating extra node to check if  identical comes false

            //var finalResult = google.CheckTreesAreIdentical(root1, root2);
            //Console.WriteLine(finalResult);





            //Q4:  Check if  a tree is subtree of another tree
            //https://www.geeksforgeeks.org/check-if-a-binary-tree-is-subtree-of-another-binary-tree/
            //Creating subtree to validate            
            Node root3 = new Node(18);
            root3 = tree.BinaryTreeInsert(root3, 9);

            //var finalResult = google.CheckIfTreeIsSubtree(root1, root3);
            //Console.WriteLine(finalResult);




            //Q5:  Check if a Binary Tree contains duplicate subtrees of size 2 or more
            // https://www.geeksforgeeks.org/check-binary-tree-contains-duplicate-subtrees-size-2/
            // Solution: https://www.youtube.com/watch?v=_j7yb_nWFO8
            // Creating an empty hashmap
            Dictionary<string, int> hashmap = new Dictionary<string, int>();

            //Node root = new Node(1);
            //root.Left = new Node(2);
            //root.Right = new Node(3);
            //root.Left.Left = new Node(4);
            //root.Left.Right = new Node(5);
            //root.Right.Right = new Node(2);
            //root.Right.Right.Right = new Node(5);
            //root.Right.Right.Left = new Node(4);
            // var finalResult = google.CheckIfTreeHas2IdenticalSubtree(root, hashmap);
            // var ValWithMaxCount = hashmap.Aggregate((l, r) => l.Value > r.Value ? l : r).Value; //Aggregate function is like Javascript Reduce function
            //if (ValWithMaxCount > 1)
            //{
            //    Console.WriteLine(true);
            //}
            //else
            //{
            //    Console.WriteLine(false);
            //}




            //Alternate for above Aggregate function, iterating dicitonary
            //var maxItem = hashmap.First();  //Notice hashmap[0] will not work in Dictionary
            //foreach (var item in hashmap)
            //{
            //    if (item.Value > maxItem.Value)
            //    {
            //        maxItem = item;
            //    }
            //}
            //Console.Write(maxItem.Value);





            //Q6: Find largest word in dictionary by deleting some characters of given string
            // https://www.geeksforgeeks.org/find-largest-word-dictionary-deleting-characters-given-string/
            //var finalResult = google.IfWordCanBeFormed("apple", "abpcplea");
            //Console.WriteLine(finalResult);







            // -----FACEBOOK ------


            //Q7:  Subarray with given sum
            //  https://www.geeksforgeeks.org/find-subarray-with-given-sum/
            int[] arr = { 1, 2, 3, 7, 5 };
            // facebook.SubArrayWithGivenSum(arr, 12);



            //Q8: Find all pairs in 2 arrays with a given sum
            // https://www.geeksforgeeks.org/given-two-unsorted-arrays-find-pairs-whose-sum-x/
            int[] arr1 = { -1, -2, 4, -6, 5, 7 };
            int[] arr2 = { 6, 3, 4, 0 };
            var sum = 8;
            // facebook.FindAllPairsWithSumInArrays(arr1, arr2, sum);


            //Q9: Total Decoding Messages

            //https://practice.geeksforgeeks.org/problems/total-decoding-messages1235/1
            //https://www.geeksforgeeks.org/count-possible-decodings-given-digit-sequence/
            //Soluton   - Full explnantion : https://www.youtube.com/watch?v=jFZmBQ569So
            var str = "21123";    // where 1 is 'A',      2 is 'B',    12 is 'L',     3 is 'C'
            //var resultCount = facebook.FindDecodingSets(str, 0);
            //Console.WriteLine(resultCount);





            //Q10: Word Boggle
            //https://www.geeksforgeeks.org/boggle-find-possible-words-board-characters/

            var Dictionary = "GEEKS";
            char[,] Board = new char[3, 3]
                       {{'G', 'I', 'Z'},
                       {'U', 'E', 'K'},
                       {'Q', 'S', 'E'}};

            //TO DO- NOT COMPLETE
            // facebook.FindWordUtil(Dictionary, Board);


            //Q11: Activity Selection
            // https://www.geeksforgeeks.org/activity-selection-problem-greedy-algo-1/

            int[] start = { 1, 8, 5, 0, 3, 5 };
            int[] finish = { 2, 9, 7, 6, 4, 9 };
            int n = start.Length;

            //facebook.printMaxActivities(start, finish, n);






            //Q12: Find Minimum Depth of a Binary Tree
            // https://www.geeksforgeeks.org/find-minimum-depth-of-a-binary-tree/

            Node root = new Node(1);
            root.Left = new Node(2);
            root.Right = new Node(3);
            root.Right.Right = new Node(14);
            root.Left.Left = new Node(4);
            root.Left.Right = new Node(5);
            root.Left.Left.Left = new Node(7);
            //Min  depth of this tree will be 2, this function can exactly be used to find actual depth of the tree by chnaging Math.min() to Math.max()
            var height = facebook.getMinDepthOfTree(root);
            Console.WriteLine(height);

            Console.ReadKey();
        }
    }
}
