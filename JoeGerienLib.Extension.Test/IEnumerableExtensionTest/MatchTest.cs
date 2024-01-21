namespace JoeGerienLib.Extension.Test.IEnumerableExtensionTest;

public class MatchTest
{
    private static readonly Func<string, string> IfSome = item => item;
    private static readonly Func<string> IfNone = () => string.Empty;

    [Fact]
    public void Match_WhenCollectionIsEmpty_ReturnsEmptyCollection()
    {
        // Arrange
        IEnumerable<string?> collection = new List<string?>();

        // Act
        var result = collection.Match(IfSome, IfNone);

        // Assert
        result.Should().BeEmpty();
    }
    
    [Fact]
    public void Match_WhenCollectionHasNulls_ReturnsCollectionWithEmptyValues()
    {
        // Arrange
        IEnumerable<string?> collection = new List<string?> { null, null };

        // Act
        var result = collection.Match(IfSome, IfNone);

        // Assert
        result.Should().BeEquivalentTo(string.Empty, string.Empty);
    }
    
    [Fact]
    public void Match_WhenCollectionHasValues_ReturnsCollectionWithValues()
    {
        // Arrange
        IEnumerable<string?> collection = new List<string?> { "a", "b", "c" };

        // Act
        var result = collection.Match(IfSome, IfNone);

        // Assert
        result.Should().BeEquivalentTo("a", "b", "c");
    }
    
    [Fact]
    public void Match_WhenCollectionHasValuesAndNulls_ReturnsCollectionWithValuesAndEmptyValues()
    {
        // Arrange
        IEnumerable<string?> collection = new List<string?> { "a", null, "b", null, "c" };

        // Act
        var result = collection.Match(IfSome, IfNone);

        // Assert
        result.Should().BeEquivalentTo("a", string.Empty, "b", string.Empty, "c");
    }
}