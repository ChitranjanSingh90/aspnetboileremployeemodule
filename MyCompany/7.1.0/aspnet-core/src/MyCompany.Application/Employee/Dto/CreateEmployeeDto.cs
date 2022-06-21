using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Roles;
using Abp.AutoMapper;
using MyCompany.Authorization.Roles;

[AutoMapTo(typeof(Employee))]
public class CreateEmployeeDto
    {
    //[Required]
    //[StringLength(AbpRoleBase.MaxNameLength)]
    //public string FirstName { get; set; }

    //[Required]
    //[StringLength(AbpRoleBase.MaxNameLength)]
    //public string LastName { get; set; }
    //public string Title { get; set; }
    //[Required]
    //public int Salary { get; set; }



    public string FirstName { get; set; }


    public string LastName { get; set; }
    public string Title { get; set; }

    public int Salary { get; set; }
}
