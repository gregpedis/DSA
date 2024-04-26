using System;

namespace DSA.Test.Algorithms;

[TestClass]
public class BinarySearchTest
{
	[DataRow(-42, -1)]
	[DataRow(0, -1)]
	[DataRow(2, 0)]
	[DataRow(3, 1)]
	[DataRow(4, 2)]
	[DataRow(5, 3)]
	[DataRow(6, 4)]
	[DataRow(42, -1)]
	[DataTestMethod]
	public void BinarySearch_Baseline(int item, int indexFound)
	{
		var list = new List2<int> { 2, 3, 4, 5, 6 };

		BinarySearch2.Find(list, item).Should().Be(indexFound);
	}

	[TestMethod]
	public void BinarySearch_Throws()
	{
		((Action)(() => BinarySearch2.Find(null!, 42))).Should().ThrowExactly<ArgumentNullException>();
	}

	[TestMethod]
	public void BinarySearch_Empty()
	{
		BinarySearch2.Find([], 42).Should().Be(-1);
	}

	[TestMethod]
	public void BinarySearch_Singleton()
	{
		BinarySearch2.Find([42], 42).Should().Be(0);
		BinarySearch2.Find([0], 42).Should().Be(-1);
	}

	[TestMethod]
	public void BinarySearch_AllElementsEqual()
	{
		BinarySearch2.Find([42, 42], 42).Should().Be(0);
		BinarySearch2.Find([42, 42, 42], 42).Should().Be(1);
		BinarySearch2.Find([42, 42, 42, 42], 42).Should().Be(1);
		BinarySearch2.Find([42, 42, 42, 42, 42], 42).Should().Be(2);
		BinarySearch2.Find([42, 42, 42, 42, 42, 42], 42).Should().Be(2);
		BinarySearch2.Find([42, 42, 42, 42, 42, 42, 42], 42).Should().Be(3);
	}
}
