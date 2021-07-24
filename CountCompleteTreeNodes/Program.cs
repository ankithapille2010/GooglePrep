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
            root.left.right = new TreeNode(5, null, null); ;

            root.right.left = new TreeNode(6, null, null);
            //root.right.right = null;
            Console.WriteLine(CountNodes(root));
        }

        public static int CountNodes(TreeNode root)
        {
            if (root == null)
                return 0;
            int leftH = GetLeftHeight(root);
            int rightH = GetRightHeight(root);
       
            if (leftH > rightH)
                return 1 + CountNodes(root.left) + CountNodes(root.right);
            
            else
                return (int)(Math.Pow(2, leftH)) - 1;

        }

        public static int GetLeftHeight(TreeNode root)
        {
           
            if (root == null)
                return 0;

            return 1 + GetLeftHeight(root.left);
        }
        public static int GetRightHeight(TreeNode root)
        {
            if (root == null)
                return 0;

            return 1 + GetRightHeight(root.right);
        }




    }
}
