﻿using System;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList a = new ArrayList(new int[] { 1, 2, 3, 4, 5 });
            a.RemoveByIndex(3);
            a.Add(6);
            a.AddToBeginning(99);
            a.Remove();
            a.AddByIndex(88, 2);
            a.Add(77);
            ArrayList b = new ArrayList(new int[] { 11, 22, 33, 44, 55 });
            a.AddArrayListToTheBegining(b);
            a.Add(3333);
            a.AddArrayListToTheEnd(b);
            a.Add(676);
            ArrayList c = new ArrayList(new int[] { 0, 5, 0, 4, 0 });
            a.AddArrayListByIndex(c, 3);
            a.RemoveAllByValue(0);
            a.RemoveFirstByValue(3);
            a.RemoveElementsByIndex(2, 3);
            a.SortDown();
            //Console.WriteLine(a.RemoveAllByValue(111110));
            a.RemoveElementsByIndex(2, 1);
            a.RemoveElements(2);
            //a.RemoveFirstN(2);
            //a.Reverse();
            a.RemoveAllByValue(33);
            Console.WriteLine(a);

            LinkedList linkedList = new LinkedList(new int[] { 1, 2, 3, 4, 5 });
            linkedList.Add(77);
            Console.WriteLine(linkedList[2]);
            linkedList[4] = 6;
            Console.WriteLine(linkedList[4]);
            linkedList.AddToBeginning(100);
            linkedList.AddByIndex(10, 3);
            Console.WriteLine(linkedList);
            LinkedList linkedList2 = new LinkedList(new int[] { 1, 2, 3, 4, 5 });
            //linkedList.AddLinkedListAtTheEnd(linkedList2);
            linkedList.AddLinkedListToTheBegining(linkedList2);
            Console.WriteLine(linkedList);
            linkedList.Remove();
            Console.WriteLine(linkedList);
            linkedList.Add(13);
            Console.WriteLine(linkedList[12]);
            linkedList2[2] = 555;
            Console.WriteLine(linkedList);
            //Console.WriteLine(linkedList2.Equals(linkedList));
        }
    }
}
