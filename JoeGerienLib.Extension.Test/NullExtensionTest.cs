namespace JoeGerienLib.Extension.Test;

public class NullExtensionTest
{
    #region TestClass

    private class TestClass
    {
        public string? Id { get; init; } = string.Empty;
        public string? Name { get; init; } = string.Empty;
        public int? Appendage { get; init; }
        public int? Period { get; init; }
    }

    private static TestClass CreateTestClass(string? id = "ExampleId", string? name = "ExampleName", 
        int? appendage = null, int? period = null)
        => new TestClass
        {
            Id = id,
            Name = name,
            Appendage = appendage,
            Period = period
        };

    #endregion
    
    [Fact]
    public void HasValue_WithClassAndString_AllCase()
    {
        // Arrange
        const string? strNone = null;
        const string? strSome = "value";
        TestClass? classNone = null;
        TestClass classSome = CreateTestClass();
        
        // Act
        var resultStrNone = strNone.HasValue();
        var resultStrSome = strSome.HasValue();
        var resultClassNone = classNone.HasValue();
        var resultClassSome = classSome.HasValue();
        
        // Assert
        resultStrNone.Should().BeFalse();
        resultStrSome.Should().BeTrue();
        resultClassNone.Should().BeFalse();
        resultClassSome.Should().BeTrue();
    }

    [Fact]
    public void GetValueOrEmpty_WithString_AllCase()
    {
        // Arrange
        const string strDefault = "default";
        const string? strNone = null;
        const string? strSome = "value";

        // Act
        var resultNone = strNone.GetValueOrEmpty();
        var resultDefault = strNone.GetValueOrEmpty(strDefault);
        var resultSome = strSome.GetValueOrEmpty();

        // Assert
        resultNone.Should().Be(string.Empty);
        resultDefault.Should().Be(strDefault);
        resultSome.Should().Be(strSome);
    }

    [Fact]
    public void GetValueOrNew_WithClass_AllCase()
    {
        // Arrange
        var initClass = CreateTestClass();
        
        TestClass? classNone = null;
        TestClass classSome = initClass;
        TestClass classNew = new TestClass();
        TestClass classDefault = new TestClass {Id = "NewId", Name = "NewName"};

        // Act
        var resultNone = classNone.GetValueOrNew();
        var resultSome = classSome.GetValueOrNew();
        var resultDefault = classNone.GetValueOrNew(classDefault);

        // Assert
        resultNone.Should().BeEquivalentTo(classNew);
        resultSome.Should().BeEquivalentTo(initClass);
        resultDefault.Should().BeEquivalentTo(classDefault);
    }

    [Fact]
    public void GetValueOrEmpty_WithCollection_AllCase()
    {
        // Arrange
        int[]? collectionNone = null;
        int[] collectionSome = {0, 1, 2};
        int[] collectionEmpty = Array.Empty<int>();

        // Act
        var resultNone = collectionNone.GetValueOrEmpty();
        var resultSome = collectionSome.GetValueOrEmpty();

        // Assert
        resultNone.Should().BeEquivalentTo(collectionEmpty);
        resultSome.Should().BeEquivalentTo(new[] {0, 1, 2});
    }

    [Fact]
    public void Map_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        const string expectId = "GenIdGenId";
        var newTestClass = CreateTestClass(genId, null, 10);

        string AppendWith(string startWith, string followWith) => startWith + followWith;

        // Act
        var resultTestClass = new TestClass
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
    
    [Fact]
    public async Task MapAsync_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        const string expectId = "GenIdGenId";
        var newTestClass = CreateTestClass(genId, null, 10);

        async Task<string> AppendWith(string startWith, string followWith) => await Task.FromResult(startWith + followWith);
        async Task<int?> DoubleNumber(int? num) => await Task.FromResult(num!.Value + num.Value);

        // Act
        var resultTestClass = new TestClass
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

    [Fact]
    public void Match_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        const string expectId = "GenIdGenId";
        const string funcName = "FuncName";
        const string expectName = "FuncNameFuncNameFuncName";
        var newTestClass = CreateTestClass(genId, null, 10);

        string AppendWith(string startWith, string followWith) => startWith + followWith;
        string TripleString(string str) => str + str + str;

        // Act
        var resultTestClass = new TestClass
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
    
    [Fact]
    public async Task MatchAsync_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        const string expectId = "GenIdGenId";
        const string funcName = "FuncName";
        const string expectName = "FuncNameFuncNameFuncName";
        var newTestClass = CreateTestClass(genId, null, 10);

        async Task<string> AppendWith(string startWith, string followWith) => await Task.FromResult(startWith + followWith);
        async Task<string> TripleString(string str) => await Task.FromResult(str + str + str);
        async Task<int?> DoubleNumber(int? num) => await Task.FromResult(num!.Value + num.Value);
        async Task<int?> GetZero() => await Task.FromResult(0);

        // Act
        var resultTestClass = new TestClass
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

    [Fact]
    public void Then_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        const string expectId = "GenIdGenId";
        const string funcName = "FuncName";
        const string expectName = "FuncNameFuncNameFuncName";
        var newTestClass = CreateTestClass(genId, null);
        
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
    
    [Fact]
    public async Task ThenAsync_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        const string expectId = "GenIdGenId";
        const string funcName = "FuncName";
        const string expectName = "FuncNameFuncNameFuncName";
        var newTestClass = CreateTestClass(genId, null, 10);
        
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

    [Fact]
    public void IfSome_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        const string expectId = "GenIdGenId";
        var expectName = string.Empty;
        var newTestClass = CreateTestClass(genId, null);
        
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

    [Fact]
    public async Task IfSomeAsync_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        const string expectId = "GenIdGenId";
        var expectName = string.Empty;
        var newTestClass = CreateTestClass(genId, null);
        
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

    [Fact]
    public void IfNone_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        var expectId = string.Empty;
        const string funcName = "FuncName";
        const string expectName = "FuncNameFuncNameFuncName";
        var newTestClass = CreateTestClass(genId, null);
        
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
    
    [Fact]
    public async Task IfNoneAsync_WithFieldInClass_AllCase()
    {
        // Arrange
        const string genId = "GenId";
        var expectId = string.Empty;
        const string funcName = "FuncName";
        const string expectName = "FuncNameFuncNameFuncName";
        var newTestClass = CreateTestClass(genId, null);
        
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