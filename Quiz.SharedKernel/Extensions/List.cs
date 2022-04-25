//
// Copyright © 2020 Terry Moreland
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
// to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
// and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, 
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 

using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiz.SharedKernel.Extensions
{
    public static class List
    {
        public static List<TSource> Empty<TSource>() => new List<TSource>();
        public static List<TSource> Of<TSource>(params TSource[] items) => new List<TSource>(items);
        public static List<TSource> Of<TSource>(IEnumerable<TSource> collectionOfItems, params TSource[] items)
        {
            collectionOfItems ??= Array.Empty<TSource>().AsEnumerable();
            var list = new List<TSource>(collectionOfItems);
            list.AddRange(items);
            return list;
        }

        public static IList<TSource> AddRange<TSource>(this IList<TSource> list, IEnumerable<TSource> items)
        {
            if (list == null)
                return new List<TSource>(items ?? Array.Empty<TSource>());

            if (items?.Any() != true)
                return list;
            foreach (var item in items)
                list.Add(item);
            return list;
        }
    }
}
