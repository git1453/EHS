using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper.Collection;
using AutoMapper.EntityFrameworkCore;
using System.Reflection;
using AutoMapper.EquivalencyExpression;

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
        /// <param name="action"></param>
        /// <param name="poolSize">连接池大小</param>
        /// <remarks>此方法仅支持一个db上下文，如果多次调用，将抛出异常。</remarks>
        /// <returns></returns>
        public static IServiceCollection AddUnitOfWorkService<TContext>(this IServiceCollection services, System.Action<DbContextOptionsBuilder> action, int poolSize = 128) where TContext : DbContext
        {
            services.AddAutoMapper(typeof(mapper));

            //注册dbcontext
            services.AddDbContextPool<TContext>(action,poolSize);
            //注册工作单元
            services.AddScoped<IUnitOfWork<TContext>, UnitOfWork<TContext>>();
            services.AddAutoMapper((serviceProvider, automapper) =>
            {
                automapper.AddCollectionMappers();
                automapper.UseEntityFrameworkCoreModel<TContext>(serviceProvider);
            }, typeof(TContext).Assembly);
            return services;
        }

    }
}
