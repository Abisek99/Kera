using HKCR.Application.Common.Interface;

namespace HKCR.Infra.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.UtcNow;
}