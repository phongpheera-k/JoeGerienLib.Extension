# JoeGerienLib.Extension

`JoeGerienLib.Extension` is a comprehensive C# library featuring a wide 
array of extension methods designed to augment the functionality of 
standard .NET types. This library particularly excels in enhancing 
`Nullable` types or `IEnumerable` collections, along with other common 
data types. These extension methods simplify the development process 
by providing more intuitive and efficient ways to handle null checks, 
default values, conditional operations, and transformations. 
The versatility of this library makes it a valuable tool for any .NET 
developer seeking to write cleaner, more maintainable code.

## Installation
The `JoeGerienLib.Extension` package can be easily installed via 
the NuGet Package Manager in your project. You can install it using one 
of the following methods:\

1. **Through NuGet Package Manager UI**<br>
- Open your project in Visual Studio.
- Navigate to `Tools` -> `NuGet Package Manager` -> `Manage NuGet Packages 
for Solution...`
- Search for `JoeGerienLib.Extensions` in the *Browse* tab.
- Select the package and click *Install*.
2. **Through NuGet Package Manager Console**<br>
- Open your project in Visual Studio.
- Go to `Tools` -> `NuGet Package Manager` -> `Package Manager Console`.
- Enter the following command:
```nuget
Install-Package JoeGerienLib.Extension
```
3. **Through .NET CLI**<br>
If you're using .NET CLI, you can install the package with the command:
```bash
dotnet add package JoeGerienLib.Extensions
```
--------------------
## Using the Extensions
After successfully installing the `JoeGerienLib.Extensions` package, 
you can start using the extension methods in the library simply 
by adding a `using` statement for the `JoeGerienLib.Extension` namespace 
at the beginning of your code file:
```csharp
using JoeGerienLib.Extension;
```
Then, you can begin to call various methods from the library, 
such as HasValue, GetValueOrEmpty, or ForEach, applying them 
to appropriate variables or collections in your code as needed:
```csharp
var numbers = new List<int?> { 1, 2, null, 4 };
numbers.ForEach(n => {
    if (n.HasValue()) {
        Console.WriteLine(n.GetValueOrEmpty());
    }
});
```
--------------------
## Documentation
The following sections provide a detailed overview of the extension
methods available in `JoeGerienLib.Extension`.

### Nullable Extensions
The `NullExtension` class offers a set of static methods designed to 
operate on nullable types, providing functionalities like checking 
for value existence, obtaining values with default options, and 
executing actions based on the presence or absence of values.

### Methods
`HasValue` \
Checks if a nullable object has a value.

`Usage Example:`
```csharp
int? number = 5;
var result = number.HasValue(); 
// result = true

number = null;
result = number.HasValue();
// result = false
```
\
`GetValueOrEmpty (string)` \
Returns the value of a `nullable string` or an empty string if it's `null`.

`Usage Example:`
```csharp
string? inputString = "Hello";
var result = inputString.GetValueOrEmpty(); 
// result = "Hello"

inputString = null;
result = inputString.GetValueOrEmpty();
// result = ""
```
\
`GetValueOrEmpty (IEnumerable<T>)` \
Returns the value of a `nullable IEnumerable<T>` or an empty enumerable 
if it's `null`.

`Usage Example:`
```csharp
IEnumerable<int>? numbers = new List<int> { 1, 2, 3 };
var result = numbers.GetValueOrEmpty(); 
// result = [1, 2, 3]

numbers = null;
result = numbers.GetValueOrEmpty();
// result = []
```
\
`GetValueOrNew (without parameter)`\
Returns the value of a nullable type or a new instance of that type 
if it's `null`.

`Usage Example:`
```csharp
MyClass? myObject = new MyClass(param1, param2);
var result = myObject.GetValueOrNew(); 
// result = instance of MyClass with data from param1 and param2

myObject = null;
result = myObject.GetValueOrNew();
// result = new instance of MyClass
```
\
`GetValueOrNew (with parameter)`\
Returns the value of a nullable type or a specified default value 
if it's `null`.

