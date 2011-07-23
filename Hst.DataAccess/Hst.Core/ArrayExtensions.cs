using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hst.Core
{
    /// <summary>
    /// Basic array extensions.
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Determines whether [is null or empty] [the specified items].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <returns>
        /// 	<c>true</c> if [is null or empty] [the specified items]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNullOrEmpty<T>(this T[] items)
        {
            return items == null || items.Length < 1;
        }
    }
}
