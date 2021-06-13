using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_CodeSnippets_CSharp
{
    class TreeHelper
    {
    }

    //Node Class
    public class Node
    {

        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int dataValue)
        {
            Data = dataValue;
            Left = Right = null;
        }
    }

    //BinaryTree Class
    public class BinaryTree
    {
        Node root;

        public BinaryTree(int dataValue)
        {
            root = new Node(dataValue);
        }
        public BinaryTree()
        {
            root = null;
        }

        public BinaryTree getBinaryTree()
        {
            var binaryTree = new BinaryTree();
            binaryTree.root = new Node(1);


            binaryTree.root.Left = new Node(2);
            binaryTree.root.Right = new Node(3);
            binaryTree.root.Left.Left = new Node(4);
            binaryTree.root.Left.Right = new Node(5);
            return binaryTree;
        }

        public Node BinaryTreeInsert(Node root, int data)
        {
            if (root == null)
            {
                root = new Node(data);
                return root;
            }
            if (data < root.Data)
            {
                root.Left = BinaryTreeInsert(root.Left, data);
            }
            else
            {
                root.Right = BinaryTreeInsert(root.Right, data);
            }
            return root;
        }

        public Node BinaryTreeDelete(Node root, int data)
        {
            if (root == null)
            {
                return root;
            }
            if (data < root.Data)
            {
                root.Left = BinaryTreeDelete(root.Left, data);
            }
            else if (data > root.Data)
            {
                root.Right = BinaryTreeDelete(root.Right, data);
            }
            //this is the case when datakey is same as Root's data
            else
            {
                if (root.Left == null && root.Right == null)
                {
                    root = null;
                }
                else if (root.Left == null)
                {
                    root = root.Right;
                }
                else if (root.Right == null)
                {
                    root = root.Left;
                }
                else
                {
                    //If both child are present than find the left most child of the right successor
                    var rightChild = root.Right;

                    //reaching the left most child
                    while (rightChild.Left != null)
                    {
                        rightChild = rightChild.Left;
                    }
                    root.Data = rightChild.Data;  //assign right successor's left most child's value to  root
                    BinaryTreeDelete(root.Right, rightChild.Data);// Now calling same function for deleting the identified node
                }
            }
            return root;
        }



    }

}
