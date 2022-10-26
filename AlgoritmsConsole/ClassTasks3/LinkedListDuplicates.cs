using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.ClassTasks3
{
    partial class LinkedListDuplicates
    {
        public ListNode Set()
        {
            var el1 = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                        }
                    }
                }
            };


            while (el1 != null)
            {
                Console.Write(el1.val + "->");
                el1 = el1.next;
            }

            return el1;
        }
        public ListNode deleteDuplicates(ListNode A)
        {
            ListNode first = null;
            ListNode current = null;
            var count = 0;

            while (A != null)
            {
                var next = A.next;
                if (next == null || next.val != A.val)
                {
                    if (count == 0)
                    {
                        if (first == null)
                        {
                            current = new ListNode(A.val);
                            first = current;
                        }
                        else
                        {
                            current.next = new ListNode(A.val);
                            current = current.next;
                        }
                    }
                    count = 0;
                }
                else
                {
                    count++;
                }
                A = A.next;
            }

            return first;
        }

        public ListNode swapPairs1(ListNode A)
        {
            ListNode start = null;
            ListNode first = A;
            ListNode second = A.next;
            ListNode prev = null;

            if (A.next == null)
            {
                return A;
            }

            while (A != null)
            {
                first = A;
                second = A.next;

                if (start == null)
                {
                    if (second == null)
                    {
                        start = first;
                    }
                    else
                    {
                        start = second;
                        prev = first;
                    }
                }

                if (second == null)
                {
                    A = null;
                }
                else
                {
                    if (prev != null)
                    {
                        prev.next = second;
                    }

                    var third = second.next;
                    second.next = first;
                    first.next = third;
                    A = third;
                    prev = first;

                }
            }

            return start;
        }

        public ListNode swapPairs(ListNode A)
        {
            var fakeNode = new ListNode(-1) { next = A };
            var isSwapped = false;
            var curr = A;
            var prev = fakeNode;

            while (curr.next != null)
            {
                if (!isSwapped)
                {
                    var tmp = curr.next.next;
                    var nxt = curr.next;
                    var crnt = curr;
                    curr = nxt;
                    curr.next = crnt;
                    curr.next.next = tmp;
                    prev.next = curr;
                    isSwapped = true;
                }
                else
                {
                    isSwapped = false;
                }

                prev = curr;
                curr = curr.next;
            }

            return fakeNode.next;
        }

        public ListNode reverseBetween(ListNode A, int B, int C)
        {
            if (B == C)
            {
                return A;
            }
            var fakeHead = new ListNode(-1);
            var fakeSegmentHead = new ListNode(-1);
            var counter = 1;

            ListNode prev = null;
            ListNode tail = null;
            ListNode curr = null;
            ListNode succ = null;

            if (B == 1)
            {
                fakeSegmentHead.next = A;
                curr = fakeSegmentHead.next;
                succ = fakeSegmentHead.next.next;
            }
            else
            {
                fakeHead.next = A;
                
                fakeSegmentHead.next = A;
                while (counter < B - 1)
                {
                    counter++;
                    fakeSegmentHead.next = fakeSegmentHead.next.next;
                }

                curr = fakeSegmentHead.next.next;
                succ = fakeSegmentHead.next.next.next;
                counter++;
            }

            while (curr != null && counter <= C)
            {
                curr.next = prev;
                if (tail == null)
                {
                    tail = curr;
                }
                prev = curr;
                curr = succ;
                succ = succ != null ? succ.next : null;
                counter++;
            }

            if (B == 1)
            {
                fakeSegmentHead.next = prev;
            }
            else
            {
                fakeSegmentHead.next.next = prev;
            }
            tail.next = curr;

            if (fakeHead.next == null)
            {
                return fakeSegmentHead.next;
            }

            return fakeHead.next;
        }
    }
}
