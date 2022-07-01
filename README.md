# MathParser
This Library can parse a string to a Function object in c#

for example:
```C#
  const string sValue = "2*sin(t)";
  var function = sValue.ToFunction();
  var value = function.GetValue(new Param("t", 0));
  var dFunction = function.GetDerivative("t");
  var value2 =dFunction.GetValue(new Param("t", 0));
  Assert.AreEqual(value, 0.0f);
  value = function.GetValue(new Param("t", (float)(Math.PI/2)));
  Assert.AreEqual(value, 2.0f);
  Assert.AreEqual(value2,2.0f);
```

the doc is generate by 
```
dotnet document apply
```

there is two main api class for this library
```
1.StaticTool
2.Function
```
