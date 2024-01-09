namespace JoeGerienLib.Extension;

// ReSharper disable once InconsistentNaming
public static class IEnumerableExtension
{
    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (var item in collection)
        {
            action(item);
        }
    }
    
    public static bool IsIn<T>(this T item, IEnumerable<T> collection) => collection.Contains(item);
}