namespace JoeGerienLib.Extension.Test.IEnumerableExtensionTest;

public class WhereIsNotInTest
{
    [Fact]
    public void WhereIsNotIn_WhenCalled_ReturnsExpected()
    {
        // Arrange
        var collection = new[] {1, 2, 3, 4};
        var otherCollection = new[] {1, 3, 5};
        var expected = new[] {2, 4};

        // Act
        var result = collection.WhereIsNotIn(otherCollection);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}