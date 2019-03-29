using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomListProgram
    {
        static void Main(string[] args)
        {
            //var intList = new CustomList<int>() { 2, 12, 6, 9, 88, 68, 66 };

            //intList.Add(-12);
            //intList.Add(-6);

            //intList.PrintList();

            //var sum = intList.Sum();
            //Console.WriteLine(sum);

            var list = new List<string>
            {
                "summer",
                "dog",
                "cat",
                "winter",
                "words"
            };

            var stringList = new CustomList<string>()
            {
                "summer",
                "dog",
                "cat",
                "winter",
                "words"
            };

            var newList = list.Select(x => x.ToUpper());

            foreach (var item in newList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine();

            var newStringList = stringList.Select(x => x.ToUpper());

            foreach (var item in newStringList)
            {
                Console.WriteLine(item);
            }
            //    var newList = list.GroupBy(x => x.Length).ToDictionary(x => x.Key, x => x.ToList());

            //    foreach (var item in newList)
            //    {
            //        Console.WriteLine($"Words with {item.Key} letters:");

            //        foreach (var word in item.Value)
            //        {
            //            Console.WriteLine($"- {word}");
            //        }
            //    }

            //    Console.WriteLine();
            //    Console.WriteLine();

            //    var newString = stringList.GroupBy(x => x.Length).ToDictionary(x => x.Key, x => x.ToList());

            //    foreach (var item in newString)
            //    {
            //        Console.WriteLine($"Words with {item.Key} letters:");

            //        foreach (var word in item.Value)
            //        {
            //            Console.WriteLine($"- {word}");
            //        }
            //    }


        }
    }
}
