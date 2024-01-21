namespace JoeGerienLib.Extension.Test.NullExtensionTest;

public class IfSome
{
    [Fact]
    public void IfSome_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        const string expectId = "GenIdGenId";
        var expectName = string.Empty;
        var newTestClass = Mock.CreateTestClass(genId, null);
        
        string AppendWith(string startWith, string followWith) => startWith + followWith;
        string TripleString(string str) => str + str + str;
        
        // Act
        var resultId = string.Empty;
        var resultName = string.Empty;
        var resultIfSomeId = newTestClass.Id
            .IfSome(s => resultId = AppendWith(s, s))
            .GetValueOrEmpty();
        var resultIfSomeName = newTestClass.Name
            .IfSome(s => resultName = TripleString(s))
            .GetValueOrEmpty();
        
        // Assert
        resultId.Should().Be(expectId);
        resultName.Should().Be(expectName);
        resultIfSomeId.Should().Be(genId);
        resultIfSomeName.Should().Be(string.Empty);
    }
}