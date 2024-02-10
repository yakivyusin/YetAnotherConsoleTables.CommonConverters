# YetAnotherConsoleTables.CommonConverters [![NuGet](https://img.shields.io/nuget/v/YetAnotherConsoleTables.CommonConverters.svg)](https://www.nuget.org/packages/YetAnotherConsoleTables.CommonConverters/) [![Made in Ukraine](https://img.shields.io/badge/made_in-ukraine-ffd700.svg?labelColor=0057b7)](https://stand-with-ukraine.pp.ua)
The set of common table member converters for the [YetAnotherConsoleTables](https://github.com/yakivyusin/YetAnotherConsoleTables) library.

**Converters**
- Root namespace
  - [FormattableConverter](#formattableconverter)
  - Chain namespace
    - [ChainedConverter](#chainedconverter)
  - StringReplace namespace
    - [StringReplaceConverter](#stringreplaceconverter)
    - [RegexReplaceConverter](#regexreplaceconverter)
  - ValueChange namespace
    - [AppendValueConverter](#appendvalueconverter)
    - [PrependValueConverter](#prependvalueconverter)
    - [WrapValueConverter](#wrapvalueconverter)
  - Enumerable namespace
    - [EnumerableFirstConverter](#enumerablefirstconverter)
    - [EnumerableLastConverter](#enumerablelastconverter)
    - [EnumerableJoinConverter](#enumerablejoinconverter)

## AppendValueConverter
Append a suffix to member values. Any object of attribute parameter types can be used as the suffix.
```
class Box
{
    [TableMemberConverter<AppendValueConverter>(ConstructorArgs = new[] { " kg" })]
    public double Weight { get; set; } = 100;
}
```
```
----------
| Weight |
----------
| 100 kg |
----------
```

## PrependValueConverter
Prepend a prefix to member values. Any object of attribute parameter types can be used as the prefix.
```
class Box
{
    [TableMemberConverter<PrependValueConverter>(ConstructorArgs = new[] { "UAH: " })]
    public double Price { get; set; } = 1000;
}
```
```
-------------
| Price     |
-------------
| UAH: 1000 |
-------------
```

## WrapValueConverter
Prepend a prefix and append a suffix to member values at the same time. You can achieve the same behavior with a [ChainedConverter](#chainedconverter), but this one will run faster. Any objects of attribute parameter types can be used as the prefix and the suffix.
```
class Box
{
    [TableMemberConverter<WrapValueConverter>(ConstructorArgs = new[] { "UAH ", " per item" })]
    public int DiscountPerItem { get; set; } = 5;
}
```
```
-------------------
| DiscountPerItem |
-------------------
| UAH 5 per item  |
-------------------
```

## FormattableConverter
Convert an object that implements `IFormattable` using the `ToString()` method of this interface.
```
class Box
{
    [TableMemberConverter<FormattableConverter>(ConstructorArgs = new[] { "P2" })]
    public double Discount { get; set; } = 0.05;
	
    [TableMemberConverter<FormattableConverter>(ConstructorArgs = new[] { "C2", "en-US" })]
    public double Price { get; set; } = 900;
}
```
```
----------------------
| Discount | Price   |
----------------------
| 5.00 %   | $900.00 |
----------------------
```

## StringReplaceConverter
Find all occurrences of a specified string and replace them with another specified string.
```
class Box
{
    [TableMemberConverter<StringReplaceConverter>(ConstructorArgs = new[] { "<br/>", "\r\n" })]
    public string HtmlDescription { get; set; } = "Description<br/>Description";
}
```
```
-------------------
| HtmlDescription |
-------------------
| Description     |
| Description     |
-------------------
```

## RegexReplaceConverter
Replace all strings that match a specified pattern with a specified replacement string.
```
class User
{
    [TableMemberConverter<RegexReplaceConverter>(ConstructorArgs = new[] { ".", "*" })]
    public string Password { get; set; } = "qwerty";
}
```
```
------------
| Password |
------------
| ******   |
------------
```

## ChainedConverter
Combine two or more converters in a chain. Out of the box, converters are available that combine 2 to 5 other converters. If you need to combine more than 5 converters, the `ChainedConverter` can be nested in another.
```
class Box
{
    [TableMemberConverter<ChainedConverter<FormattableConverter, AppendValueConverter>>(ConstructorArgs = new object[] { new[] { "C" }, new[] { " per item" }})]
    public int Discount { get; set; } = 5;
}
```
```
------------------
| Discount       |
------------------
| ¤5.00 per item |
------------------
```
## EnumerableFirstConverter
Use the first element of the `IEnumerable`. The first element can be retrieved using `FirstOrDefault` or `First` LINQ method.
```
class Student
{
    [TableMember(DisplayName = "First Mark")]
    [TableMemberConverter<EnumerableFirstConverter<string>>]
    public string[] Marks { get; set; } = new[] { "A", "A", "F" };
}
```
```
--------------
| First Mark |
--------------
| A          |
--------------
```

## EnumerableLastConverter
Use the last element of the `IEnumerable`. The last element can be retrieved using `LastOrDefault` or `Last` LINQ method.
```
class Student
{
    [TableMember(DisplayName = "Last Mark")]
    [TableMemberConverter<EnumerableLastConverter<string>>]
    public string[] Marks { get; set; } = new[] { "A", "A", "F" };
}
```
```
------------
| Last Mark |
-------------
| F         |
-------------
```

## EnumerableJoinConverter
Join all elements of the `IEnumerable` using the passed separator.
```
class Student
{
    [TableMemberConverter<EnumerableJoinConverter<string>>(ConstructorArgs = new object[] { ", " })]
    public string[] Marks { get; set; } = new[] { "A", "A", "F" };
}
```
```
-----------
| Marks   |
-----------
| A, A, F |
-----------
```
