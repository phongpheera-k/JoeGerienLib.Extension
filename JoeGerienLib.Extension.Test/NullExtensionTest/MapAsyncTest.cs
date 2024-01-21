namespace JoeGerienLib.Extension.Test.NullExtensionTest;

public class MapAsyncTest
{
    [Fact]
    public async Task MapAsync_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        const string expectId = "GenIdGenId";
        var newTestClass = Mock.CreateTestClass(genId, null, 10);

        async Task<string> AppendWith(string startWith, string followWith) => await Task.FromResult(startWith + followWith);
        async Task<int?> DoubleNumber(int? num) => await Task.FromResult(num!.Value + num.Value);

        // Act
        var resultTestClass = new Mock.TestClass
        {
            Id = await newTestClass.Id.MapAsync(s => AppendWith(s, s)),
            Name = await newTestClass.Name.MapAsync(s => AppendWith(s, s)),
            Appendage = await newTestClass.Appendage.MapAsync(DoubleNumber),
            Period = await newTestClass.Period.MapAsync(DoubleNumber)
        };

        // Assert
        resultTestClass.Id.Should().Be(expectId);
        resultTestClass.Name.Should().BeNull();
        resultTestClass.Appendage.Should().Be(20);
        resultTestClass.Period.Should().BeNull();
    }
}