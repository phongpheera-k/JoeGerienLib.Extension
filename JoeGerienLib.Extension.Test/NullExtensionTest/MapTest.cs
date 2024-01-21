namespace JoeGerienLib.Extension.Test.NullExtensionTest;

public class MapTest
{
    [Fact]
    public void Map_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        const string expectId = "GenIdGenId";
        var newTestClass = Mock.CreateTestClass(genId, null, 10);

        string AppendWith(string startWith, string followWith) => startWith + followWith;

        // Act
        var resultTestClass = new Mock.TestClass
        {
            Id = newTestClass.Id.Map(s => AppendWith(s, s)),
            Name = newTestClass.Name.Map(s => AppendWith(s, s)),
            Appendage = newTestClass.Appendage.Map(i => i+i),
            Period = newTestClass.Period.Map(i => i+i)
        };

        // Assert
        resultTestClass.Id.Should().Be(expectId);
        resultTestClass.Name.Should().BeNull();
        resultTestClass.Appendage.Should().Be(20);
        resultTestClass.Period.Should().BeNull();
    }
}