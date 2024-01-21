namespace JoeGerienLib.Extension.Test.IEnumerableExtensionTest;

public class WhereHasValueTest
{
    [Fact]
    public void WhereHasValue_WhenCollectionIsNull_ReturnsEmptyCollection()
    {
        // Arrange
        IEnumerable<string?> collection = [null];

        // Act
        var result = collection.WhereHasValue();

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void WhereHasValue_WhenCollectionIsEmpty_ReturnsEmptyCollection()
    {
        // Arrange
        var collection = Enumerable.Empty<string?>();

        // Act
        var result = collection.WhereHasValue();

        // Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public void WhereHasValue_WhenCollectionIsNotEmpty_ReturnsCollectionWithoutNulls()
    {
        // Arrange
        var collection = new[] { "test", null, "test2" };
        var expected = new[] { "test", "test2" };

        // Act
        var result = collection.WhereHasValue();

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void WhereHasValue_WhenCollectionIsNotEmptyAndHasPredicate_ReturnsCollectionWithoutNulls()
    {
        // Arrange
        var collection = new[] { "test", null, "test2" };
        var expected = new[] { "test2" };

        // Act
        var result = collection.WhereHasValue(item => item == "test2");

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}