namespace DSA.Test;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void Add_Test()
    {
        Mathematics.Sum(1, 2).Should().Be(3);
    }
}