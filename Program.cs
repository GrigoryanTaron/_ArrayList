using System;
using System.Collections;
using System.Collections.Generic;

namespace _ArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _ArrayList list = new _ArrayList(15);
            list.Add("Hello");
            list.Add(59);
            list.Add('Q');
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            list.Reverse(0, 2);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            list[0] = "Hi";
            list[1] = 77;
            list[2] = "W";
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            list.Clear();
            list.Add("-_-");
            list.Add(717);
            list.Add("Q_Q");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            list.Insert(2, 1254);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            list.Reverse(0,2);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            string[] test = new string[] { ">_<", "O_O" };

            list.InsertRange(4, test); //dont work
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            list.AddRange(new int[] { 1, 3 }); //dont work
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            list.RemoveAt(0);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            //Array array = new Array(); //TODO
            //list.CopyTo(0, array, 1, 2);

            _ArrayList list1 = new _ArrayList(new List<string>(10));
            list1.Add("Hello");
            list1.Add("World");
            _ArrayList list2 = new _ArrayList();
         
            ArrayList list3 = new ArrayList();
            list3.Add("Hello");
            list3.InsertRange(1, test);
            foreach(var item in list3)
            {
                Console.WriteLine(item);
            }

        }
    }

}
