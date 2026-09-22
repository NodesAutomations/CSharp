# NewtonSoft.Json

## Serializing

### Basic Example
- To serialize an object into a JSON string, you can use the `JsonConvert.SerializeObject` method.
```csharp
User user = new User
{
    UserId = 12345,
    UserName = "john_doe",
    Email = "john.doe@example.com"
};

string json = JsonConvert.SerializeObject(user);
Console.WriteLine(json);
```
```csharp
public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}
```
```json
{"UserId":12345,"UserName":"john_doe","Email":"john.doe@example.com"}
```
### Formatting Options
- You can control the formatting of the JSON output using the `Formatting` enum.

```csharp
string json = JsonConvert.SerializeObject(user, Formatting.Indented);
Console.WriteLine(json);
```
```json
{
  "UserId": 12345,
  "UserName": "john_doe",
  "Email": "john.doe@example.com"
}
```

### Using JsonProperty Attribute
```csharp
public class User
{
  [JsonProperty("user_id")]
  public int UserId { get; set; }

  [JsonProperty("user_name")]
  public string UserName { get; set; }

  [JsonProperty("email_address")]
  public string Email { get; set; }
}
```
```json
{
  "user_id": 12345,
  "user_name": "john_doe",
  "email_address": "john.doe@example.com"
}
```

### Handling Null Values
- By default, `JsonConvert.SerializeObject` includes properties with `null` values in the JSON output.
- You can use the `NullValueHandling` setting to control this behavior.

```csharp
User user = new User
{
    UserId = 12345,
    UserName = "john_doe",
    Email = null
};

string json = JsonConvert.SerializeObject(user, new JsonSerializerSettings
{
    NullValueHandling = NullValueHandling.Ignore
});
Console.WriteLine(json);
```
```json
{
  "UserId": 12345,
  "UserName": "john_doe"
}
```

### Custom Converters
- For more complex scenarios, you can create custom converters by inheriting from JsonConverter. This allows you to define custom serialization logic:

```csharp
public class DateTimeConverter : JsonConverter<DateTime>
{
  private readonly string _format = "yyyy-MM-dd";

  public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
  {
    writer.WriteValue(value.ToString(_format));
  }

  public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
  {
    return DateTime.ParseExact((string)reader.Value, _format, null);
  }
}
```
```csharp
[JsonConverter(typeof(DateTimeConverter))]
public DateTime DateOfBirth { get; set; }
```
```json
{
  "UserId": 12345,
  "UserName": "john_doe",
  "Email": "john.doe@example.com",
  "DateOfBirth": "1992-06-28"
}
```

## Load Data from Json file


## Serialize and Deserialize Objects


## Attributes

### JsonProperty
- The `JsonProperty` attribute is used to specify the name of the property in the JSON representation.
- You can use it to map a property to a different name in the JSON output.

### JsonIgnore
- The `JsonIgnore` attribute is used to prevent a property from being serialized or deserialized.
- You can use it to exclude specific properties from the JSON representation of an object.
- Use case is to ignore calculated properties 

