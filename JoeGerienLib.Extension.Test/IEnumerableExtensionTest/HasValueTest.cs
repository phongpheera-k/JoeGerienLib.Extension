namespace JoeGerienLib.Extension.Test.IEnumerableExtensionTest;

public class HasValueTest
{
    [Fact]
    public void HasValue_WhenCollectionIsNull_ReturnsFalse()
    {
        // Arrange
        IEnumerable<string>? collection = null;

        // Act
        var result = collection.HasValue();

        // Assert
        result.Should().BeFalse();
    }
    
    [Fact]
    public void HasValue_WhenCollectionIsEmpty_ReturnsFalse()
    {
        // Arrange
        var collection = Enumerable.Empty<string>();

        // Act
        var result = collection.HasValue();

        // Assert
        result.Should().BeFalse();
    }
    
    [Fact]
    public void HasValue_WhenCollectionIsNotEmpty_ReturnsTrue()
    {
        // Arrange
        var collection = new[] { "test" };

        // Act
        var result = collection.HasValue();

        // Assert
        result.Should().BeTrue();
    }
}