namespace JoeGerienLib.Extension;

public static class NullExtension
{
    public static bool HasValue<T>(this T? input) where T : class => input is not null;
    public static string GetValueOrEmpty(this string? input, string value = "") => input ?? value;

    public static IEnumerable<T> GetValueOrEmpty<T>(this IEnumerable<T>? input) => input ?? Enumerable.Empty<T>();
    
    public static T GetValueOrNew<T>(this T? input) where T : class, new() => input ?? new T();
    
    public static T GetValueOrNew<T>(this T? input, T value) where T : class, new() => input ?? value;

    public static TResult? Map<TParam, TResult>(this TParam? input, Func<TParam, TResult> func)
        => input is not null ? func(input) : default;

    public static async Task<TResult?> MapAsync<TParam, TResult>(this TParam? input, Func<TParam, Task<TResult>> func)
        => input is not null ? await func(input) : default;

    public static TResult Match<TParam, TResult>(this TParam? input, Func<TParam, TResult> ifSome, Func<TResult> ifNone)
        => input is not null ? ifSome(input) : ifNone();

    public static async Task<TResult> MatchAsync<TParam, TResult>(this TParam? input, Func<TParam, Task<TResult>> ifSome, Func<Task<TResult>> ifNone)
        => input is not null ? await ifSome(input) : await ifNone();

    public static T? Then<T>(this T? input, Action<T> ifSome, Action ifNone)
    {
        if (input is not null)
            ifSome(input);
        else
            ifNone();

        return input;
    }
    
    public static async Task<T?> ThenAsync<T>(this T? input, Func<T, Task> ifSome, Func<Task> ifNone)
    {
        if (input is not null)
            await ifSome(input);
        else
            await ifNone();

        return input;
    }
    
    public static T? IfSome<T>(this T? input, Action<T> ifSome)
    {
        if (input is not null)
            ifSome(input);

        return input;
    }
    
    public static async Task<T?> IfSomeAsync<T>(this T? input, Func<T, Task> ifSome)
    {
        if (input is not null)
        {
            await ifSome(input);
        }

        return input;
    }
    
    public static T? IfNone<T>(this T? input, Action ifNone)
    {
        if (input is null)
            ifNone();

        return input;
    }

    public static async Task<T?> IfNoneAsync<T>(this T? input, Func<Task> ifNone)
    {
        if (input is null)
            await ifNone();

        return input;
    }
}