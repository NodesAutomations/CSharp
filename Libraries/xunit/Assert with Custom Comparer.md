```csharp
using System;
using System.Collections.Generic;
using Xunit;

public class EqualExample
{
    class DateComparer : IEqualityComparer<DateTime>
    {
        public bool Equals(DateTime x, DateTime y)
        {
            return x.Date == y.Date;
        }

        public int GetHashCode(DateTime obj)
        {
            return obj.GetHashCode();
        }
    }

    [Fact]
    public void DateShouldBeEqualEvenThoughTimesAreDifferent()
    {
        DateTime firstTime = DateTime.Now.Date;
        DateTime later = firstTime.AddMinutes(90);

        Assert.NotEqual(firstTime, later);
        Assert.Equal(firstTime, later, new DateComparer());
    }
}
```
