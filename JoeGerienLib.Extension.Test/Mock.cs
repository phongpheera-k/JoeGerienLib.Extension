namespace JoeGerienLib.Extension.Test;

public static class Mock
{
    public class TestClass
    {
        public string? Id { get; init; } = string.Empty;
        public string? Name { get; init; } = string.Empty;
        public int? Appendage { get; init; }
        public int? Period { get; init; }
    }
    
    public static TestClass CreateTestClass(string? id = "ExampleId", string? name = "ExampleName", 
        int? appendage = null, int? period = null)
        => new()
        {
            Id = id,
            Name = name,
            Appendage = appendage,
            Period = period
        };

}