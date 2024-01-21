namespace JoeGerienLib.Extension.Test.NullExtensionTest;

public class GetValueOrNewTest
{
    [Fact]
    public void GetValueOrNew_WithClass_AllCase()
    {
        // Arrange
        var initClass = Mock.CreateTestClass();
        
        Mock.TestClass? classNone = null;
        Mock.TestClass classSome = initClass;
        Mock.TestClass classNew = new();
        Mock.TestClass classDefault = new() {Id = "NewId", Name = "NewName"};

        // Act
        var resultNone = classNone.GetValueOrNew();
        var resultSome = classSome.GetValueOrNew();
        var resultDefault = classNone.GetValueOrNew(classDefault);

        // Assert
        resultNone.Should().BeEquivalentTo(classNew);
        resultSome.Should().BeEquivalentTo(initClass);
        resultDefault.Should().BeEquivalentTo(classDefault);
    }
}