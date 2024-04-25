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

	public List2(IEnumerable<T> collection)
	{
		_items = collection.ToArray();
		_count = _items.Length;
	}

	public int Count => _count;
	public bool IsReadOnly => false;

	public T this[int index]
	{
		get => (index < 0 || index >= _count)
			? throw new ArgumentOutOfRangeException(nameof(index))
			: _items[index];

		set => _items[index] = index < 0 || index >= _count
			? throw new ArgumentOutOfRangeException(nameof(index))
			: value;
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

	public bool Contains(T item) =>
		IndexOf(item) >= 0;

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
			throw new ArgumentException("Not enough space", nameof(array));
		}

		for (int i = 0; i < _count; i++)
		{
			array[arrayIndex] = _items[i];
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

	// TODO: This implementation is wrong. It should insert it by growing the list and filling the spot with item.
	public void Insert(int index, T item)
	{
		if (_count == index)
		{
			Add(item);
		}
		else
		{
			this[index] = item;
		}
	}

	public bool Remove(T item)
	{
		var index = IndexOf(item);
		if (index >= 0)
		{
			RemoveAt(index);
			return true;
		}

		return false;
	}

	public void RemoveAt(int index)
	{
		ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(index, _count);
		Array.Copy(_items, index + 1, _items, index, _count - index - 1);
		_count--;
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	public IEnumerator<T> GetEnumerator() => _items.Take(_count).GetEnumerator();
}
