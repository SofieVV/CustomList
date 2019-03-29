using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public static class Extensions
    {
        public static void PrintList<T>(this CustomList<T> intList)
        {
            foreach (var number in intList)
            {
                Console.WriteLine(number);
            }
        }

        public static int Sum(this CustomList<int> intList)
        {
            var sum = 0;

            foreach (var number in intList)
            {
                sum += number;
            }

            return sum;
        }

        public static void LastElements(this CustomList<string> stingList, int amount)
        {
            string lastElements;

            foreach (var item in stingList)
            {
                if (item.Length <= amount)
                {
                    lastElements = item;
                }
                else
                {
                    lastElements = item.Substring(item.Length - amount, amount);
                }

                Console.WriteLine(lastElements);
            }
        }

        public static bool CheckIfEven(this int number)
        {
            if (number % 2 == 0)
            {
                return true;
            }

            return false;
        }

        public static bool CheckIfAllListElementsAreEven(this CustomList<int> list)
        {
            foreach (var item in list)
            {
                if (!item.CheckIfEven())
                {
                    return false;
                }
            }

            return true;
        }

        public static bool All<T>(this CustomList<T> list, Func<T, bool> predicate)
        {
            foreach (var item in list)
            {
                if (!predicate(item))
                    return false;
            }

            return true;
        }
        
        public static bool Any<T>(this CustomList<T> list, Func<T, bool> predicate)
        {
            foreach (var item in list)
            {
                if (predicate(item))
                    return true;
            }

            return false;
        }

        public static T FirsOrDefaut<T>(this CustomList<T> list, Func<T, bool> predicate)
        {
            foreach (var item in list)
            {
                if (predicate(item))
                    return item;
            }

            return default(T);
        }

        public static IEnumerable<T> Where<T>(this CustomList<T> list, Func<T, bool> predicate)
        {
            var newList = new CustomList<T>();

            foreach (var item in list)
            {
                if (predicate(item))
                    newList.Add(item);
            }

            return newList;
        }

        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey> (this CustomList<TSource> list, Func<TSource, TKey> keySelector)
        {
            var result = new Dictionary<TKey, List<TSource>>();

            foreach (var item in list)
            {
                var key = keySelector(item);

                if (result.ContainsKey(key))
                    result[key].Add(item);
                else
                    result.Add(key, new List<TSource> { item });
            }
            
            foreach (var item in result)
            {
                yield return new Grouping<TKey, TSource>() { Key = item.Key, Values = item.Value };
            }
        }

        public static IEnumerable<TResult> Select<TSource, TResult> (this CustomList<TSource> list, Func<TSource, TResult> selector)
        {
            foreach (var item in list)
                yield return selector(item);
        }
    }
}
