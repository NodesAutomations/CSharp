# xUnit Assert Methods

## Boolean Assertions
- `Assert.True(condition)` - Asserts that a condition is true.
- `Assert.False(condition)` - Asserts that a condition is false.

## Equality Assertions
- `Assert.Equal(expected, actual)` - Asserts that two values are equal.
- `Assert.NotEqual(notExpected, actual)` - Asserts that two values are not equal.
- `Assert.StrictEqual(expected, actual)` - Asserts that two values are equal and of the same type.
- `Assert.NotStrictEqual(notExpected, actual)` - Asserts that two values are not equal or not of the same type.
- `Assert.Same(expected, actual)` - Asserts that two object references refer to the same object.
- `Assert.NotSame(notExpected, actual)` - Asserts that two object references do not refer to the same object.

## Null Assertions
- `Assert.Null(object)` - Asserts that an object is null.
- `Assert.NotNull(object)` - Asserts that an object is not null.

## Range Assertions
- `Assert.InRange(value, low, high)` - Asserts that a value is within a specified range.
- `Assert.NotInRange(value, low, high)` - Asserts that a value is outside a specified range.
- `Assert.InclusiveBetween(low, high, value)` - Asserts that a value is between low and high, inclusive.
- `Assert.ExclusiveBetween(low, high, value)` - Asserts that a value is between low and high, exclusive.

## String Assertions
- `Assert.Contains(substring, string)` - Asserts that a string contains a specified substring.
- `Assert.DoesNotContain(substring, string)` - Asserts that a string does not contain a specified substring.
- `Assert.StartsWith(prefix, string)` - Asserts that a string starts with a specified prefix.
- `Assert.EndsWith(suffix, string)` - Asserts that a string ends with a specified suffix.
- `Assert.Matches(pattern, string)` - Asserts that a string matches a specified regular expression pattern.
- `Assert.DoesNotMatch(pattern, string)` - Asserts that a string does not match a specified regular expression pattern.
- `Assert.EqualIgnoringCase(expected, actual)` - Asserts that two strings are equal, ignoring case.
- `Assert.NotEqualIgnoringCase(notExpected, actual)` - Asserts that two strings are not equal, ignoring case.

## Exception Assertions
- `Assert.Throws<TException>(action)` - Asserts that a specific exception of type TException is thrown.
- `Assert.ThrowsAny<TException>(action)` - Asserts that any exception of type TException is thrown.
- `Assert.DoesNotThrow(action)` - Asserts that no exception is thrown during the execution of the action.
- `Assert.Multiple(action)` - Asserts that multiple exceptions are thrown during the execution of the action.

## Collection Assertions
- `Assert.Contains(item, collection)` - Asserts that a collection contains a specified item.
- `Assert.DoesNotContain(item, collection)` - Asserts that a collection does not contain a specified item.
- `Assert.All(collection, action)` - Asserts that all items in a collection satisfy a specified condition.
- `Assert.Empty(collection)` - Asserts that a collection is empty.
- `Assert.NotEmpty(collection)` - Asserts that a collection is not empty.

## Type Assertions
- `Assert.IsType<T>(object)` - Asserts that an object is of a specified type T.
- `Assert.IsNotType<T>(object)` - Asserts that an object is not of a specified type T.
- `Assert.IsAssignableFrom<T>(object)` - Asserts that an object can be assigned to a variable of type T.
- `Assert.IsNotAssignableFrom<T>(object)` - Asserts that an object cannot be assigned to a variable of type T.

## DateTime Assertions
- `Assert.Equal(expected, actual, precision)` - Asserts that two DateTime values are equal within a specified precision.
- `Assert.NotEqual(expected, actual, precision)` - Asserts that two DateTime values are not equal within a specified precision.

## Miscellaneous Assertions
- `Assert.fail(message)` - Fails the test with a specified message.
- `Assert.Inconclusive(message)` - Marks the test as inconclusive with a specified message.
