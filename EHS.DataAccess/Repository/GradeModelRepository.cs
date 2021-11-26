using AutoMapper;
using AutoMapper.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using ClassLib;
using EHS.DbContexts;
using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EHS.DataAccess.Repository
{
    public class GradeModelRepository : Repository<GradeModel>
    {
        public GradeModelRepository(EHSContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override void Delete(GradeModel model)
        {
            _dbContext.EhsExamrecords.Persist(_autoMapper).Remove(model);
            _dbContext.SaveChanges();
        }

        public override void Delete(params GradeModel[] models)
        {
            var ids = models.Select(x => x.id);
            var del= _dbContext.EhsExamrecords.Where(x=>ids.Contains(x.Id));
            _dbContext.RemoveRange(del);
            _dbContext.SaveChanges();
        }

        public override void Delete(IEnumerable<GradeModel> models)
        {
            var ids = models.Select(x => x.id);
            var del = _dbContext.EhsExamrecords.Where(x => ids.Contains(x.Id));
            _dbContext.RemoveRange(del);
            _dbContext.SaveChanges();
        }

        public override IEnumerable<GradeModel> GetAll()
        {
           var models= _dbContext.EhsExamrecords.AsNoTracking().ProjectTo<GradeModel>(_autoMapper.ConfigurationProvider).AsEnumerable();
            return models;
        }

        public override GradeModel Insert(GradeModel model)
        {
            var entity =_autoMapper.Map<EhsExamrecord>(model);
            _dbContext.EhsExamrecords.Add(entity);
            _dbContext.SaveChanges();
            model.id = entity.Id;
            return model;
        }

        public override void Insert(params GradeModel[] models)
        {
            var entities= _autoMapper.Map<EhsExamrecord[]>(models);
            _dbContext.AddRange(entities);
            _dbContext.SaveChanges();
        }

        public override void Insert(IEnumerable<GradeModel> models)
        {
            var entities = _autoMapper.Map<IEnumerable<GradeModel>>(models);
            _dbContext.AddRange(entities);
            _dbContext.SaveChanges();
        }

        public override void Update(GradeModel model)
        {
            _dbContext.EhsExamrecords.Persist(_autoMapper).InsertOrUpdate(model);
            _dbContext.SaveChanges();
        }

        public override void Update(params GradeModel[] models)
        {
            foreach (var model in models)
            {
                _dbContext.EhsExamrecords.Persist(_autoMapper).InsertOrUpdate(model);
            }
            _dbContext.SaveChanges();
        }

        public override void Update(IEnumerable<GradeModel> models)
        {
            foreach (var model in models)
            {
                _dbContext.EhsExamrecords.Persist(_autoMapper).InsertOrUpdate(model);
            }
            _dbContext.SaveChanges();
        }
    }
}
