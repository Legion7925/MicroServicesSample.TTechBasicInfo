using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TTechBasicInfo.Core.Contracts.Categories.Commands.CreateCategories;
using Zamin.EndPoints.Web.Controllers;

namespace TTechBasicInfo.Endpoints.API.Categories
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            return await Create<CreateCategoryCommand, long>(command);
        }
    }
}
