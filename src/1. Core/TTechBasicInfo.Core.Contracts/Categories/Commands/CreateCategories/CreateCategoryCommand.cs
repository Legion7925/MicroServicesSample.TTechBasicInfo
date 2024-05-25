using System.Windows.Input;
using Zamin.Core.RequestResponse.Commands;

namespace TTechBasicInfo.Core.Contracts.Categories.Commands.CreateCategories;

public class CreateCategoryCommand : ICommand<long>
{
    public string Title { get; set; }

    public string Name { get; set; }
}
