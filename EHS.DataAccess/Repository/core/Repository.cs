using AutoMapper;
using EHS.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHS.DataAccess.Repository
{
    public class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        protected readonly DbContext _dbContext;
        protected readonly IMapper _autoMapper;
        public Repository(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _autoMapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        }
        public virtual void Delete(TModel model)=> _dbContext.Set<TModel>().Remove(model);

        public virtual void Delete(params TModel[] models) => _dbContext.Set<TModel>().RemoveRange(models);

        public virtual void Delete(IEnumerable<TModel> models)=> _dbContext.Set<TModel>().RemoveRange(models);

        public virtual IEnumerable<TModel> GetAll() => _dbContext.Set<TModel>().AsNoTracking();

        public  virtual TModel Insert(TModel model) => _dbContext.Set<TModel>().Add(model).Entity;

        public virtual void Insert(params TModel[] models) => _dbContext.Set<TModel>().AddRange(models);

        public virtual void Insert(IEnumerable<TModel> models)=> _dbContext.Set<TModel>().AddRange(models);

        public  virtual void Update(TModel model)=> _dbContext.Set<TModel>().Update(model);  

        public virtual void Update(params TModel[] models)=> _dbContext.Set<TModel>().UpdateRange(models);

        public virtual void Update(IEnumerable<TModel> models) => _dbContext.Set<TModel>().UpdateRange(models);
    }
}
