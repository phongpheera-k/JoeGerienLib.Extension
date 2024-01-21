namespace JoeGerienLib.Extension.Test.IEnumerableExtensionTest;

public class IsInTest
{
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