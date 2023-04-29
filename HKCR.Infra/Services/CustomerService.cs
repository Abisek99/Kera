//using HKCR.Application.Common.DTO;
//using HKCR.Application.Common.DTO.Customer;
//using HKCR.Application.Common.Interface;
//using HKCR.Domain.Entities;
//using HKCR.Infra.Migrations;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HKCR.Infra.Services
//{
//    public class CustomerService : ICustomerDetails
//    {
//        private readonly IApplicationDbContext _dbContext;

//        public CustomerService(IApplicationDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public Task<CustomerResponseDto> AddCustomerDetails(CustomerRequestDto customer)
//        {
//            var costumerDetails = new Customer()
//            {
//                CustomerDiscount = customer.CustomerDiscount,

//            };

//            await _dbContext.customer.AddAsync(CustomerService);
//            await _dbContext.SaveChangesAsync(default(CancellationToken));

//            var result = new CarResponseDto()
//            {
//                CustomerDiscount = customer.CustomerDiscount,
                
//            return result;
//        }

//        public Task<List<CustomerResponseDto>> GetAllCustomer()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<List<CustomerResponseDto>> GetAllCustomerAsync()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
