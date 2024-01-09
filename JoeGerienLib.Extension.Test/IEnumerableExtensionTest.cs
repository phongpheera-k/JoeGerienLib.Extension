namespace JoeGerienLib.Extension.Test;

// ReSharper disable once InconsistentNaming
public class IEnumerableExtensionTest
{
    [Fact]
    public void ForEach_WithArray_ShouldIterationAll()
    {
        // Arrange
        const int expectResult = 15;
        var collection = new[] {1, 2, 3, 4, 5};
        
        // Act
        var result = 0;
        collection.ForEach(item => result += item);

        // Assert
        result.Should().Be(expectResult);
    }
    
    [Fact]
    public void IsIn_WithArray_ShouldReturnTrue()
    {
        // Arrange
        const int item = 1;
        var collection = new[] {1, 2, 3, 4, 5};
        
        // Act
        var result = item.IsIn(collection);

        // Assert
        result.Should().BeTrue();
    }
}