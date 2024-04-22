using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DSA.DataStructures;

public class List2<T> : IList<T>
{
	private const int DEFAULT_CAPACITY = 4;
	private T[] _items;
	private int _count;

	public List2()
	{
		_items = new T[DEFAULT_CAPACITY];
		_count = 0;
	}

	public List2(int capacity)
	{
		_items = new T[capacity];
		_count = 0;
	}

	public List2(IEnumerable<T> collection)
	{
		_items = collection.ToArray();
		_count = _items.Length;
	}

	public int Count => _count;
	public bool IsReadOnly => false;

	public T this[int index]
	{
#pragma warning disable S3358 // Ternary operators should not be nested
		get =>
			index >= _items.Length ? throw new ArgumentOutOfRangeException(nameof(index), "{0} is equal or greater than Count")
			: index < 0 ? throw new ArgumentOutOfRangeException(nameof(index), "{0} is less than zero")
			: _items[index];
#pragma warning restore S3358 // Ternary operators should not be nested
		set
		{
			if (index >= _items.Length)
			{
				throw new ArgumentOutOfRangeException(nameof(index), "{0} is equal or greater than Count");
			}
			else if (index < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(index), "{0} is less than zero");
			}
			else
			{
				_items[index] = value;
			}
		}
	}

	public void Add(T item)
	{
		if (_count == _items.Length)
		{
			var temp = new T[_items.Length * 2];
			_items.CopyTo(temp, 0);
			_items = temp;
		}

		_items[_count] = item;
		_count++;
	}

	public void Clear()
	{
		Array.Clear(_items);
		_count = 0;
	}

	public bool Contains(T item)
	{
		foreach (var x in _items)
		{
			if (EqualityComparer<T>.Default.Equals(x, item))
			{
				return true;
			}
		}
		return false;
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		if (array is null)
		{
			throw new ArgumentNullException(nameof(array));
		}
		else if (arrayIndex < 0)
		{
			throw new ArgumentOutOfRangeException(nameof(arrayIndex));
		}
		else if (array.Length - arrayIndex < _count)
		{
			throw new ArgumentException("{0} does not have enough space", nameof(array));
		}

		foreach (var item in _items)
		{
			array[arrayIndex] = item;
			arrayIndex++;
		}
	}

	public int IndexOf(T item)
	{
		for (int i = 0; i < _count; i++)
		{
			if (EqualityComparer<T>.Default.Equals(_items[i], item))
			{
				return i;
			}
		}
		return -1;
	}

	public void Insert(int index, T item)
	{

		throw new NotImplementedException();
	}

	public bool Remove(T item)
	{
		throw new NotImplementedException();
	}

	public void RemoveAt(int index)
	{
		throw new NotImplementedException();
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	public IEnumerator<T> GetEnumerator() => _items.AsEnumerable().GetEnumerator();
}
