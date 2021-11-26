using AutoMapper;
using ClassLib;
using EHS.DataAccess.DAService.Core;
using EHS.DbContexts;
using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHS.DataAccess.DAService
{
    public class CourseModelService : ModelDAService<CourseModel>
    {
        protected readonly DbSet<EhsCourse> _courses;
        protected readonly DbSet<EhsCoursefolder> _coursesfolder;
        protected readonly DbSet<EhsCoursefoldercourseware> _coursefoldercoursewares;
        protected readonly DbSet<EhsCoursearrange> _coursesarrange;
        public CourseModelService(EHSContext dbContext) : base(dbContext)
        {
        }

        public override void Delete(CourseModel model)
        {
            _dbContext.Remove(_dbContext.EhsCourses.Find(model.coursenum));
            _dbContext.RemoveRange(_dbContext.EhsCoursefolders.Where(x => x.Courseid == model.coursenum));
            _dbContext.RemoveRange(_dbContext.EhsCoursefoldercoursewares.Where(x => x.Courseid == model.coursenum));
            _dbContext.RemoveRange(_dbContext.EhsCoursearranges.Where(x => x.Courseid == model.coursenum));
            _dbContext.SaveChanges();
        }

        public override void Delete(params CourseModel[] models)
        {
            var ids = models.Select(x => x.coursenum);
            _dbContext.RemoveRange(_dbContext.EhsCourses.Where(x => ids.Contains(x.Id)));
            _dbContext.RemoveRange(_dbContext.EhsCoursefolders.Where(x => ids.Contains(x.Courseid)));
            _dbContext.RemoveRange(_dbContext.EhsCoursefoldercoursewares.Where(x => ids.Contains(x.Courseid)));
            _dbContext.RemoveRange(_dbContext.EhsCoursearranges.Where(x => ids.Contains(x.Courseid)));
            _dbContext.SaveChanges();
        }

        public override void Delete(IEnumerable<CourseModel> models)
        {
            var ids = models.Select(x => x.coursenum);
            _dbContext.RemoveRange(_dbContext.EhsCourses.Where(x => ids.Contains(x.Id)));
            _dbContext.RemoveRange(_dbContext.EhsCoursefolders.Where(x => ids.Contains(x.Courseid)));
            _dbContext.RemoveRange(_dbContext.EhsCoursefoldercoursewares.Where(x => ids.Contains(x.Courseid)));
            _dbContext.RemoveRange(_dbContext.EhsCoursearranges.Where(x => ids.Contains(x.Courseid)));
            _dbContext.SaveChanges();
        }

        public override IEnumerable<CourseModel> GetAll()
        {
            var courses = _dbContext.EhsCourses.AsNoTracking().AsEnumerable();
            var coursearranges = _dbContext.EhsCoursearranges.AsNoTracking().AsEnumerable();
            var coursefolders = _dbContext.EhsCoursefolders.AsNoTracking().AsEnumerable();
            var coursefoldercoursewares = _dbContext.EhsCoursefoldercoursewares.AsNoTracking().AsEnumerable();

            foreach (EhsCourse tmp in courses)
            {
                CourseModel courseModel = new CourseModel()
                {
                    coursename = tmp.Name,
                    coursenum = tmp.Id,
                    coursetype = tmp.Type,
                    coursecount = tmp.Classhour,
                    coursesummery = tmp.Context,
                    creatime = tmp.Createtime,
                };
                var tmparra = coursearranges.Where(x => x.Courseid.Equals(tmp.Id));
                courseModel.participants = new();
                #region 权限判定
                if (tmparra.Any())
                {
                    if (tmparra.Count() == 1 && tmparra.First().Authority.Equals(configure.Authority1[0]))
                    {
                        courseModel.participants = null;
                        courseModel.authority = configure.Authority1[0];
                    }
                    else
                    {
                        courseModel.authority = configure.Authority1[1];
                        foreach (EhsCoursearrange ehsCoursearrange in tmparra)
                        {
                            courseModel.participants.Add(ehsCoursearrange.Badge);
                        }
                    }
                }
                #endregion
                #region 课件赋值
                courseModel.directories = new List<CourseDirectory>();
                List<EhsCoursefolder> tmpfold = coursefolders.Where(x => x.Courseid.Equals(tmp.Id)).ToList();
                foreach (var t in tmpfold)
                {
                    List<int> wareid = coursefoldercoursewares.Where(x => x.Foldeid.Equals(t.Id)).Select(o => o.Courseware).ToList();
                    courseModel.directories.Add(new CourseDirectory { directoryname = t.Foldername, coursefiles = wareid, fileModels = new() });
                }
                #endregion
                yield return courseModel;
            }
        }

        public override CourseModel Insert(CourseModel model)
        {
            EhsCourse course1 = new EhsCourse
            {
                Name = model.coursename,
                Type = model.coursetype,
                Createtime = model.creatime,
                Classhour = model.coursecount,
                Context = model.coursesummery,
                Coursewarefile = model.coursefile
            };
            _dbContext.Add(course1);
            int a = course1.Id;
            model.coursenum = a;
            //添加课程安排表
            List<EhsCoursearrange> coursearranges = new List<EhsCoursearrange>();
            if (model.participants.Count > 0)
            {
                foreach (var i in model.participants)
                {
                    coursearranges.Add(new EhsCoursearrange { Authority = "指定人员", Badge = i, Courseid = a });
                }
            }
            else
            {
                coursearranges.Add(new EhsCoursearrange { Authority = "完全公开", Courseid = a, Badge = -1 });
            }
            _dbContext.AddRange(coursearranges);
            return model;
        }

        public override void Insert(params CourseModel[] models)
        {
            LinkedList<EhsCoursearrange> coursearranges = new();
            foreach (var model in models)
            {
                EhsCourse course1 = new EhsCourse
                {
                    Name = model.coursename,
                    Type = model.coursetype,
                    Createtime = model.creatime,
                    Classhour = model.coursecount,
                    Context = model.coursesummery,
                    Coursewarefile = model.coursefile
                };
                _dbContext.Add(course1);
                int id = course1.Id;
                model.coursenum = id;
                if (model.authority.Equals(configure.Authority1[1]) && model.participants.Any())
                {
                    foreach (var i in model.participants)
                    {
                        coursearranges.AddLast(new EhsCoursearrange { Authority = "指定人员", Badge = i, Courseid = id });
                    }
                }
                if (model.authority.Equals(configure.Authority1[0]))
                {
                    coursearranges.AddLast(new EhsCoursearrange { Authority = "完全公开", Courseid = id, Badge = -1 });
                }
            }
            _dbContext.AddRange(coursearranges);
            _dbContext.SaveChanges();
        }

        public override void Insert(IEnumerable<CourseModel> models)
        {
            LinkedList<EhsCoursearrange> coursearranges = new();
            foreach (var model in models)
            {
                EhsCourse course1 = new EhsCourse
                {
                    Name = model.coursename,
                    Type = model.coursetype,
                    Createtime = model.creatime,
                    Classhour = model.coursecount,
                    Context = model.coursesummery,
                    Coursewarefile = model.coursefile
                };
                _dbContext.Add(course1);
                int id = course1.Id;
                model.coursenum = id;
                if (model.authority.Equals(configure.Authority1[1]) && model.participants.Any())
                {
                    foreach (var i in model.participants)
                    {
                        coursearranges.AddLast(new EhsCoursearrange { Authority = "指定人员", Badge = i, Courseid = id });
                    }
                }
                if (model.authority.Equals(configure.Authority1[0]))
                {
                    coursearranges.AddLast(new EhsCoursearrange { Authority = "完全公开", Courseid = id, Badge = -1 });
                }
            }
            _dbContext.AddRange(coursearranges);
            _dbContext.SaveChanges();

        }

        public override void Update(CourseModel model)
        {
            var course1 = _dbContext.EhsCourses.Find(model.coursenum);
            course1.Name = model.coursename;
            course1.Type = model.coursetype;
            course1.Createtime = model.creatime;
            course1.Classhour = model.coursecount;
            course1.Context = model.coursesummery;
            _dbContext.Update(course1);

            int id = model.coursenum;
            //更新课程安排表
            var arrangs = _dbContext.EhsCoursearranges.Where(x => x.Courseid == id);
            if (model.authority.Equals(configure.Authority1[0]))
            {
                if (arrangs.Any())
                {
                    _dbContext.RemoveRange(arrangs);
                    _dbContext.Add(new EhsCoursearrange { Authority = configure.Authority1[0], Badge = 0, Courseid = id });
                }
            }
            else
            {
                _dbContext.RemoveRange(arrangs);
                List<EhsCoursearrange> coursearranges = new List<EhsCoursearrange>();
                foreach (var i in model.participants)
                {
                    coursearranges.Add(new EhsCoursearrange { Authority = configure.Authority1[1], Badge = i, Courseid = id });
                }
                _dbContext.AddRange(coursearranges);
            }

            //更新课程文件加
            _dbContext.EhsCoursefolders.RemoveRange(_dbContext.EhsCoursefolders.Where(x => x.Courseid == id));
            _dbContext.EhsCoursefoldercoursewares.RemoveRange(_dbContext.EhsCoursefoldercoursewares.Where(x => x.Courseid == id));
            // List<EhsCoursefolder> coursefolders = new List<EhsCoursefolder>();
            List<EhsCoursefoldercourseware> coursefoldercoursewares = new List<EhsCoursefoldercourseware>();
            foreach (var i in model.directories)
            {
                EhsCoursefolder tmp = new EhsCoursefolder
                {

                    Courseid = course1.Id,
                    Foldername = i.directoryname,
                };
                _dbContext.Add(tmp);
                foreach (var j in i.coursefiles)
                {
                    coursefoldercoursewares.Add(new EhsCoursefoldercourseware
                    {
                        Courseid = course1.Id,
                        Foldeid = tmp.Id,
                        Courseware = j
                    }
                    );
                }
            }
            _dbContext.EhsCoursefoldercoursewares.AddRange(coursefoldercoursewares);
            _dbContext.SaveChanges();

        }

        public override void Update(params CourseModel[] models)
        {
            foreach (var item in models)
            {
                Insert(item);
            }
        }

        public override void Update(IEnumerable<CourseModel> models)
        {
            foreach (var item in models)
            {
                Insert(item);
            }
        }
    }
}
