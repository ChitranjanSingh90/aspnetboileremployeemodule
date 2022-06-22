using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyCompany.Configuration;
using MyCompany.Web;

namespace MyCompany.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MyCompanyDbContextFactory : IDesignTimeDbContextFactory<MyCompanyDbContext>
    {
        public MyCompanyDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyCompanyDbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MyCompanyDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MyCompanyConsts.ConnectionStringName));

            return new MyCompanyDbContext(builder.Options);
        }
    }
}
