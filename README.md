# MathParser
This Library can parse a string to a Fucntion object in c#

for example:
```
const string sValue = "2*sin(t)";
var value = sValue.ToFunction().GetValue(new Param("t", 0));
Assert.AreEqual(value, 0.0f);
```

the doc is generate by 
```
dotnet document apply
```
there is two main api class for this library
1.StaticTool
2.Function