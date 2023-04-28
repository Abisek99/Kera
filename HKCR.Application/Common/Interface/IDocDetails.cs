using HKCR.Application.Common.DTO;
using HKCR.Application.Common.DTO.Document;

namespace HKCR.Application.Common.Interface;

public interface IDocDetails
{
    Task<List<DocResponseDto>> GetAllDocsAsync();
    Task<List<DocResponseDto>> GetAllDocs();
    Task<DocResponseDto> AddDocDetails(DocRequestDto car);
}