namespace JoeGerienLib.Extension.Test.NullExtensionTest;

public class GetValueOrEmptyCollectionTest
{
    [Fact]
    public void GetValueOrEmpty_WithCollection_AllCase()
    {
        // Arrange
        int[]? collectionNone = null;
        int[] collectionSome = [0, 1, 2];
        int[] collectionEmpty = Array.Empty<int>();

        // Act
        var resultNone = collectionNone.GetValueOrEmpty();
        var resultSome = collectionSome.GetValueOrEmpty();

        // Assert
        resultNone.Should().BeEquivalentTo(collectionEmpty);
        resultSome.Should().BeEquivalentTo([0, 1, 2]);
    }
}