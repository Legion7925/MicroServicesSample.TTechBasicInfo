using TTechBasicInfo.Core.Domain.Categories.Entities;
using Zamin.Core.Domain.Exceptions;

namespace TTechBasicInfo.Core.Domain.Test;

public class CategoryTest
{
    [Fact]
    public void CategoryCreated_WhenAll_InputsAreValid()
    {
        //Arrange
        string name = "Sport";
        string title = "ورزش";

        //Act
        Category category = new Category(name, title);

        //Assert
        Assert.NotNull(category);
        Assert.Equal(title, category.Title);
        Assert.Equal(name, category.Name);
    }
}
