namespace JoeGerienLib.Extension.Test.NullExtensionTest;

public class HasValueTest
{
    [Fact]
    public void HasValue_WithClassAndString_AllCase()
    {
        // Arrange
        const string? strNone = null;
        const string? strSome = "value";
        Mock.TestClass? classNone = null;
        Mock.TestClass classSome = Mock.CreateTestClass();
        
        // Act
        var resultStrNone = strNone.HasValue();
        var resultStrSome = strSome.HasValue();
        var resultClassNone = classNone.HasValue();
        var resultClassSome = classSome.HasValue();
        
        // Assert
        resultStrNone.Should().BeFalse();
        resultStrSome.Should().BeTrue();
        resultClassNone.Should().BeFalse();
        resultClassSome.Should().BeTrue();
    }
}