namespace JoeGerienLib.Extension;

// ReSharper disable once InconsistentNaming
public static class IEnumerableExtension
{
    public static bool HasValue<T>(this IEnumerable<T>? input) => input is not null && input.Any();
    
    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (var item in collection)
        {
            action(item);
        }
    }
    
    public static bool IsIn<T>(this T item, IEnumerable<T> collection) => collection.Contains(item);
    
    public static IEnumerable<T> WhereHasValue<T>(this IEnumerable<T?> collection) where T : class
        => collection.Where(item => item is not null)!;
    
    public static IEnumerable<T> WhereHasValue<T>(this IEnumerable<T?> collection, Func<T, bool> predicate) 
        where T : class
        => collection.Where(item => item is not null && predicate(item))!;
    
    public static IEnumerable<T> WhereIsIn<T>(this IEnumerable<T> collection, IEnumerable<T> otherCollection)
        => collection.Where(item => item.IsIn(otherCollection));
    
    public static IEnumerable<T> WhereIsNotIn<T>(this IEnumerable<T> collection, IEnumerable<T> otherCollection)
        => collection.Where(item => !item.IsIn(otherCollection));
    
    public static IEnumerable<T> Map<T>(this IEnumerable<T?> collection, Func<T, T> func) where T : class
        => collection
            .WhereHasValue()
            .Select(func);

    public static IEnumerable<T> Match<T>(this IEnumerable<T?> collection, Func<T, T> ifSome, Func<T> ifNone)
        where T : class
        => collection.Select(item => item is not null ? ifSome(item) : ifNone());
}