
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;




public class Employee:Entity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }

      public bool Status { get; set; }

}

