using Amazon.Lambda.Annotations;
using ApiSeriesAWSCRUD.Data;
using ApiSeriesAWSCRUD.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiSeriesAWSCRUD;

[LambdaStartup]
public class Startup
{
    /// <summary>
    /// Services for Lambda functions can be registered in the services dependency injection container in this method. 
    ///
    /// The services can be injected into the Lambda function through the containing type's constructor or as a
    /// parameter in the Lambda function using the FromService attribute. Services injected for the constructor have
    /// the lifetime of the Lambda compute container. Services injected as parameters are created within the scope
    /// of the function invocation.
    /// </summary>
    public void ConfigureServices(IServiceCollection services)
    {
        string connectionString = @"server=mysqlrdsjra.c4rw82gcesy0.us-east-1.rds.amazonaws.com;port=3306;user id=adminsql;password=Admin123;database=series";
        services.AddTransient<RepositorySeries>();
        services.AddDbContext<SeriesContext>(options => options.UseMySQL(connectionString));

    }
}
