using HKCR.Application.Common.DTO;
using HKCR.Application.Common.DTO.Document;
using HKCR.Application.Common.Interface;
using HKCR.Infra.Services;
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

    [HttpGet]
    [Route("/api/v1/docs")]
    public async Task<List<DocResponseDto>> GetAllDocDetails()
    {
        var data = await _docDetails.GetAllDocsAsync();
        return data;
    }

    [HttpPost]
    [Route("/api/v1/docs")]
    public async Task<DocResponseDto> AddDocDetails(DocRequestDto doc)
    {
        var data = await _docDetails.AddDocDetails(doc);
        return data;
    }
}