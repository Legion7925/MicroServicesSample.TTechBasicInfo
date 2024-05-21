using TTechBasicInfo.Core.Domain.Categories.Entities;
using TTechBasicInfo.Core.Domain.Common.ValueObjects;
using Zamin.Core.Domain.Exceptions;

namespace TTechBasicInfo.Core.Domain.Test.Common.ValueObjects;

public class TinyStringTest
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("123456789012345678901234567890123456789012345678901234567890")]
    public void WhenTinyStringIsInvalid_Should_ThrowInvalidValueObjectStateException(string value)
    {
        //Act
        TinyString tinyString;

        //Assert
        Assert.Throws<InvalidValueObjectStateException>(() => tinyString = new TinyString(value));      
    }
}
