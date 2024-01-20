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
`GetValueOrNew<T> (without parameter)`\
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
`GetValueOrNew<T> (with parameter)`\
Returns the value of a nullable type or a specified default value 
if it's `null`.

`Usage Example:`
```csharp
MyClass? myObject = new MyClass(param1, param2);
var defaultValue = new MyClass(param3);
var result = myObject.GetValueOrNew(defaultValue); 
// result = instance of MyClass with data from param1 and param2

myObject = null;
result = myObject.GetValueOrNew(defaultValue);
// result = defaultValue (instance provided as parameter)
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