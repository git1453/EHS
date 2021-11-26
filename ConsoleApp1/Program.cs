using Microsoft.Extensions.DependencyInjection;
using System;
using EHS.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Text;
using EHS.DataAccess.DAService;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "USER ID=SCOTT;Password=123456; DATA SOURCE=127.0.0.1:1521/ORCL;PERSIST SECURITY INFO=True";
            var serviceCollection = new ServiceCollection()
                .AddDataAccessService<EHS.DbContexts.EHSContext>(action:optionsBuilder=> optionsBuilder.UseOracle(a, b => b.UseOracleSQLCompatibility("11")));
            StringBuilder MyStringBuilder = new StringBuilder();
            foreach (var item in serviceCollection)
            {
                if(item.ServiceType.FullName.StartsWith("EHS"))
                MyStringBuilder.Append(nameof(item.ServiceType) + ":" + item.ServiceType + "\t")
                    .Append(nameof(item.ImplementationType) + ":" + item.ImplementationType + "\t")
                    .Append(nameof(item.ImplementationInstance) + ":" + item.ImplementationInstance + "\t")
                    .Append(nameof(item.Lifetime) + ":" + item.Lifetime + "\t")
                    .Append("\n");
            }
            Console.WriteLine(MyStringBuilder.ToString());
            var serviceProviders = serviceCollection.BuildServiceProvider();
            var s= serviceProviders.GetService<CourseModelService>();
            Console.WriteLine("Hello World!");
        }
    }
}
