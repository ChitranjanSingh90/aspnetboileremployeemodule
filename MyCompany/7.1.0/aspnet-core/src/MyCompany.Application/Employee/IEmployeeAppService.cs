using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompany.Roles.Dto;


    public interface IEmployeeAppService :  IAsyncCrudAppService<EmployeeDto, int, PagedEmployeeResultRequestDto, CreateEmployeeDto, UpdateEmployeeDto>
{
     //Task<EmployeeDto> CreateAsync(CreateEmployeeDto input);

    //Task<EmployeeDto> UpdateAsync(UpdateEmployeeDto input);

    //Task DeleteAsync(EntityDto<int> input);

}

