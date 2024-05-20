using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TTechBasicInfo.Core.Contracts.Keywords.Commands.ActivateKeywords;
using TTechBasicInfo.Core.Contracts.Keywords.Commands.ChangeTitle;
using TTechBasicInfo.Core.Contracts.Keywords.Commands.CreateKeywords;
using TTechBasicInfo.Core.Contracts.Keywords.Commands.DiactivatedKeywords;
using TTechBasicInfo.Core.Contracts.Keywords.Queries.SearchTitle;
using Zamin.Core.RequestResponse.Queries;
using Zamin.EndPoints.Web.Controllers;

namespace TTechBasicInfo.Endpoints.API.Keywords;

[Route("api/[controller]/[action]")]
[ApiController]
public class KeywordsController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> SearchTitleAndStatus([FromQuery]SearchTitleAndStatusQuery query)
    {
        return await Query<SearchTitleAndStatusQuery , PagedData<KeywordSearchResult>>(query);
    }

    [HttpPost]
    public async Task<IActionResult> CreateKeyword(CreateKeywordCommand command)
    {
        return await Create<CreateKeywordCommand , long>(command);  
    }

    [HttpPut]
    public async Task<IActionResult> ChangeTitle(ChangeTitleCommand command)
    {
        return await Edit(command);
    }

    [HttpPut]
    public async Task<IActionResult> ActivateKeyword(ActivateKeywordCommand command)
    {
        return await Edit(command);
    }

    [HttpPut]
    public async Task<IActionResult> DiactivateKeyword(DeactivateKeywordCommand command)
    {
        return await Edit(command);
    }
}
