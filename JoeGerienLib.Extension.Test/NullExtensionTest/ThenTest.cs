namespace JoeGerienLib.Extension.Test.NullExtensionTest;

public class ThenTest
{
    [Fact]
    public void Then_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        const string expectId = "GenIdGenId";
        const string funcName = "FuncName";
        const string expectName = "FuncNameFuncNameFuncName";
        var newTestClass = Mock.CreateTestClass(genId, null);
        
        string AppendWith(string startWith, string followWith) => startWith + followWith;
        string TripleString(string str) => str + str + str;
        
        // Act
        var resultId = string.Empty;
        var resultName = string.Empty;
        var resultThenId = newTestClass.Id.Then(s => resultId = AppendWith(s, s)
                , () => resultId = TripleString(funcName))
            .GetValueOrEmpty();
        var resultThenName = newTestClass.Name.Then(s => resultName = AppendWith(s, s)
                , () => resultName = TripleString(funcName))
            .GetValueOrEmpty();
        
        // Assert
        resultId.Should().Be(expectId);
        resultName.Should().Be(expectName);
        resultThenId.Should().Be(genId);
        resultThenName.Should().Be(string.Empty);
    }
}