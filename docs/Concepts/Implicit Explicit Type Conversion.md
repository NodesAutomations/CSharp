### Type Conversion

```csharp
//Implicit Type Conversion
byte b=1;
int i=b;

//Explicit Type Conversion
int i=1;
byte b=i; //This Won't Compile
byte b=(byte)i;
```

As per above Code if we assign byte var to int var it will work because byte only take 1 byte of memory and integer takes 4 bytes. this is called implicit type conversion. When we convert integer to byte program it won't compile because of data loss. if we still need to compile that we need to tell compiler that we are ok with data loss using  `byte b=(byte)i;` This is Called Explicit Type Conversion. This also Called Casting.

### Non Compatible type

```csharp
string s = "1";
int i = (int)s;//This won't Compile
int i = Convert.ToInt32(s);
int j = int.Parse(s);
```

So as per above code we can't convert string to integer explicitly to integer. We need to use `convert.ToInt32(string)` or `int.parse(string)` method for Explicit conversation.

<aside>
⚠️ When We use convert String to integer and if value is more than integer can hold Program will throw runtime exception.

</aside>
