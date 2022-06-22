using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using Abp.AutoMapper;
using MyCompany.Authorization.Roles;

[AutoMapTo(typeof(Employee))]
public class UpdateEmployeeDto : EntityDto<int>
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    [Required]
    public int Salary { get; set; }

    public bool Status { get; set; }

}
