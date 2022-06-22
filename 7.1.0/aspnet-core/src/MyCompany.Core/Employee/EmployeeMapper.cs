
using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using Abp.Domain.Entities;
using MyCompany.Authorization.Users;

public class EmployeeMapper :  AbpRole<User>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }
             
    }

