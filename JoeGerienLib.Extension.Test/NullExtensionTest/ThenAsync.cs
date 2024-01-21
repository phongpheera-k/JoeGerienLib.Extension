namespace JoeGerienLib.Extension.Test.NullExtensionTest;

public class ThenAsync
{
    [Fact]
    public async Task ThenAsync_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        const string expectId = "GenIdGenId";
        const string funcName = "FuncName";
        const string expectName = "FuncNameFuncNameFuncName";
        var newTestClass = Mock.CreateTestClass(genId, null, 10);
        
        var resultId = string.Empty;
        var resultName = string.Empty;
        var resultAppendage = 0;
        var resultPeriod = 0;
        async Task<string> AppendWith(string startWith, string followWith) => await Task.FromResult(resultId = startWith + followWith);
        async Task<string> TripleString(string str) => await Task.FromResult(resultName = str + str + str);
        async Task<int?> DoubleNumber(int? num) => await Task.FromResult(resultAppendage = num!.Value + num.Value);
        async Task<int?> GetZero() => await Task.FromResult(resultPeriod = 0);
        
        // Act
        var resultThenId = (await newTestClass.Id.ThenAsync(s => AppendWith(s, s)
                , () => TripleString(funcName)))
            .GetValueOrEmpty();
        var resultThenName = (await newTestClass.Name.ThenAsync(s => AppendWith(s, s)
                , () => TripleString(funcName)))
            .GetValueOrEmpty();
        await newTestClass.Appendage.ThenAsync(DoubleNumber, GetZero);
        await newTestClass.Period.ThenAsync(DoubleNumber, GetZero);
        
        // Assert
        resultId.Should().Be(expectId);
        resultName.Should().Be(expectName);
        resultThenId.Should().Be(genId);
        resultThenName.Should().Be(string.Empty);
        resultAppendage.Should().Be(20);
        resultPeriod.Should().Be(0);
    }
}