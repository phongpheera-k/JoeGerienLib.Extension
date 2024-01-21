namespace JoeGerienLib.Extension.Test.IEnumerableExtensionTest;

public class ForEachTest
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
}