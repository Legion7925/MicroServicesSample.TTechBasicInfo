using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TTechBasicInfo.Core.Contracts.Keywords.Commands.CreateKeywords;
using Zamin.EndPoints.Web.Controllers;

namespace TTechBasicInfo.Endpoints.API.Keywords
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeywordsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateKeywordCommand command)
        {
            return await Create<CreateKeywordCommand , long>(command);  
        }
    }
}
