namespace JoeGerienLib.Extension.Test.NullExtensionTest;

public class IfSomeAsync
{
    [Fact]
    public async Task IfSomeAsync_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        const string expectId = "GenIdGenId";
        var expectName = string.Empty;
        var newTestClass = Mock.CreateTestClass(genId, null);
        
        var resultId = string.Empty;
        var resultName = string.Empty;
        async Task AppendWith(string startWith, string followWith) => await Task.FromResult( resultId = startWith + followWith);
        async Task TripleString(string str) => await Task.FromResult(resultName = str + str + str);
        
        // Act
        var resultIfSomeId = (await newTestClass.Id
                .IfSomeAsync(s => AppendWith(s, s)))
            .GetValueOrEmpty();
        var resultIfSomeName = (await newTestClass.Name
                .IfSomeAsync(TripleString))
            .GetValueOrEmpty();
        
        // Assert
        resultId.Should().Be(expectId);
        resultName.Should().Be(expectName);
        resultIfSomeId.Should().Be(genId);
        resultIfSomeName.Should().Be(string.Empty);
    }
}