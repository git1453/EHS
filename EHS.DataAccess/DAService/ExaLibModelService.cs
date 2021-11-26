using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClassLib;
using EHS.DataAccess.DAService.Core;
using EHS.DbContexts;
using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EHS.DataAccess.DAService
{
    public class ExaLibModelService : ModelDAService<ExaLibModel>
    {
        public ExaLibModelService(EHSContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override void Delete(ExaLibModel model)
        {
            var entity = _autoMapper.Map<EhsLib>(model);
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public override void Delete(params ExaLibModel[] models)
        {
            var entity = _autoMapper.Map<EhsLib[]>(models);
            _dbContext.RemoveRange(entity);
            _dbContext.SaveChanges();
        }

        public override void Delete(IEnumerable<ExaLibModel> models)
        {
            var entity = _autoMapper.Map<IEnumerable<EhsLib>>(models);
            _dbContext.RemoveRange(entity);
            _dbContext.SaveChanges();
        }

        public override IEnumerable<ExaLibModel> GetAll() => _dbContext.EhsLibs.AsNoTracking().ProjectTo<ExaLibModel>(_autoMapper.ConfigurationProvider).AsEnumerable();

        public override ExaLibModel Insert(ExaLibModel model)
        {
            var entity = _autoMapper.Map<EhsLib>(model);
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return _autoMapper.Map<ExaLibModel>(entity);
        }

        public override void Insert(params ExaLibModel[] models)
        {
            var entity = _autoMapper.Map<EhsLib[]>(models);
            _dbContext.AddRange(entity);
            _dbContext.SaveChanges();
        }

        public override void Insert(IEnumerable<ExaLibModel> models)
        {
            var entity = _autoMapper.Map<IEnumerable<EhsLib>>(models);
            _dbContext.AddRange(entity);
            _dbContext.SaveChanges();
        }

        public override void Update(ExaLibModel model)
        {
            var entity = _autoMapper.Map<EhsLib>(model);
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public override void Update(params ExaLibModel[] models)
        {
            var entities = _autoMapper.Map<ExaLibModel[]>(models);
            foreach (var entitiy in entities)
            {
                _dbContext.Entry(entitiy).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }

        public override void Update(IEnumerable<ExaLibModel> models)
        {
            var entities = _autoMapper.Map<IEnumerable<ExaLibModel>>(models);
            foreach (var entitiy in entities)
            {
                _dbContext.Entry(models).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }
    }
}
