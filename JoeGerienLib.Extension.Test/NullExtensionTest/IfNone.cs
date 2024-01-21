namespace JoeGerienLib.Extension.Test.NullExtensionTest;

public class IfNone
{
    [Fact]
    public void IfNone_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        var expectId = string.Empty;
        const string funcName = "FuncName";
        const string expectName = "FuncNameFuncNameFuncName";
        var newTestClass = Mock.CreateTestClass(genId, null);
        
        string AppendWith(string startWith, string followWith) => startWith + followWith;
        string TripleString(string str) => str + str + str;
        
        // Act
        var resultId = string.Empty;
        var resultName = string.Empty;
        var resultIfNoneId = newTestClass.Id
            .IfNone(() => resultId = AppendWith(genId, genId))
            .GetValueOrEmpty();
        var resultIfNoneName = newTestClass.Name
            .IfNone(() => resultName = TripleString(funcName))
            .GetValueOrEmpty();
        
        // Assert
        resultId.Should().Be(expectId);
        resultName.Should().Be(expectName);
        resultIfNoneId.Should().Be(genId);
        resultIfNoneName.Should().Be(string.Empty);
    }
}