namespace JoeGerienLib.Extension.Test.NullExtensionTest;

public class MatchAsync
{
    [Fact]
    public async Task MatchAsync_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        const string expectId = "GenIdGenId";
        const string funcName = "FuncName";
        const string expectName = "FuncNameFuncNameFuncName";
        var newTestClass = Mock.CreateTestClass(genId, null, 10);

        async Task<string> AppendWith(string startWith, string followWith) => await Task.FromResult(startWith + followWith);
        async Task<string> TripleString(string str) => await Task.FromResult(str + str + str);
        async Task<int?> DoubleNumber(int? num) => await Task.FromResult(num!.Value + num.Value);
        async Task<int?> GetZero() => await Task.FromResult(0);

        // Act
        var resultTestClass = new Mock.TestClass
        {
            Id = await newTestClass.Id.MatchAsync(s => AppendWith(s, s), () => TripleString(funcName)),
            Name = await newTestClass.Name.MatchAsync(s => AppendWith(s, s), () => TripleString(funcName)),
            Appendage = await newTestClass.Appendage.MatchAsync(DoubleNumber,  GetZero),
            Period = await newTestClass.Period.MatchAsync(DoubleNumber, GetZero)
        };

        // Assert
        resultTestClass.Id.Should().Be(expectId);
        resultTestClass.Name.Should().Be(expectName);
        resultTestClass.Appendage.Should().Be(20);
        resultTestClass.Period.Should().Be(0);
    }
}