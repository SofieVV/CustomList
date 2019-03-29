using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    class Grouping<TKey, TSource> : IGrouping<TKey, TSource>
    {
        public TKey Key { get; set; }
        public IEnumerable<TSource> Values;

        public IEnumerator<TSource> GetEnumerator()
        {
            return Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
