using System;

namespace CountCompleteTreeNodes
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
        static int count = 0;
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1, null, null);
            root.left = new TreeNode(2, null, null);
            root.right = new TreeNode(3, null, null);

            root.left.left = new TreeNode(4, null, null); ;
            root.left.left = new TreeNode(5, null, null); ;

            root.right.left = new TreeNode(6, null, null);
            root.right.right = null;
            Console.WriteLine(CountNodes(root));
        }
        public static int CountNodes(TreeNode root)
        {
            int depth = ComputeDepth(root);
            Console.WriteLine(depth);
            return 0;
        }
        public static int ComputeDepth(TreeNode root)
        {
            int depth = 0;
            while (root.left != null)
            {
                root = root.left;
                ++depth;
            }
            return depth;
        }
    }
}
