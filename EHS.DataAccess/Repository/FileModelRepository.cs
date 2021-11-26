using AutoMapper;
using ClassLib;
using EHS.DbContexts;
using EHS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace EHS.DataAccess.Repository
{
    public class FileModelRepository : Repository<FileModel>
    {
        public FileModelRepository(EHSContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override void Delete(FileModel model)
        {
            _dbContext.EhsCoursewares.Remove(_dbContext.EhsCoursewares.Find(model.Filenum));
            _dbContext.SaveChanges();
            //_dbContext.EhsCoursewares.Persist(_autoMapper).Remove<FileModel>(model);
            //_dbContext.SubmitChanges();
        }

        public override void Delete(params FileModel[] models)
        {
            var ids = models.Select(x => x.Filenum);
            var query = _dbContext.EhsCoursewares.Where(x => ids.Contains(x.Id));
            _dbContext.EhsCoursewares.RemoveRange(query);
            _dbContext.SaveChanges();
            //_dbContext.EhsCoursewares.Persist(_autoMapper).Remove<FileModel[]>(models);
        }

        public override void Delete(IEnumerable<FileModel> models)
        {
            var ids = models.Select(x => x.Filenum);
            var query = _dbContext.EhsCoursewares.Where(x => ids.Contains(x.Id));
            _dbContext.EhsCoursewares.RemoveRange(query);
            _dbContext.SaveChanges();
            //_dbContext.EhsCoursewares.Persist(_autoMapper).Remove<IEnumerable<FileModel>>(models);
        }

        public override IEnumerable<FileModel> GetAll()
        {
            var query = _dbContext.EhsCoursewares.AsNoTracking().ProjectTo<FileModel>(_autoMapper.ConfigurationProvider).AsEnumerable();
            return query;
        }

        public override FileModel Insert(FileModel model)
        {
            var entity = _autoMapper.Map<EhsCourseware>(model);
            _dbContext.Add(entity);
            model.Filenum = entity.Id;
            _dbContext.SaveChanges();
            return model;
        }

        public override void Insert(params FileModel[] models)
        {
            var coursewares = _autoMapper.Map<IEnumerable<EhsCourseware>>(models);
            _dbContext.AddRange(coursewares);
            _dbContext.SaveChanges();
        }

        public override void Insert(IEnumerable<FileModel> models)
        {
            //LinkedList<EhsCourseware> coursewares = new LinkedList<EhsCourseware>();
            //foreach (var model in models)
            //{
            //    var entity =new EhsCourseware
            //    {
            //        Starttime = model.uploadtime,
            //        Name = model.filename,
            //        Tag = model.courseclass,
            //        Type = model.type,
            //        Extension = model.extension,
            //        Capable = model.capable
            //    };
            //    coursewares.AddLast(entity);
            //}
            var coursewares = _autoMapper.Map<IEnumerable<EhsCourseware>>(models);
            _dbContext.AddRange(coursewares);
            _dbContext.SaveChanges();
        }

        public override void Update(FileModel model)
        {

            //var entity = _dbContext.EhsCoursewares.Find(model.Filenum);
            //entity.Starttime = model.uploadtime;
            //entity.Name = model.filename;
            //entity.Tag = model.courseclass;
            //entity.Type = model.type;
            //entity.Capable = model.capable;
            //entity.Extension = model.extension;
            var entity = _autoMapper.Map<EhsCourseware>(model);
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public override void Update(params FileModel[] models)
        {
            //foreach (var model in models)
            //{
            //    var entity = _dbContext.EhsCoursewares.Find(model.Filenum);
            //    entity.Starttime = model.uploadtime;
            //    entity.Name = model.filename;
            //    entity.Tag = model.courseclass;
            //    entity.Type = model.type;
            //    entity.Capable = model.capable;
            //    entity.Extension = model.extension;
            //}
            var entities = _autoMapper.Map<EhsCourseware[]>(models);
            _dbContext.UpdateRange(entities);
            _dbContext.SaveChanges();
        }

        public override void Update(IEnumerable<FileModel> models)
        {
            //foreach (var model in models)
            //{
            //    var entity = _dbContext.EhsCoursewares.Find(model.Filenum);
            //    entity.Starttime = model.uploadtime;
            //    entity.Name = model.filename;
            //    entity.Tag = model.courseclass;
            //    entity.Type = model.type;
            //    entity.Capable = model.capable;
            //    entity.Extension = model.extension;
            //}
            var entities = _autoMapper.Map<IEnumerable<EhsCourseware>>(models);
            _dbContext.UpdateRange(entities);
            _dbContext.SaveChanges();
        }
    }
}
