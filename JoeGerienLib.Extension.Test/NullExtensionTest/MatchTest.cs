namespace JoeGerienLib.Extension.Test.NullExtensionTest;

public class MatchTest
{
    [Fact]
    public void Match_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        const string expectId = "GenIdGenId";
        const string funcName = "FuncName";
        const string expectName = "FuncNameFuncNameFuncName";
        var newTestClass = Mock.CreateTestClass(genId, null, 10);

        string AppendWith(string startWith, string followWith) => startWith + followWith;
        string TripleString(string str) => str + str + str;

        // Act
        var resultTestClass = new Mock.TestClass
        {
            Id = newTestClass.Id.Match(s => AppendWith(s, s), () => TripleString(funcName)),
            Name = newTestClass.Name.Match(s => AppendWith(s, s), () => TripleString(funcName)),
            Appendage = newTestClass.Appendage.Match(i => i+i, () => 0),
            Period = newTestClass.Period.Match(i => i+i, () => 0)
        };
        
        // Assert
        resultTestClass.Id.Should().Be(expectId);
        resultTestClass.Name.Should().Be(expectName);
        resultTestClass.Appendage.Should().Be(20);
        resultTestClass.Period.Should().Be(0);
    }
}