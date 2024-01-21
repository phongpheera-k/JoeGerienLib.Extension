namespace JoeGerienLib.Extension.Test.NullExtensionTest;

public class GetValueOrEmptyStringTest
{
    [Fact]
    public void GetValueOrEmpty_WithString_AllCase()
    {
        // Arrange
        const string strDefault = "default";
        const string? strNone = null;
        const string? strSome = "value";

        // Act
        var resultNone = strNone.GetValueOrEmpty();
        var resultDefault = strNone.GetValueOrEmpty(strDefault);
        var resultSome = strSome.GetValueOrEmpty();

        // Assert
        resultNone.Should().Be(string.Empty);
        resultDefault.Should().Be(strDefault);
        resultSome.Should().Be(strSome);
    }
}