using DSA.DataStructures;
using System;
using System.Collections.Generic;

namespace DSA.Algorithms;

public static class BinarySearch2
{
	/// <summary>
	/// Searches an entire one-dimensional sorted array for a specific element, using the IComparable interface implemented by each element of the array and by the specified object.
	/// </summary>
	/// <param name="collection">The sorted one-dimensional Array to search.</param>
	/// <param name="item">The object to search for.</param>
	/// <returns>The index of the specified value in the specified array, if value is found; otherwise, a negative number</returns>
	public static int Find<T>(IList<T> collection, T item) where T : IComparable<T>
	{
		ArgumentNullException.ThrowIfNull(collection);

		var left = 0;
		var right = collection.Count - 1;

		while (left <= right)
		{
			var mid = (right + left) / 2;

			var comparison = item.CompareTo(collection[mid]);
			if (comparison == 0)
			{
				return mid;
			}
			else if (comparison < 0)
			{
				right = mid - 1;
			}
			else
			{
				left = mid + 1;
			}
		}

		return -1;
	}
}
