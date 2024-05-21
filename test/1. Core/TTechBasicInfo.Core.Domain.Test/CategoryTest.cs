using TTechBasicInfo.Core.Domain.Categories.Entities;
using TTechBasicInfo.Core.Domain.Categories.Events;
using TTechBasicInfo.Core.Domain.Categories.ValueObjects;
using Zamin.Core.Domain.Exceptions;

namespace TTechBasicInfo.Core.Domain.Test;

public class CategoryTest
{
    [Fact]
    public void CategoryCreated_WhenAll_InputsAreValid()
    {
        //Arrange
        CategoryName name = new ("Sport");
        CategoryTitle title = new ("ورزش");

        //Act
        Category category = new (name, title);

        //Assert
        Assert.NotNull(category);
        var categoryCreatedEvent = category.GetEvents().Where(c=> c.GetType() == typeof(CategoryCreatedEvent)).FirstOrDefault() as CategoryCreatedEvent;
        Assert.NotNull(categoryCreatedEvent);
        Assert.Equal(title, category.Title);
        Assert.Equal(name, category.Name);
        Assert.Equal(name.Value, categoryCreatedEvent.Name);
        Assert.Equal(name.Value, categoryCreatedEvent.Name);
    }
}
