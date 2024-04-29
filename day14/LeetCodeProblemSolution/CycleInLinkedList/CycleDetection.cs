


namespace CycleInLinkedList
{
    internal class CycleDetection
    {
        static async Task Main(string[] args)
        {
            ListNode head = TakeInput().Result;
            if(head == null ) { Console.WriteLine("No cycle"); }

            int CycleIndex = TakeCycleIndex().Result;
            AddCycle(head,CycleIndex);

            bool isCycle= DetectCycle(head).Result;

            if( isCycle )
            {
                Console.WriteLine("Yes the Link List has cycle ");
            }
            else
            {
                Console.WriteLine("No there is no cycle in it");
            }
        }

        // to detect if cycle is present of not 
        private static async Task<bool> DetectCycle(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return false; 
            }
            ListNode slow = head;
            ListNode fast = head.next;
            while (fast != null && fast.next != null)
            {
                if (slow == fast)
                {
                    return true; 
                }
                slow = slow.next;
                fast = fast.next.next;
            }
            return false;
        }

        // to take the index where user want to add cycle 
        private static async Task<int> TakeCycleIndex()
        {
            Console.WriteLine("Enter the index of cycle (zero based)");
            Console.WriteLine("if more then the length of list then no cycle");
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Enter integer only");
            }
            return input;
        }


        // make the list by taking input
        private static async Task<ListNode> TakeInput()
        {
            ListNode head = null;
            Console.WriteLine("Enter Number of Node");
            int nodeCount;
            while (!int.TryParse(Console.ReadLine(), out nodeCount))
            {
                Console.WriteLine("Enter integer only");
            }
            
            Console.WriteLine("Enter values ");
            for (int i = 0; i < nodeCount; i++)
            {
                int input;
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Enter integer only");
                }
                head = AddNode(head, input).Result;
            }
            return head;

        }


        // add node to the linklist
        private static async Task<ListNode> AddNode(ListNode head,int value)
        {
            ListNode newNode = new ListNode(value);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                ListNode current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = newNode;
            }
            return head;
        }

        // create a cycle in linklist based on index 
        private static async Task AddCycle(ListNode head, int index)
        {
            if (index < 0)
            {
                return;
            }

            ListNode tail = head;
            // go to tail
            int nodeCount = 0;
            while (tail != null && tail.next != null)
            {
                nodeCount++;
                tail = tail.next;
            }
            nodeCount++;
            if (index >= nodeCount) return; 

            ListNode cycleStart = head;
            for (int i = 0; i < index; i++)
            {
                cycleStart = cycleStart.next;
            }
            tail.next = cycleStart;
        }
    }
}
