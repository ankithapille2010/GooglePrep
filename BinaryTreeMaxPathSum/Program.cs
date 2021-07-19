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
        static int max_sum = Int32.MinValue;
        static void Main(string[] args)
        {
            int?[] inputs = new int? []{-10, 9, 20, null, null, 15, 7 };
            TreeNode root = new TreeNode(-10,null,null);
            root.left = new TreeNode(9,null,null);
            root.right = new TreeNode(20, null, null);

            root.left.left = null;
            root.left.left = null;

            root.right.left = new TreeNode(15,null,null);
            root.right.right = new TreeNode(7, null, null);
            Console.WriteLine(MaxPathSum(root));
            
        }

        public static int MaxPathSum(TreeNode root)
        {
            maxGain(root);
            return max_sum;
        }

        private static int maxGain(TreeNode root)
        {
            if (root == null)
                return 0;
            int left_gain = Math.Max(maxGain(root.left), 0);
            int right_gain = Math.Max(maxGain(root.right), 0);
            int path_val = (int)root.val + left_gain + right_gain;

            max_sum = Math.Max(path_val,max_sum);

            return (int)root.val + Math.Max(left_gain, right_gain);
        }
    }
}