`Usage Example:`
```csharp
MyClass? myObject = new MyClass(param1, param2);
var defaultValue = new MyClass(param3, param4);
var result = myObject.GetValueOrNew(defaultValue); 
// result = instance of MyClass with data from param1 and param2

myObject = null;
result = myObject.GetValueOrNew(defaultValue);
// result = defaultValue (instance provided as param3 and param4)
```
\
`Map`\
Transforms a value if it's not `null`, otherwise returns 
the default value of the result type.

`Usage Example:`
```csharp
int? number = 5;
var result = number.Map(n => n * 2); 
// result = 10

number = null;
result = number.Map(n => n * 2);
// result = 0 (default of int)

--------------------

MyClass? myObject = new MyClass(param1, param2);
var result = myObject.Map(o => ConverToClassB(o));
// result = instance of ClassB

myObject = null;
result = myObject.Map(o => ConverToClassB(o));
// result = null (default of ClassB)
```
\
`MapAsync`\
Asynchronously transforms a value if it's not `null`, 
otherwise returns the default value of the result type.

`Usage Example:`
```csharp
// Assuming `SomeAsyncFunction` is a method that takes an int and returns a Task<int>
int? number = 5;
var result = await number.MapAsync(n => SomeAsyncFunction(n)); 
// result depends on SomeAsyncFunction

number = null;
result = await number.MapAsync(n => SomeAsyncFunction(n));
// result = 0 (default of int)
```
\
`Match`\
Executes one of two functions based on the presence or absence of a value.

`Usage Example:`
```csharp
int? number = 5;
var result = number.Match(n => n * 2, 1);
// result = 10

number = null;
result = number.Match(n => n * 2, 1);
// result = 1

//--------------------

int? number = 5;
var result = number.Match(
    n => $"Value: {n}",
    () => "No value"
); 
// result = "Value: 5"

number = null;
result = number.Match(
    n => $"Value: {n}",
    () => "No value"
);
// result = "No value"
```
\
`MatchAsync`\
Asynchronously executes one of two functions based on the presence 
or absence of a value.

`Usage Example:`
```csharp
// Assuming `SomeAsyncFunction` and `DefaultValueAsync` are async methods
int? number = 5;
var result = await number.MatchAsync(
    n => SomeAsyncFunction(n),
    () => DefaultValueAsync()
); 
// result depends on SomeAsyncFunction

number = null;
result = await number.MatchAsync(
    n => SomeAsyncFunction(n),
    () => DefaultValueAsync()
);
// result depends on DefaultValueAsync
```
\
`Then`\
Executes one of two actions based on the presence or absence of a value.\
Different from `Match` in that it doesn't return a value.\
`Match` use `Func<T,Resut>` but\
`Then` use `Action<T>`.

`Usage Example:`
```csharp
int? number = 5;
number.Then(
    n => Console.WriteLine($"Value: {n}"),
    () => Console.WriteLine("No value")
); 
// Outputs: "Value: 5"

number = null;
number.Then(
    n => Console.WriteLine($"Value: {n}"),
    () => Console.WriteLine("No value")
);
// Outputs: "No value"
```
\
`ThenAsync`\
Asynchronously executes one of two actions based on the presence
or absence of a value.\

