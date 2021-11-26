using AutoMapper;
using ClassLib;
using EHS.DbContexts;
using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EHS.DataAccess.DAService.Core
{
    public class ModelDAService<TModel> : BaseDAService, IModelDAService<TModel> where TModel : BaseModel
    {
        public ModelDAService(EHSContext dbContext) : base(dbContext)
        {
        }

        public ModelDAService(EHSContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public virtual void Delete(TModel model) => _dbContext.Set<TModel>().Remove(model);

        public virtual void Delete(params TModel[] models) => _dbContext.Set<TModel>().RemoveRange(models);

        public virtual void Delete(IEnumerable<TModel> models) => _dbContext.Set<TModel>().RemoveRange(models);

        public virtual IEnumerable<TModel> GetAll() => _dbContext.Set<TModel>().AsNoTracking();

        public virtual TModel Insert(TModel model) => _dbContext.Set<TModel>().Add(model).Entity;

        public virtual void Insert(params TModel[] models) => _dbContext.Set<TModel>().AddRange(models);

        public virtual void Insert(IEnumerable<TModel> models) => _dbContext.Set<TModel>().AddRange(models);

        public virtual void Update(TModel model) => _dbContext.Set<TModel>().Update(model);

        public virtual void Update(params TModel[] models) => _dbContext.Set<TModel>().UpdateRange(models);

        public virtual void Update(IEnumerable<TModel> models) => _dbContext.Set<TModel>().UpdateRange(models);
    }
}
