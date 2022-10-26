using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmsConsole.ClassTasks3
{
    class CycleFound
    {
        public ListNode FindCycleStart(ListNode A)
        {
            ListNode turtle = A;
            ListNode rabbit = A.next;

            do
            {
                turtle = turtle.next;
                rabbit = rabbit.next.next;
            }
            while (turtle != rabbit);

            ListNode fakeHead = new ListNode(-1);
            fakeHead.next = A;
            rabbit = rabbit.next;

            while (fakeHead.next != rabbit)
            {
                fakeHead.next = fakeHead.next.next;
                rabbit = rabbit.next;
            }

            return fakeHead.next;
        }
    }
}
