using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization.Roles;
using Abp.AutoMapper;


public class EmployeeListDto : EntityDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public int Salary { get; set; }

}

