/* License: GLPLV3 - See License.txt */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSystems.Tools
{
    /// <summary>
    /// Array extensions
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// remove an item at specific index from array
        /// </summary>
        /// <typeparam name="T">array class type</typeparam>
        /// <param name="source">array to remove item from</param>
        /// <param name="index">index to remove at</param>
        /// <returns>new array with item removed</returns>
        public static T[] RemoveAt<T>(this T[] source, int index)
        {
            T[] dest = new T[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }

        /// <summary>
        /// Remove all specific constants from an array
        /// </summary>
        /// <param name="source">array to remove from</param>
        /// <param name="val">value to remove</param>
        /// <returns>new array with removed items</returns>
        public static T[] RemoveAll<T>(this T[] source, T val)
        {
            T[] dest = new T[source.Length];

            int i = 0;
            foreach (T e in source)
            {
                if (!EqualityComparer<T>.Default.Equals(e, val))
                {
                    dest[i] = e;
                    i++;
                }
            }
            Array.Resize(ref dest, i);

            return dest;
        }

        /// <summary>
        /// Append a item at the end of the array
        /// </summary>
        /// <param name="source">array class instance</param>
        /// <param name="val">value to append at the end</param>
        /// <returns>array</returns>
        public static T[] Append<T>(this T[] source, T val)
        {
            int index = source.Length;
            Array.Resize<T>(ref source, index + 1);
            source[index] = val;

            return source;
        }

        /// <summary>
        /// Insert item at a specific point in an array.
        /// Please note that a lot of copying goes on with this method.
        /// Thus it is not very efficient to insert into an array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">array ref</param>
        /// <param name="Val">Value to insert</param>
        /// <param name="idx">index where the value is to be inserted</param>
        /// <returns>a copy of a new array</returns>
        public static T[] InsertAt<T>(this T[] source, T Val, int idx)
        {
            int i;

            Array.Resize<T>(ref source, source.Length + 1);

            for (i = idx + 1; i < source.Count(); i++)
            {
                source[i] = source[i - 1];
            }

            source[idx] = Val;

            return source;

        }

        /// <summary>
        /// extension method to resize 2 multi dimensional array
        /// </summary>
        /// <param name="arr">array to resize</param>
        /// <param name="newSizes">array of new sizes for the array to be resized</param>
        /// <returns>New resized array</returns>
        public static Array ResizeArray(this Array arr, int[] newSizes)
        {
            if (newSizes.Length != arr.Rank)
            {
                throw new ArgumentException("arr must have the same number of dimensions as there are elements in newSizes", "newSizes");
            }

            var temp = Array.CreateInstance(arr.GetType().GetElementType(), newSizes);
            var sizesToCopy = new int[newSizes.Length];
            for (var i = 0; i < sizesToCopy.Length; i++)
            {
                sizesToCopy[i] = System.Math.Min(newSizes[i], arr.GetLength(i));
            }

            var currentPositions = new int[sizesToCopy.Length];
            CopyArray(arr, temp, sizesToCopy, currentPositions, 0);

            return temp;
        }

        private static void CopyArray(Array arr, Array temp, int[] sizesToCopy, int[] currentPositions, int dimmension)
        {
            if (arr.Rank - 1 == dimmension)
            {
                //Copy this Array
                for (var i = 0; i < sizesToCopy[dimmension]; i++)
                {
                    currentPositions[dimmension] = i;
                    temp.SetValue(arr.GetValue(currentPositions), currentPositions);
                }
            }
            else
            {
                //Recursion one dimmension higher
                for (var i = 0; i < sizesToCopy[dimmension]; i++)
                {
                    currentPositions[dimmension] = i;
                    CopyArray(arr, temp, sizesToCopy, currentPositions, dimmension + 1);
                }
            }
        }
    }

}
