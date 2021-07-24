using System;

namespace DiameterBinaryTree
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
        public static int diameter = 0;
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1, null, null);
            root.left = new TreeNode(2, null, null);
            root.right = new TreeNode(3, null, null);

            root.left.left = new TreeNode(4, null, null); ;
            root.left.right = new TreeNode(5, null, null); ;

            root.right.left = new TreeNode(6, null, null);
            
            Console.WriteLine(DiameterOfBinaryTree(root));
        }
        public static int DiameterOfBinaryTree(TreeNode root)
        {
            LongestPath(root);
            return diameter;
          
        } 

        private static int LongestPath(TreeNode root)
        {
            if (root == null)
                return 0;
            int leftPath = LongestPath(root.left);
            int righPath = LongestPath(root.right);
            diameter = Math.Max(diameter, leftPath + righPath);

            return Math.Max(leftPath,righPath)+1;
        }
    }
}
