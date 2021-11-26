using AutoMapper;
using AutoMapper.Collection;
using AutoMapper.EquivalencyExpression;
using ClassLib;
using EHS.Entities;

namespace EHS.DataAccess
{
    public class mapperconfig : Profile
    {
        public mapperconfig()
        {
            CreateMap<FileModel, EhsCourseware>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Filenum))
                .ForMember(x=>x.Name,y=>y.MapFrom(z=>z.filename))
                .ForMember(x=>x.Starttime,y=>y.MapFrom(z=>z.uploadtime))
                .ForMember(x=>x.Tag,y=>y.MapFrom(z=>z.courseclass))
                .ForMember(x=>x.Type,y=>y.MapFrom(z=>z.type))
                .ForMember(x=>x.Capable,y=>y.MapFrom(z=>z.capable))
                .ForMember(x=>x.Extension,y=>y.MapFrom(z=>z.extension))
                //.EqualityComparison((x,y)=>x.Filenum==y.Id)
                .ReverseMap();
 
            CreateMap<ExaLibModel, EhsLib>()
                .ForMember(x => x.Createtime, y => y.MapFrom(z => z.createtime))
                .ForMember(x => x.Libname, y => y.MapFrom(z => z.libname))
                .ForMember(x => x.Questcount, y => y.MapFrom(z => z.questcount))
                .ForMember(x => x.Libsummary, y => y.MapFrom(z => z.libsummary))
                .ForMember(x => x.Questionpath, y => y.MapFrom(z => z.libfilelpath))
                .ForMember(x => x.Type, y => y.MapFrom(z => z.type))
                .ForMember(x => x.Usage, y => y.MapFrom(z => z.usage))
                .ForMember(x => x.Sectioncount, y => y.MapFrom(z => Converter.ParseToString(z.sections) ?? "1:第一章"));
            CreateMap< EhsLib, ExaLibModel>()
                .ForMember(x => x.createtime, y => y.MapFrom(z => z.Createtime))
                .ForMember(x => x.libname, y => y.MapFrom(z => z.Libname))
                .ForMember(x => x.questcount, y => y.MapFrom(z => z.Questcount))
                .ForMember(x => x.libsummary, y => y.MapFrom(z => z.Libsummary))
                .ForMember(x => x.libfilelpath, y => y.MapFrom(z => z.Questionpath))
                .ForMember(x => x.type, y => y.MapFrom(z => z.Type))
                .ForMember(x => x.usage, y => y.MapFrom(z => z.Usage))
                .ForMember(x => x.sections, y => y.MapFrom(z => Converter.ParseToDictionaryIS( z.Sectioncount)));

            CreateMap<GradeModel, EhsExamrecord>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.name))
                .ForMember(x => x.Lasttime, y => y.MapFrom(y => y.lasttime))
                .ForMember(x => x.Objectivescore, y => y.MapFrom(z => z.Objectivescore))
                .ForMember(x => x.Score, y => y.MapFrom(z => z.score))
                .ForMember(x => x.Qualified, y => y.MapFrom(z => z.qualified))
                .ForMember(x => x.Badge, y => y.MapFrom(z => z.worknum))
                .ForMember(x => x.Answerpath, y => y.MapFrom(z => z.answerpath))
                .ForMember(x => x.Examname, y => y.MapFrom(z => z.examname))
                .ForMember(x => x.Examtime, y => y.MapFrom(z => z.examtime))
                .ForMember(x => x.Lasttime, y => y.MapFrom(z => z.lasttime))
                .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
                .ForMember(x => x.Subjectivescore, y => y.MapFrom(z => z.Subjectivescore))
                .ReverseMap();
           
                }
    }
}
