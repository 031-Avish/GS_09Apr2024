using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleInLinkedList
{
    public class ListNode
    {
        public int val { get; set; }
        public ListNode next { get; set; }

        public ListNode(int x ) {
            val = x;
            next = null;
        }
    }
}
