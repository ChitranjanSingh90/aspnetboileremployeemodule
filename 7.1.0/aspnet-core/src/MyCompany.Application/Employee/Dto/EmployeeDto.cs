using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using Abp.AutoMapper;


[AutoMapFrom(typeof(Employee))]
public class EmployeeDto : EntityDto<int>
    {
    //public string FirstName { get; set; }
    //public string LastName { get; set; }
    //public string Title { get; set; }
    //public int Salary { get; set; }

    [Required]
    [StringLength(AbpRoleBase.MaxNameLength)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(AbpRoleBase.MaxNameLength)]
    public string LastName { get; set; }
    public string Title { get; set; }
    [Required]
    public int Salary { get; set; }

    public bool Status { get; set; }

}