`Usage Example:`
```csharp
// Assuming `ProcessValueAsync` and `HandleNullAsync` are async methods
int? number = 5;
await number.ThenAsync(
    n => ProcessValueAsync(n),
    () => HandleNullAsync()
); 
// Executes ProcessValueAsync

number = null;
await number.ThenAsync(
    n => ProcessValueAsync(n),
    () => HandleNullAsync()
);
// Executes HandleNullAsync
```
\
***`Match And Then`***
> The Match and Then methods serve different purposes and are used
> in different scenarios, despite both dealing with nullable types.
> Here's a breakdown of their differences:
>
> `Match Method`\
> `Purpose:` The Match method is used to execute one of two provided
> functions based on whether the nullable type has a value or not.
> It's similar to a conditional statement, where you have an action for
> the "true" case (if the value exists) and another for the "false" case
> (if the value is null).\
> `Return Type:` It returns a value. The return type is determined by
> the functions provided to it. Both functions (ifSome and ifNone)
> must return the same type of result.\
> `Usage Scenario:` Use Match when you need to handle both the presence
> and absence of a value and each scenario needs to produce a result of
> the same type. It's particularly useful in functional programming
> paradigms where you want to transform the input based on its state
> (existing or non-existing).
>
> `Then Method`\
> `Purpose:` The Then method is used to perform an action if the nullable
> type has a value. Optionally, it can also perform a different action
> if the value is null. However, the focus is primarily on the case
> where the value exists.\
> `Return Type:` It does not produce a new value. Instead, it returns
> the original input, possibly unchanged. It's used for side effects
> (like logging or modifying external state) rather than transforming
> the input.\
> `Usage Scenario:` Use Then when your primary concern is to do something
> with the existing value, like performing a side effect.
> The optional handling of the null case is just an additional feature
> but not the main purpose of Then.
>
> In summary, use `Match` when you need to handle both presence
> and absence of a value and require a return value from this handling.
> Use `Then` when you want to perform an action (usually a side effect)
> when a value exists, and optionally handle the null case
> without expecting a return value.


`IfSome`\
Executes an action if a value is present.

`Usage Example:`
```csharp
int? number = 5;
number.IfSome(n => Console.WriteLine($"Value: {n}"));
// Outputs: "Value: 5"

number = null;
number.IfSome(n => Console.WriteLine($"Value: {n}"));
// No output
```
\
`IfSomeAsync`\
Asynchronously executes an action if a value is present.

`Usage Example:`
```csharp
// Assuming `ProcessValueAsync` is an async method
int? number = 5;
await number.IfSomeAsync(n => ProcessValueAsync(n));
// Executes ProcessValueAsync

number = null;
await number.IfSomeAsync(n => ProcessValueAsync(n));
// No output
```
\
`IfNone`\
Executes an action if a value is absent.

`Usage Example:`
```csharp
int? number = 5;
number.IfNone(() => Console.WriteLine("No value"));
// No output

number = null;
number.IfNone(() => Console.WriteLine("No value"));
// Outputs: "No value"
```

`IfNoneAsync`\
Asynchronously executes an action if a value is absent.

`Usage Example:`
```csharp
// Assuming `HandleNullAsync` is an async method
int? number = 5;
await number.IfNoneAsync(() => HandleNullAsync());
// No output

number = null;
await number.IfNoneAsync(() => HandleNullAsync());
// Executes HandleNullAsync
```

--------------------

### IEnumerable Extensions
The `IEnumerableExtension` class extends the capabilities of 
`IEnumerable<T>` collections in .NET, offering additional methods 
for enhanced functionality and usability.

### Methods
`ForEach`\
Performs a specified action on each element of the `IEnumerable<T>`.
This method is similar to the `ForEach` method of `List<T>`, but
it's available for all `IEnumerable<T>` collections.

`Usage Example:`
```csharp
var numbers = [1, 2, 3, 4, 5];
numbers.ForEach(n => Console.WriteLine(n));
// This will output:
// 1
// 2
// 3
// 4
// 5
```
This method is particularly useful for iterating over a collection 
and applying an action to each element, 
such as logging, modifying, or processing the items.

`IsIn`\
This method is particularly useful for iterating over a collection 
and applying an action to each element, such as logging, modifying, 
or processing the items.

`Usage Example:`
```csharp
int number = 3;
var numbers = new List<int> { 1, 2, 3, 4, 5 };
bool result = number.IsIn(numbers);
// result = true

number = 6;
result = number.IsIn(numbers);
// result = false

//--------------------

int number 3;
bool result = number.IsIn([1, 2, 3, 4, 5]);
// result = true
```
This method simplifies the process of checking if an item exists 
within a collection, making the code more readable and concise.



