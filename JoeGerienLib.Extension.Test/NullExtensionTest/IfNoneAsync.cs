namespace JoeGerienLib.Extension.Test.NullExtensionTest;

public class IfNoneAsync
{
    [Fact]
    public async Task IfNoneAsync_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        var expectId = string.Empty;
        const string funcName = "FuncName";
        const string expectName = "FuncNameFuncNameFuncName";
        var newTestClass = Mock.CreateTestClass(genId, null);
        
        var resultId = string.Empty;
        var resultName = string.Empty;
        async Task AppendWith(string startWith, string followWith) => await Task.FromResult( resultId = startWith + followWith);
        async Task TripleString(string str) => await Task.FromResult(resultName = str + str + str);
        
        // Act
        var resultIfSomeId = (await newTestClass.Id
                .IfNoneAsync(() => AppendWith(genId, genId)))
            .GetValueOrEmpty();
        var resultIfSomeName = (await newTestClass.Name
                .IfNoneAsync(() => TripleString(funcName)))
            .GetValueOrEmpty();
        
        // Assert
        resultId.Should().Be(expectId);
        resultName.Should().Be(expectName);
        resultIfSomeId.Should().Be(genId);
        resultIfSomeName.Should().Be(string.Empty);
    }
}