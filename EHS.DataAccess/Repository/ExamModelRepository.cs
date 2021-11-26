using AutoMapper;
using ClassLib;
using EHS.DbContexts;
using EHS.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EHS.DataAccess.Repository
{
    public class ExamModelRepository : Repository<ExamModel>
    {
        public ExamModelRepository(EHSContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public override void Delete(ExamModel model)
        {
            string Examname = model.examname;
            _dbContext.Remove(_dbContext.EhsExams.Find(Examname));
            _dbContext.RemoveRange(_dbContext.EhsExamarranges.Where(e => e.Examname == Examname));
            _dbContext.RemoveRange(_dbContext.EhsExamquestionscores.Where(e => e.Examname == Examname));
            _dbContext.RemoveRange(_dbContext.EhsExamrecords.Where(e => e.Examname == Examname));
        }

        public override void Delete(params ExamModel[] models)
        {
            base.Delete(models);
        }

        public override void Delete(IEnumerable<ExamModel> models)
        {
            base.Delete(models);
        }

        public override IEnumerable<ExamModel> GetAll()
        {
            var exams = _dbContext.EhsExams.AsNoTracking();
            var examarranges = _dbContext.EhsExamarranges.AsNoTracking();//_unitOfWork.EhsExamarrangeRepository.Get().ToList();
            var examquestionscores = _dbContext.EhsExamquestionscores.AsNoTracking();//_unitOfWork.EhsExamquestionscoreRepository.Get().ToList();
            List<ExamModel> models = new List<ExamModel>(exams.Count());
            foreach (var i in exams)
            {
                ExamModel tmp = new ExamModel
                {
                    endtime = i.Endtime,
                    examfile = i.Examfile,
                    examname = i.Examname,
                    artifitial = (bool)i.Artifitial,
                    Anhuan = i.Anhuan,
                    section = i.Section,
                    starttime = i.Starttime,
                    lasttime = i.Lsattime,
                    totalscore = i.Toalscore,
                    limittime = (bool)i.limittime,
                    level = i.Levels,
                    qualifiedscore = i.Qualifiedscore,
                    limitcount = i.Limitcount,
                    libname = i.Libname,
                    type = i.Type,
                    status = false
                };
                var ea = examarranges.Where(x => x.Examname == i.Examname);
                if (ea.Any())
                {
                    tmp.authority = ea.First().Authority;
                    if (tmp.authority.Equals(configure.Authority2[0])) { };
                    if (tmp.authority.Equals(configure.Authority2[1]))
                    {
                        tmp.password = ea.First().Password;
                    };
                    if (tmp.authority.Equals(configure.Authority2[2]))
                    {
                        tmp.department = new List<string>();
                        foreach (var depar in ea)
                            tmp.department.Add(depar.Department);
                    };
                    if (tmp.authority.Equals(configure.Authority2[3]))
                    {
                        tmp.badge = new List<int>();
                        foreach (var depar in ea)
                            tmp.badge.Add(depar.Badge);
                    };
                }
                tmp.questions = examquestionscores
                    .Where(x => x.Examname == i.Examname)
                    .Select(x => new
                    {
                        x.Questionid,
                        x.Questionscore
                    })
                    .ToDictionary(c => c.Questionid, c => c.Questionscore);
                models.Add(tmp);
            }

            return models.OrderByDescending(x => x.starttime);
        }

        public override ExamModel Insert(ExamModel model)
        {
            var exam = new EhsExam
            {
                Endtime = model.endtime,
                Examfile = model.examfile,
                Examname = model.examname,
                Artifitial = model.artifitial,
                Levels = model.level,
                Limitcount = model.limitcount,
                Section = model.section,
                Libname = model.libname,
                Anhuan = model.Anhuan,
                Type = model.type,
                Starttime = model.starttime,
                limittime = model.limittime,
                Lsattime = model.lasttime,
                Limittime = model.limittime,
                Qualifiedscore = model.qualifiedscore,
                Toalscore = model.totalscore
            };
            _dbContext.EhsExams.Add(exam);
            if (model.authority.Equals(configure.Authority2[0]))
            {
                _dbContext.Add(new EhsExamarrange
                {
                    Authority = model.authority,
                    Badge = 0,
                    Examname = model.examname,
                    Department = "",
                    Password = ""
                });
            };
            if (model.authority.Equals(configure.Authority2[1]))
            {
                _dbContext.Add(new EhsExamarrange
                {
                    Authority = model.authority,
                    Badge = 0,
                    Examname = model.examname,
                    Department = "",
                    Password = model.password
                });
            };
            if (model.authority.Equals(configure.Authority2[2]))
            {
                List< EhsExamarrange > examarranges=new List< EhsExamarrange >(model.department.Count);
                foreach (var depar in model.department)
                {
                    EhsExamarrange examarrange = new EhsExamarrange
                    {
                        Authority = model.authority,
                        Badge = 0,
                        Examname = model.examname,
                        Department = depar,
                        Password = ""
                    };
                    examarranges.Add(examarrange);
                }
                _dbContext.AddRange(examarranges);
            };
            if (model.authority.Equals(configure.Authority2[3]))
            {
                List<EhsExamarrange> examarranges = new List<EhsExamarrange>(model.department.Count);
                foreach (var b in model.badge)
                {
                    EhsExamarrange examarrange = new EhsExamarrange
                    {
                        Authority = model.authority,
                        Badge = b,
                        Examname = model.examname,
                        Department = "",
                        Password = ""
                    };
                    examarranges.Add(examarrange);
                }
                _dbContext.AddRange(examarranges);
            };

            List< EhsExamquestionscore > examquestionscores=new List<EhsExamquestionscore>(model.questions.Count);
            foreach (var s in model.questions)
            {
                EhsExamquestionscore examquestionscore = new EhsExamquestionscore
                {
                    Examname = model.examname,
                    Questionid = s.Key,
                    Questionscore = s.Value
                };
               examquestionscores.Add(examquestionscore);
            }
            _dbContext.AddRange(examquestionscores);
            _dbContext.SaveChanges();
            
            return model;
        }

        public override void Insert(params ExamModel[] models)
        {
            base.Insert(models);
        }

        public override void Insert(IEnumerable<ExamModel> models)
        {
            base.Insert(models);
        }

        public override void Update(ExamModel model)
        {
            var i = _dbContext.EhsExams.Find(model.examname);
            if (i == null) return;
            i.Artifitial = model.artifitial;
            i.Endtime = model.endtime;
            i.Examfile = model.examfile;
            i.Libname = model.libname;
            i.limittime = model.limittime;
            i.Lsattime = model.lasttime;
            i.Qualifiedscore = model.qualifiedscore;
            i.Section = model.section;
            i.Type = model.type;
            i.Anhuan = model.Anhuan;
            i.Levels = model.level;
            i.Starttime = model.starttime;
            i.Limitcount = model.limitcount;
            i.Toalscore = model.totalscore;

            var examarranges1 = _dbContext.EhsExamarranges.Where(e => e.Examname == model.examname);
            _dbContext.RemoveRange(examarranges1);

            if (model.authority.Equals(configure.Authority2[0]))
            {
                _dbContext.Add(new EhsExamarrange
                {
                    Authority = model.authority,
                    Badge = 0,
                    Examname = model.examname,
                    Department = "",
                    Password = ""
                });
            };
            if (model.authority.Equals(configure.Authority2[1]))
            {
                _dbContext.Add(new EhsExamarrange
                {
                    Authority = model.authority,
                    Badge = 0,
                    Examname = model.examname,
                    Department = "",
                    Password = model.password
                });
            };
            if (model.authority.Equals(configure.Authority2[2]))
            {
                List<EhsExamarrange> examarranges = new List<EhsExamarrange>(model.department.Count);
                foreach (var depar in model.department)
                {
                    EhsExamarrange examarrange = new EhsExamarrange
                    {
                        Authority = model.authority,
                        Badge = 0,
                        Examname = model.examname,
                        Department = depar,
                        Password = ""
                    };
                    examarranges.Add(examarrange);
                }
                _dbContext.AddRange(examarranges);
            };
            if (model.authority.Equals(configure.Authority2[3]))
            {
                List<EhsExamarrange> examarranges = new List<EhsExamarrange>(model.department.Count);
                foreach (var b in model.badge)
                {
                    EhsExamarrange examarrange = new EhsExamarrange
                    {
                        Authority = model.authority,
                        Badge = b,
                        Examname = model.examname,
                        Department = "",
                        Password = ""
                    };
                    examarranges.Add(examarrange);
                }
                _dbContext.AddRange(examarranges);
            };

            var examquestionscores1 = _dbContext.EhsExamquestionscores.Where(e => e.Examname == model.examname);
            _dbContext.RemoveRange(examquestionscores1);

            List<EhsExamquestionscore> examquestionscores = new List<EhsExamquestionscore>(model.questions.Count);
            foreach (var s in model.questions)
            {
                EhsExamquestionscore examquestionscore = new EhsExamquestionscore
                {
                    Examname = model.examname,
                    Questionid = s.Key,
                    Questionscore = s.Value
                };
                examquestionscores.Add(examquestionscore);
            }
            _dbContext.AddRange(examquestionscores);
            _dbContext.SaveChanges();


        }

        public override void Update(params ExamModel[] models)
        {
            base.Update(models);
        }

        public override void Update(IEnumerable<ExamModel> models)
        {
            base.Update(models);
        }
    }
}
