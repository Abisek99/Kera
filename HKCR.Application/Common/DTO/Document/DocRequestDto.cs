using HKCR.Domain.Shared;

namespace HKCR.Application.Common.DTO.Document;

public class DocRequestDto
{
    public DocumentType DocType { get; set; }
    public string DocImage { get; set; }
}