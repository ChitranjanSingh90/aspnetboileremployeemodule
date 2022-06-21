
using Abp.Authorization.Roles;
using MyCompany.Authorization.Users;

namespace MyCompany.Authorization.Employees
{
    public class Employee : AbpRole<User>
    {
        public Employee()
        {
        }

        public Employee(int? tenantId, string displayName)
            : base(tenantId, displayName)
        {
        }

        public Employee(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
        {
        }

        public string Description { get; set; }
    }
}
