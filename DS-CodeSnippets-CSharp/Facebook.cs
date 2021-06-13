using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_CodeSnippets_CSharp
{
    class Facebook
    {

        //Q7: Subarray with given sum
        public void SubArrayWithGivenSum(int[] arr, int sum)
        {
            var tempSum = 0;
            var startPointer = 0;
            for (int i = 0; i < arr.Length; i++)
            {


                if (tempSum == sum)
                {
                    Console.WriteLine("{0} ,  {1}", startPointer, i - 1);
                    break;
                }
                tempSum += arr[i];

                // if total has gone beyond destred sum, start subtracting the elements from left
                while (tempSum > sum)
                {
                    tempSum -= arr[startPointer];
                    startPointer++;
                }
            }

            if (tempSum != sum)
            {
                Console.WriteLine("Value not found");
            }
        }


        //Q8: Find all pairs in 2 arrays with a given sum
        public void FindAllPairsWithSumInArrays(int[] arr1, int[] arr2, int sum)
        {
            var hashMap = new Dictionary<int, int>();

            //Store first array in Hashmap
            for (int i = 0; i < arr1.Length; i++)
            {
                hashMap.Add(arr1[i], 1);
            }

            //Loop second array
            for (int i = 0; i < arr2.Length; i++)
            {
                var NumbertoFind = sum - arr2[i]; // Find the differne in previously creasted hashmap
                if (hashMap.ContainsKey(NumbertoFind))
                {
                    Console.WriteLine("{0} {1}", arr2[i], NumbertoFind);
                }
            }

        }



        //Q9: Total Decoding Messages
        //Full explnantion : https://www.youtube.com/watch?v=jFZmBQ569So
        public int FindDecodingSets(string str, int count)
        {
            int[] dp = new int[str.Length];
            dp[0] = 1;  //till we have 1 charcter answer will be 1 only.

            // 0..1..2..3....... [i-2]  [i-1] [i]    Consider this while understanding below loop

            for (int i = 1; i < str.Length; i++)
            {
                //in below conditions we will only consider last 2 digits becuase maximum number we ware looking for is 26
                if (str[i - 1] == '0' && str[i] == '0')   // 'i-2' will be second last element of the string, 'i-1' is the last element of string
                {
                    //this condition means '00' are there at the end of the string
                    dp[i] = 0;
                }
                else if (str[i - 1] == '0' && str[i] != '0')
                {
                    dp[i] = dp[i - 1];
                }
                else if (str[i - 1] != '0' && str[i] == '0')
                {
                    if (str[i - 1] == '1' || str[i] == '2')
                    {
                        //Ideally the line below was dp[i]= dp[i-2], but since i-2 will fail when i=1 in the loop, hence we changed it to below
                        // E.g. i=1 for number 21
                        dp[i] = i > 1 ? dp[i - 2] : 1;
                    }
                    else
                    {
                        dp[i] = 0;
                    }

                }
                else
                {
                    var p = str.Substring(i - 1, 2);
                    if (Convert.ToInt32(str.Substring(i - 1, 2)) < 26)
                    {
                        //replaced dp[i-2] is replaced with (i > 1 ? dp[i - 2] : 1)  as done above too
                        //dp[i]= dp[i-1] + dp[i-2];
                        dp[i] = dp[i - 1] + (i > 1 ? dp[i - 2] : 1);
                    }
                    else
                    {
                        dp[i] = dp[i - 1];
                    }
                }


            }


            return dp[str.Length - 1];

        }




        //Q10: Word Boggle

        public void FindWordUtil(string Dictionary, char[,] Board)
        {
            var pointer = 0;
            while (pointer < Dictionary.Length - 1)
            {
                var wordFound = false;
                //Notice GetLength (0) and GetLength(1) to get number of rows and columns dynamically without hardcoding
                for (int i = 0; i < Board.GetLength(0); i++)
                {
                    for (int j = 0; j < Board.GetLength(1); j++)
                    {
                        Console.WriteLine(Dictionary[pointer]);
                        if (Dictionary[pointer] == Board[i, j])
                        {
                            wordFound = true;
                            pointer++;
                        }
                        // Console.Write("{0} ", Board[i, j]);
                    }
                    //Console.WriteLine("\n");
                }
                if (wordFound == false)
                {
                    Console.WriteLine("Word Not found");
                    return;
                }

            }
            if (pointer == Dictionary.Length)
            {
                Console.Write("Word Found");
            }

        }


        //Q11: Activity Selection
        //Example for Greedy Alogorithm
        public void printMaxActivities(int[] start, int[] finish, int n)
        {

            //using  Bubble Sort
            SortActivitiesBasedonFinishTime2(start, finish);

            //Using  Insertion Sort
            //SortActivitiesBasedonFinishTime2(start, finish);

            int k = 0;
            Console.WriteLine("Activity {0}", start[k]); // First activity will always be in the result

            for (int i = 0; i < n; i++)
            {
                if (finish[k] < start[i])
                {
                    Console.WriteLine("Activity {0}", start[i]);
                    k = i;
                }
            }


        }

        //Sorting for Q11 using BUBBLE Sort, Activity Selection
        public void SortActivitiesBasedonFinishTime(int[] start, int[] finish)
        {

            //Using normal Bubble sort
            for (int i = 0; i < start.Length - 1; i++)
            {
                for (int j = 0; j < start.Length - i - 1; j++)
                {
                    if (finish[j] > finish[j + 1])  // Notice we are comparing j with j+1
                    {
                        int temp = finish[j];
                        finish[j] = finish[j + 1];
                        finish[j + 1] = temp;

                        temp = start[j];
                        start[j] = start[j + 1];
                        start[j + 1] = temp;
                    }
                }
            }
        }
        //Sorting for Q11 using INSERTION Sort, Activity Selection
        public void SortActivitiesBasedonFinishTime2(int[] start, int[] finish)
        {

            //Using normal INSERTION sort
            for (int i = 1; i < finish.Length - 1; i++)
            {
                var pointer = i;
                var element = finish[i];
                while (element < finish[pointer - 1] && pointer >= 0)
                {
                    finish[pointer] = finish[pointer - 1];
                    //Updating Start array too
                    start[pointer] = start[pointer - 1];
                    pointer--;
                }

                finish[pointer] = element;
                //Updating Start pointer too
                start[pointer] = element;

            }
        }




        //Q12: Find Minimum Depth of a Binary Tree
        // this function can exactly be used to find actual depth of the tree  as well just by chnaging Math.min() to Math.max() n the last  line
        //In this approach we handle all possible 4 cases 
        //case 1. When node is null, when a root node passed is null
        //case 2. When node is leaf i..e left and right child are null
        //case 3. When we have left child only, or right only only
        //case 4.  Whn both left and right child are present
        public int getMinDepthOfTree(Node root)
        {
            // Corner case. Would never be hit unless the code is called on root = NULL
            if (root == null)
            {
                return 0;
            }

            // Base case : When node is Leaf Node. This accounts for height = 1.
            if (root.Left == null && root.Right == null)
            {
                return 1;
            }

            // Case If left subtree is NULL, recur for right subtree
            if (root.Left == null)
            {
                return getMinDepthOfTree(root.Right) + 1;

            }
            // Case If right subtree is NULL, recur for left subtree
            if (root.Right == null)
            {
                return getMinDepthOfTree(root.Left) + 1;

            }

            // Case when both left and right are present
            return Math.Max(getMinDepthOfTree(root.Left), getMinDepthOfTree(root.Right)) + 1;
        }
    }
}
