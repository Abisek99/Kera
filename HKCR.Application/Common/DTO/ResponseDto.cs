namespace HKCR.Application.Common.DTO;

public class ResponseDto
{
    public string? Status { get; set; }
    public string? Message { get; set; }
    public string? Token { get; set; }
}

public class ErrorMessageResponse
{
    public string? Message { get; set; }
    public string? ContentType { get; set; }
    public int StatusCode { get; set; }
}