using HKCR.Domain.Shared;

namespace HKCR.Application.Common.DTO.Document;

public class DocResponseDto
{
    public Guid DocId { get; set; }
    public string DocType { get; set; }
    public string DocImage { get; set; }
}