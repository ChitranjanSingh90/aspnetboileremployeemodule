
using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using MyCompany.Authorization;


[AbpAuthorize(PermissionNames.Pages_Employees)]
public class EmployeeAppService : AsyncCrudAppService<Employee, EmployeeDto, int, PagedEmployeeResultRequestDto, CreateEmployeeDto, UpdateEmployeeDto>, IEmployeeAppService
{
    private readonly IRepository<Employee> _employeeRepository;
    private readonly IObjectMapper _objectMapper;

    public EmployeeAppService(IRepository<Employee> repository,IObjectMapper objectMapper)
            : base(repository)
    {
        _employeeRepository = repository;
        _objectMapper = objectMapper;
    }


    public override async Task<EmployeeDto> CreateAsync(CreateEmployeeDto input)
    {
        var role = ObjectMapper.Map<Employee>(input);
        await _employeeRepository.InsertAsync(role);
        return MapToEntityDto(role);

    }

    public override async Task<EmployeeDto> UpdateAsync(UpdateEmployeeDto input)
    {
        var user = _objectMapper.Map<Employee>(input);
        await _employeeRepository.UpdateAsync(user);
        return await GetAsync(input);
    }

    public override async Task DeleteAsync(EntityDto<int> input)
    {
        var person = await _employeeRepository.GetAsync(input.Id);

        await _employeeRepository.DeleteAsync(person);
    }

    public async Task<Employee> GetEmployeeForEdit(EntityDto input)
    {

        var role = await _employeeRepository.GetAsync(input.Id);

        var roleEditDto = ObjectMapper.Map<Employee>(role);

        return roleEditDto;
    }


    protected override IQueryable<Employee> CreateFilteredQuery(PagedEmployeeResultRequestDto input)
    {
        
        IQueryable<Employee> matchingvalues = null;
        var list = _employeeRepository.GetAll();

        if (!string.IsNullOrWhiteSpace(input.Keyword))
        {
            string inputVar = input.Keyword.ToLower();

            matchingvalues = list.Where(stringToCheck => ((stringToCheck.FirstName.ToLower()).Contains(inputVar) || (stringToCheck.LastName.ToLower()).Contains(inputVar)
                             || (stringToCheck.Title.ToLower()).Contains(inputVar) ||  Convert.ToString(stringToCheck.Salary).Contains(inputVar)));

        }
        else
        {
            matchingvalues = list;
        }
        return matchingvalues;
    }


}



