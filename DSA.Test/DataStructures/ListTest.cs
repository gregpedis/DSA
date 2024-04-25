using System;

namespace DSA.Test.DataStructures;

[TestClass]
public class ListTest
{
	[TestMethod]
	public void List_Constructor()
	{
		var list = new List2<int>();
		list.Should().BeEquivalentTo(Array.Empty<int>());
	}

	[TestMethod]
	public void List_Constructor_Collection()
	{
		var list = new List2<int>([1, 2, 3]);
		list.Should().BeEquivalentTo([1, 2, 3]);
	}

	[TestMethod]
	public void List_Count()
	{
		new List2<int>().Count.Should().Be(0);
		new List2<int> { 42 }.Count.Should().Be(1);
		new List2<int> { 1, 2 }.Count.Should().Be(2);
	}

	[TestMethod]
	public void List_IsReadOnly()
	{
		new List2<int>().IsReadOnly.Should().BeFalse();
	}

	[TestMethod]
	public void List_Index_Get()
	{
		var list = new List2<int> { 42 };

		((Func<int>)(() => list[-1])).Should().ThrowExactly<ArgumentOutOfRangeException>();
		((Func<int>)(() => list[42])).Should().ThrowExactly<ArgumentOutOfRangeException>();
		list[0].Should().Be(42);
	}

	[TestMethod]
	public void List_Index_Set()
	{
		var list = new List2<int> { 42 };

		((Func<int>)(() => list[-1] = 0)).Should().ThrowExactly<ArgumentOutOfRangeException>();
		((Func<int>)(() => list[42] = 0)).Should().ThrowExactly<ArgumentOutOfRangeException>();

		list[0].Should().Be(42);
		list[0] = 0;
		list[0].Should().Be(0);
	}

	[TestMethod]
	public void List_Add()
	{
		var list = new List2<int> { 0 };
		list.Should().BeEquivalentTo([0]);

		list.Add(1);
		list.Should().BeEquivalentTo([0, 1]);

		list.Add(2);
		list.Add(3);
		list.Add(4);
		list.Add(5);
		list.Should().BeEquivalentTo([0, 1, 2, 3, 4, 5]);
	}

	[TestMethod]
	public void List_Clear()
	{
		var list = new List2<int> { 1, 2, 3 };
		list.Should().BeEquivalentTo([1,2,3]);

		list.Clear();
		list.Should().BeEquivalentTo(Array.Empty<int>());
	}

	[TestMethod]
	public void List_Contains()
	{
		var list = new List2<int> { 42 };

		list.Contains(0).Should().BeFalse();
		list.Contains(42).Should().BeTrue();

		list.Add(0);
		list.Contains(0).Should().BeTrue();
	}

	[TestMethod]
	public void List_CopyTo()
	{
		var list = new List2<int> { 1, 2, 3 };

		var arr = new int[5];

		list.CopyTo(arr, 0);
		arr.Should().BeEquivalentTo([1, 2, 3, 0, 0]);

		list.CopyTo(arr, 2);
		arr.Should().BeEquivalentTo([1, 2, 1, 2, 3]);

		((Action)(() => list.CopyTo(null!, 42))).Should().ThrowExactly<ArgumentNullException>();
		((Action)(() => list.CopyTo(arr, -1))).Should().ThrowExactly<ArgumentOutOfRangeException>();
		((Action)(() => list.CopyTo(arr, 42))).Should().ThrowExactly<ArgumentException>();
	}

	[TestMethod]
	public void List_IndexOf()
	{
		var list = new List2<int> { 1, 2, 3 };

		list.IndexOf(2).Should().Be(1);
		list.IndexOf(42).Should().Be(-1);
	}

	[TestMethod]
	public void List_Insert()
	{
		var list = new List2<int> { 1, 2, 3 };

		list.Should().BeEquivalentTo([1, 2, 3]);

		list.Insert(0, 42);
		list.Should().BeEquivalentTo([42, 2, 3]);

		list.Insert(3, -2);
		list.Should().BeEquivalentTo([42, 2, 3, -2]);
	}

	[TestMethod]
	public void List_Remove()
	{
		var list = new List2<int> { 1, 2, 3 };
		list.Should().BeEquivalentTo([1, 2, 3]);

		list.Remove(2).Should().BeTrue();
		list.Should().BeEquivalentTo([1, 3]);

		list.Remove(42).Should().BeFalse();
		list.Should().BeEquivalentTo([1, 3]);
	}

	[TestMethod]
	public void List_RemoveAt()
	{
		var list = new List2<int> { 1, 2, 3 };

		((Action)(() => list.RemoveAt(42))).Should().ThrowExactly<ArgumentOutOfRangeException>();
		((Action)(() => list.RemoveAt(list.Count))).Should().ThrowExactly<ArgumentOutOfRangeException>();

		list.Should().BeEquivalentTo([1, 2, 3]);

		list.RemoveAt(1);
		list.Should().BeEquivalentTo([1, 3]);
	}

	[TestMethod]
	public void List_GetEnumerator()
	{
		var list = new List2<int> { 1, 2 };
		var enumerator = ((System.Collections.IEnumerable)list).GetEnumerator();

		enumerator.MoveNext().Should().Be(true);
		enumerator.Current.Should().Be(1);

		enumerator.MoveNext().Should().Be(true);
		enumerator.Current.Should().Be(2);

		enumerator.MoveNext().Should().BeFalse();
	}
}
