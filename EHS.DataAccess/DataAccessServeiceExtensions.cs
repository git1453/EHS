using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EHS.DataAccess
{
    public static class DataAccessServeiceExtensions
    {
        /// <summary>
        /// 在<see cref ="IServiceCollection"/>中注册给定上下文作为服务的工作单元。
        /// 同时注册了dbcontext
        /// </summary>
        /// <typeparam name="TContext"></typeparam>
        /// <param name="services"></param>
        /// <param name="action"><example>opt=>opt.UseOracle(connectionstring, b => b.UseOracleSQLCompatibility("11"))</example></param>
        /// <param name="poolSize">连接池大小</param>
        /// <remarks>此方法仅支持一个db上下文，如果多次调用，将抛出异常。</remarks>
        /// <returns></returns>
        public static IServiceCollection AddDataAccessService<TContext>(this IServiceCollection services, System.Action<DbContextOptionsBuilder> action, int poolSize = 128) where TContext : DbContext
        {
            services.AddAutoMapper(typeof(mapperconfig));
            services.AddEntityFrameworkOracle();
            //注册dbcontext
            //action: opt=>opt.UseOracle(connectionstring, b => b.UseOracleSQLCompatibility("11"))
            services.AddDbContextPool<TContext>(action, poolSize);
            services.AddAutoMapper((serviceProvider, automapper) =>
            {
                automapper.AddCollectionMappers();
                automapper.UseEntityFrameworkCoreModel<TContext>(serviceProvider);
            }, typeof(TContext).Assembly);


            string location = Assembly.GetExecutingAssembly().Location;
            Assembly assembly = Assembly.Load(AssemblyName.GetAssemblyName(location));
            List<Type> ts = assembly.GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.Name.EndsWith("Service")).ToList();
            foreach (var item in ts)
            {
                services.AddScoped(item);
            }
            return services;
        }

    }
}
