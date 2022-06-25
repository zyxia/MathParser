# MathParser
This Library can parse a string to a Fucntion object in c#

for example:
```
const string sValue = "2*sin(t)";
var value = sValue.ToFunction().GetValue(new Param("t", 0));
Assert.AreEqual(value, 0.0f);
```