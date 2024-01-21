namespace JoeGerienLib.Extension.Test.IEnumerableExtensionTest;

public class MapTest
{
    private static readonly Func<string, string> FuncDefault = item => item;
    private static readonly Func<string, string> FuncModified = item => item + item;

    [Fact]
    public void Map_WhenCollectionIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        IEnumerable<string?>? collection = null;

        // Act
        Action act = () => collection!.Map(FuncDefault);

        // Assert
        act.Should().ThrowExactly<ArgumentNullException>();
    }
    
    [Fact]
    public void Map_WhenFuncIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        IEnumerable<string?> collection = new List<string?>();

        // Act
        Action act = () => collection.Map(null!);

        // Assert
        act.Should().ThrowExactly<ArgumentNullException>();
    }
    
    [Fact]
    public void Map_WhenCollectionIsEmpty_ReturnsEmptyCollection()
    {
        // Arrange
        IEnumerable<string?> collection = new List<string?>();

        // Act
        var result = collection.Map(FuncDefault);

        // Assert
        result.Should().BeEmpty();
    }
    
    [Fact]
    public void Map_WhenCollectionHasNulls_ReturnsEmptyCollection()
    {
        // Arrange
        IEnumerable<string?> collection = new List<string?> { null, null };

        // Act
        var result = collection.Map(FuncDefault);

        // Assert
        result.Should().BeEmpty();
    }
    
    [Fact]
    public void Map_WhenCollectionHasValues_ReturnsMappedCollection()
    {
        // Arrange
        IEnumerable<string?> collection = new List<string?> { "a", "b", "c" };

        // Act
        var result = collection.Map(FuncModified);

        // Assert
        result.Should().BeEquivalentTo(new List<string> { "aa", "bb", "cc" });
    }
}