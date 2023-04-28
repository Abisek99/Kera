using HKCR.Application.Common.DTO.Document;
using HKCR.Application.Common.Interface;
using Microsoft.AspNetCore.Mvc;

namespace HKCR.API.Controllers;

[ApiController]
public class DocController : ControllerBase
{
    private readonly IDocDetails _docDetails;

    public DocController(IDocDetails docDetails)
    {
        _docDetails = docDetails;
    }

    [HttpPost]
    [Route("/api/v1/docs")]
    public async Task<DocResponseDto> AddDocDetails(DocRequestDto doc)
    {
        var data = await _docDetails.AddDocDetails(doc);
        return data;
    }
}