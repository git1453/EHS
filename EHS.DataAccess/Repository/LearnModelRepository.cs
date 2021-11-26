using ClassLib;
using EHS.DbContexts;
using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EHS.DataAccess.Repository
{
    public class LearnModelRepository :Repository<LearnModel>
    {
        public LearnModelRepository(EHSContext dbContext) : base(dbContext)
        {
        }

        #region GetAll
        public override IEnumerable<LearnModel> GetAll()
        {
            var models = _dbContext.EhsStudyrecords.AsNoTracking().Select(x => new LearnModel
            {
                updatetime = x.Updatetime,
                allwares = x.Totalcoureseware,
                coursenum = x.Courseid,
                id = x.Id,
                eid = x.Badge
            });
            foreach (var model in models)
            {
                int id = model.coursenum;
                model.learnedwares = _dbContext.EhsStudyrecords.AsNoTracking()
                    .Where(predicate: y => y.Courseid.Equals(id))
                    .Select(z => z.Id).ToList();
                model.course = _dbContext.EhsCourses.FirstOrDefault(x => x.Id.Equals(id))?.Name;
            }
            return models;
        }
        #endregion

        #region Add
        public override LearnModel Insert(LearnModel model)
        {
            EhsStudyrecord studyrecord = new EhsStudyrecord
            {
                Badge = model.eid,
                Courseid = model.coursenum,
                Updatetime = model.updatetime,
                Totalcoureseware = model.allwares
            };
            _dbContext.EhsStudyrecords.Add(studyrecord);
            foreach (var i in model.learnedwares)
            {
                _dbContext.EhsStudiedcoursewares.Add(new EhsStudiedcourseware
                {
                    Badge = model.id,
                    Courseid = model.coursenum,
                    Coursewareid = i
                });
            }
            _dbContext.SaveChanges();
            if (studyrecord.Id == default(int))
                return null;
            else
            {
                model.id = studyrecord.Id;
                return model;
            }
        }

        public override void Insert(params LearnModel[] models)
        {
            EhsStudyrecord[] studyrecords = new EhsStudyrecord[models.Length];
            for (int i = 0; i < studyrecords.Length; i++)
            {
                studyrecords[i] = new EhsStudyrecord
                {
                    Badge = models[i].eid,
                    Courseid = models[i].coursenum,
                    Updatetime = models[i].updatetime,
                    Totalcoureseware = models[i].allwares
                };
            }
            _dbContext.EhsStudyrecords.AddRange(studyrecords);
            List<EhsStudiedcourseware> studiedcoursewares = new();
            foreach (var model in models)
            {
                foreach (var i in model.learnedwares)
                {
                    studiedcoursewares.Add(new EhsStudiedcourseware
                    {
                        Badge = model.id,
                        Courseid = model.coursenum,
                        Coursewareid = i
                    });
                }
            }
            _dbContext.EhsStudiedcoursewares.AddRange(studiedcoursewares);
            _dbContext.SaveChanges();
        }
        public override void Insert(IEnumerable<LearnModel> models)
        {
            LinkedList<EhsStudyrecord> studyrecords = new();
            LinkedList<EhsStudiedcourseware> studiedcoursewares = new();
            int i = 0;
            foreach (var model in models)
            {
                studyrecords.AddLast(new EhsStudyrecord
                {
                    Badge = model.eid,
                    Courseid = model.coursenum,
                    Updatetime = model.updatetime,
                    Totalcoureseware = model.allwares
                });
                foreach (var id in model.learnedwares)
                {
                    studiedcoursewares.AddLast(new EhsStudiedcourseware
                    {
                        Badge = model.id,
                        Courseid = model.coursenum,
                        Coursewareid = id
                    });
                }
                i++;
            }
            _dbContext.EhsStudyrecords.AddRange(studyrecords);
            _dbContext.EhsStudiedcoursewares.AddRange(studiedcoursewares);
            _dbContext.SaveChanges();
        }

        #endregion

        #region Update

        public override void Update(LearnModel model)
        {
            var entity = _dbContext.EhsStudyrecords.Find(model.eid);
            entity.Badge = model.eid;
            entity.Courseid = model.coursenum;
            entity.Updatetime = model.updatetime;
            entity.Totalcoureseware = model.allwares;
            var ex = _dbContext.EhsStudiedcoursewares
                .Where(x => x.Courseid == model.coursenum && x.Badge == model.eid)
                .Select(x => x.Courseid); //已学课件id
            var adds = model.learnedwares.Except(ex);//新增课件id
            LinkedList<EhsStudiedcourseware> studiedcoursewares = new LinkedList<EhsStudiedcourseware>();
            foreach (var i in adds)
            {
                studiedcoursewares.AddLast(new EhsStudiedcourseware
                {
                    Badge = model.id,
                    Courseid = model.coursenum,
                    Coursewareid = i
                });
            }
            _dbContext.AddRange(studiedcoursewares);
            _dbContext.SaveChanges();
        }

        public override void Update(params LearnModel[] models)
        {
            LinkedList<EhsStudiedcourseware> studiedcoursewares = new LinkedList<EhsStudiedcourseware>();
            foreach (var model in models)
            {
                var entity = _dbContext.EhsStudyrecords.Find(model.eid);
                entity.Badge = model.eid;
                entity.Courseid = model.coursenum;
                entity.Updatetime = model.updatetime;
                entity.Totalcoureseware = model.allwares;
                var ex = _dbContext.EhsStudiedcoursewares
                    .Where(predicate: x => x.Courseid == model.coursenum && x.Badge == model.eid)
                    .Select(x => x.Courseid); //已学课件id
                var adds = model.learnedwares.Except(ex);//新增课件id
                foreach (var i in adds)
                {
                    studiedcoursewares.AddLast(new EhsStudiedcourseware
                    {
                        Badge = model.id,
                        Courseid = model.coursenum,
                        Coursewareid = i
                    });
                }
            }
            _dbContext.AddRange(studiedcoursewares);
            _dbContext.SaveChanges();
        }

        public override void Update(IEnumerable<LearnModel> models)
        {
            foreach (var model in models)
            {
                var entity = _dbContext.EhsStudyrecords.Find(model.eid);
                entity.Badge = model.eid;
                entity.Courseid = model.coursenum;
                entity.Updatetime = model.updatetime;
                entity.Totalcoureseware = model.allwares;
                var ex = _dbContext.EhsStudiedcoursewares
                    .Where(predicate: x => x.Courseid == model.coursenum && x.Badge == model.eid)
                    .Select(x => x.Courseid); //已学课件id
                var adds = model.learnedwares.Except(ex);//新增课件id
                foreach (var i in adds)
                {
                    _dbContext.EhsStudiedcoursewares.Add(new EhsStudiedcourseware
                    {
                        Badge = model.id,
                        Courseid = model.coursenum,
                        Coursewareid = i
                    });
                }
            }
            _dbContext.SaveChanges();
        }
        #endregion

        #region Delete

        public override void Delete(LearnModel model)
        {
            _dbContext.EhsStudyrecords.Remove(_dbContext.EhsStudyrecords.Find(model.id));
            var query = _dbContext.EhsStudiedcoursewares.Where(predicate: x => x.Courseid.Equals(model.id));
            _dbContext.EhsStudiedcoursewares.RemoveRange(query);
            _dbContext.SaveChanges();
        }

        public override void Delete(params LearnModel[] models)
        {
            var ids = models.Select(x => x.id);
            _dbContext.RemoveRange(_dbContext.EhsStudyrecords.AsNoTracking().Where(x => ids.Contains(x.Id)));

            var query = _dbContext.EhsStudiedcoursewares.Where(predicate: x => ids.Contains(x.Courseid));
            _dbContext.EhsStudiedcoursewares.RemoveRange(query);
            _dbContext.SaveChanges();
        }

        public override void Delete(IEnumerable<LearnModel> models)
        {
            var ids = models.Select(x => x.id);
            _dbContext.RemoveRange(_dbContext.EhsStudyrecords.AsNoTracking().Where(x => ids.Contains(x.Id)));
            var query = _dbContext.EhsStudiedcoursewares.Where(predicate: x => ids.Contains(x.Courseid));
            _dbContext.EhsStudiedcoursewares.RemoveRange(query);
            _dbContext.SaveChanges();
        }
        #endregion 
    }
}
