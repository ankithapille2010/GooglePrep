using System;

namespace BinaryTreeMaxPathSum
{
    public class TreeNode
    {
       public int? val;
       public TreeNode left;
       public TreeNode right;
       public TreeNode(int? val = 0, TreeNode left = null, TreeNode right = null)
       {
            this.val = val;
            this.left = left;
            this.right = right;
       }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int?[] inputs = new int? []{-10, 9, 20, null, null, 15, 7 };

            TreeNode root = new TreeNode(-10, null, null);
            root.left = new TreeNode(9,null,null);
            root.right = new TreeNode(20, null, null);
            TreeNode currNode = root;
            int i = 1;

            while (i < inputs.Length)
            {
                Console.WriteLine(currNode.val);
                currNode.left = new TreeNode(inputs[i]);
                i++;
                currNode.right = new TreeNode(inputs[i]);
                i++;

                if (currNode.left == null)
                    currNode = currNode.left;
                else
                    currNode = currNode.right;
            }
         }

        private static void ParseBinaryTree(TreeNode root)
        {
            while (root != null)
            {
                Console.WriteLine();
            }

        }

        private static TreeNode InsertIntoBinaryTree(int?[] inputs)
        {
            TreeNode root = new TreeNode(inputs[0],null,null);
            TreeNode currNode = root;
            for(int i =1;i< inputs.Length-2; i++)
            {
               // Console.WriteLine()
                currNode.left = new TreeNode(inputs[i], null, null);
                currNode.right = new TreeNode(inputs[i + 1], null, null);
                currNode = currNode.left!=null?currNode.left:currNode.right;
            }
            return root;
        }
    }
}
