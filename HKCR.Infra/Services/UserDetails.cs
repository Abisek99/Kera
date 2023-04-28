using HKCR.Application.Common.DTO;
using HKCR.Application.Common.Interface;
using HKCR.Domain.Entities;

namespace HKCR.Infra.Services;

public class UserDetails : IUserDetails
{
    private readonly IApplicationDbContext _dbContext;

    public UserDetails(IApplicationDbContext dBContext)
    {
        _dbContext = dBContext;
    }


    // nonsense 
    public Task<List<UserResponseDto>> GetAllUserAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<UserResponseDto>> GetAllUser()
    {
        throw new NotImplementedException();
    }


    public async Task<UserResponseDto> AddUserDetails(UserRequestDto user)
    {
        var userDetails = new User()
        {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password
        };
        await _dbContext.User.AddAsync(userDetails);
        await _dbContext.SaveChangesAsync(default(CancellationToken));

        var result = new UserResponseDto()
        {
            Role = userDetails.Role,
            Phone = userDetails.Phone,
            Address = userDetails.Address
        };
        return result;
    }


    public async Task<UserResponseDto> AddUserDetailsAsync(UserResponseDto user)
    {
        var userDetails = new User()
        {
            Name = user.Name,
            Email = user.Email,
            Password = user.Password
            // JoinDate = employee.JoinDate,
            // Designation = employee.Designation,
            // Salary = employee.Salary,
            // DepartmentId = employee.DepartmentId
        };
        await _dbContext.User.AddAsync(userDetails);
        await _dbContext.SaveChangesAsync(default(CancellationToken));

        var result = new UserResponseDto()
        {
            Role = userDetails.Role,
            Phone = userDetails.Phone,
            Address = userDetails.Address
        };
        return result;
    }
}