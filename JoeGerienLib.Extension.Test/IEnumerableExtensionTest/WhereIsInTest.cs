namespace JoeGerienLib.Extension.Test.IEnumerableExtensionTest;

public class WhereIsInTest
{
    [Fact]
    public void WhereIsIn_WhenCalled_ReturnsExpected()
    {
        // Arrange
        var collection = new[] {1, 2, 3, 4};
        var otherCollection = new[] {1, 3, 5};
        var expected = new[] {1, 3};

        // Act
        var result = collection.WhereIsIn(otherCollection);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}