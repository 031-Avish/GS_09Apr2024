namespace MinimumDepthTree
{
    internal class MinimumDepthTree
    {
        static async Task Main(string[] args)
        {
            List<int> inputArray = await TakeInput();
            TreeNode root = await MakeTree(inputArray);
            int result = int.MaxValue;
            Inorder(root, ref result, 1);
            Console.WriteLine("The Final answer is " + result);

        }

        // recursively getting the answer 
        private static void Inorder(TreeNode root, ref int result, int count)
        {
            if (root == null)
            {
                return;
            }
            if (root.left == null && root.right == null)
            {
                // geting the minimum length path 
                result = Math.Min(result, count);
                return;
            }

            Inorder(root.left, ref result, count + 1);
            Inorder(root.right, ref result, count + 1);
        }

        // code to create the tree 
        private static async Task<TreeNode> MakeTree(List<int> inputArray)
        {
            if (inputArray.Count == 0 || inputArray[0] == -1)
            {
                return null;
            }
            TreeNode root = new TreeNode(inputArray[0]);

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int i = 1;
            while (queue.Count > 0 && i < inputArray.Count)
            {
                TreeNode node = queue.Dequeue();
                if (i < inputArray.Count && inputArray[i] != -1)
                {
                    node.left = new TreeNode(inputArray[i]);
                    queue.Enqueue(node.left);
                }
                i++;
                if (i < inputArray.Count && inputArray[i] != -1)
                {
                    node.right = new TreeNode(inputArray[i]);
                    queue.Enqueue(node.right);
                }
                i++;
            }
            return root;
        }

        // to take user input 
        private static async Task<List<int>> TakeInput()
        {
            List<int> userArray = new List<int>();
            Console.WriteLine("Enter the size of array");
            int size;
            while (!int.TryParse(Console.ReadLine(), out size))
            {
                Console.WriteLine("enter interger only");
            }
            Console.WriteLine("Enter the values");
            // -1 for null
            for (int i = 0; i < size; i++)
            {
                int input;
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("enter interger only");
                }
                userArray.Add(input);
            }
            return userArray;
        }

    }
}
